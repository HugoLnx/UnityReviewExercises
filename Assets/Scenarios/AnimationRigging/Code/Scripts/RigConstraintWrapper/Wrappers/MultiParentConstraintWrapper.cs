using UnityEngine.Animations.Rigging;

namespace AnimationRigging
{
    public class MultiParentConstraintWrapper : RigConstraintWrapper<MultiParentConstraint>
    {
        public MultiParentConstraintWrapper(MultiParentConstraint constraint) : base(constraint)
        {}
        public override float Weight {get => _constraint.weight; set => _constraint.weight = value;}
    }
}