using UnityEngine.Animations.Rigging;

namespace AnimationRigging
{
    public class MultiReferentialConstraintWrapper : RigConstraintWrapper<MultiReferentialConstraint>
    {
        public MultiReferentialConstraintWrapper(MultiReferentialConstraint constraint) : base(constraint)
        {}
        public override float Weight {get => _constraint.weight; set => _constraint.weight = value;}
    }
}