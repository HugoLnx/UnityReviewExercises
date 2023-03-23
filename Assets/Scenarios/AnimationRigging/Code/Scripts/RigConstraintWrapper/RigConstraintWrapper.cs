using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace AnimationRigging
{
    public static class RigConstraintWrapper
    {
        public static readonly HashSet<Type> WrapperTypes = GetAllTypesThatImplement(typeof(IRigConstraintWrapper));
        public static readonly HashSet<Type> RigConstraintTypes = GetConstraintTypesOfWrappers(WrapperTypes);

        private static HashSet<Type> GetAllTypesThatImplement(Type type)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => type.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && t.IsVisible)
                .ToHashSet();
        }

        private static HashSet<Type> GetConstraintTypesOfWrappers(IEnumerable<Type> wrapperTypes)
        {
            return wrapperTypes.Select(t => {
                FieldInfo field = t.GetField("ConstraintType", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
                return (Type) field.GetValue(null);
            }).ToHashSet();
        }

        public static IRigConstraintWrapper[] BuildForAll<T>(IEnumerable<T> constraints)
        {
            return AllWrapped(constraints).ToArray();
        }
        public static IRigConstraintWrapper[] BuildForAllInContainer(Transform container)
        {
            return AllInContainerWrapped(container).ToArray();
        }
        private static IEnumerable<IRigConstraintWrapper> AllWrapped<T>(IEnumerable<T> constraints)
        {
            foreach (T constraint in constraints)
            {
                yield return Wrap(constraint);
            }
        }

        private static IEnumerable<IRigConstraintWrapper> AllInContainerWrapped(Transform container)
        {
            foreach (Type constraintType in RigConstraintTypes)
            {
                Component[] components = container.GetComponentsInChildren(constraintType);
                foreach (IRigConstraintWrapper wrapper in AllWrapped(components))
                {
                    yield return wrapper;
                }
            }
        }

        private static IRigConstraintWrapper Wrap<T>(T constraint)
        {
            switch (constraint)
            {
                case MultiAimConstraint c: return new MultiAimConstraintWrapper(c);
                case TwoBoneIKConstraint c: return new TwoBoneIKConstraintWrapper(c);
                case MultiRotationConstraint c: return new MultiRotationConstraintWrapper(c);
                case BlendConstraint c: return new BlendConstraintWrapper(c);
                case ChainIKConstraint c: return new ChainIKConstraintWrapper(c);
                case TwistChainConstraint c: return new TwistChainConstraintWrapper(c);
                case MultiReferentialConstraint c: return new MultiReferentialConstraintWrapper(c);
                case MultiPositionConstraint c: return new MultiPositionConstraintWrapper(c);
                case MultiParentConstraint c: return new MultiParentConstraintWrapper(c);
                default: throw new InvalidRigConstraintToWrapException($"Can't wrap constraint of type {typeof(T)}");
            };
        }
    }

    public abstract class RigConstraintWrapper<T> : IRigConstraintWrapper
    {
        public static Type ConstraintType = typeof(T);
        protected T _constraint;
        public RigConstraintWrapper(T constraint)
        {
            _constraint = constraint;
        }

        public abstract float Weight {get; set;}
    }
}