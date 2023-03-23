using UnityEngine.Animations.Rigging;

namespace AnimationRigging
{
    public class MultiPositionConstraintWrapper : RigConstraintWrapper<MultiPositionConstraint>
    {
        public MultiPositionConstraintWrapper(MultiPositionConstraint constraint) : base(constraint)
        {}
        public override float Weight {get => _constraint.weight; set => _constraint.weight = value;}
    }
}