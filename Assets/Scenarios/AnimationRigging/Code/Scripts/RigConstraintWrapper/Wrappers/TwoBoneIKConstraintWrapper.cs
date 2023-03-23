using UnityEngine.Animations.Rigging;

namespace AnimationRigging
{
    public class TwoBoneIKConstraintWrapper : RigConstraintWrapper<TwoBoneIKConstraint>
    {
        public TwoBoneIKConstraintWrapper(TwoBoneIKConstraint constraint) : base(constraint)
        {}
        public override float Weight {get => _constraint.weight; set => _constraint.weight = value;}
    }
}