using UnityEngine.Animations.Rigging;

namespace AnimationRigging
{
    public class MultiRotationConstraintWrapper : RigConstraintWrapper<MultiRotationConstraint>
    {
        public MultiRotationConstraintWrapper(MultiRotationConstraint constraint) : base(constraint)
        {}
        public override float Weight {get => _constraint.weight; set => _constraint.weight = value;}
    }
}