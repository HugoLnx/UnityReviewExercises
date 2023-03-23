using UnityEngine.Animations.Rigging;

namespace AnimationRigging
{
    public class TwistChainConstraintWrapper : RigConstraintWrapper<TwistChainConstraint>
    {
        public TwistChainConstraintWrapper(TwistChainConstraint constraint) : base(constraint)
        {}
        public override float Weight {get => _constraint.weight; set => _constraint.weight = value;}
    }
}