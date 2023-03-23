using UnityEngine.Animations.Rigging;

namespace AnimationRigging
{
    public class BlendConstraintWrapper : RigConstraintWrapper<BlendConstraint>
    {
        public BlendConstraintWrapper(BlendConstraint constraint) : base(constraint)
        {}
        public override float Weight {get => _constraint.weight; set => _constraint.weight = value;}
    }
}