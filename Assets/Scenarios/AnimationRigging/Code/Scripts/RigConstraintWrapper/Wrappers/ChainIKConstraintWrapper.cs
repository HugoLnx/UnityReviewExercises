using UnityEngine.Animations.Rigging;

namespace AnimationRigging
{
    public class ChainIKConstraintWrapper : RigConstraintWrapper<ChainIKConstraint>
    {
        public ChainIKConstraintWrapper(ChainIKConstraint constraint) : base(constraint)
        {}
        public override float Weight {get => _constraint.weight; set => _constraint.weight = value;}
    }
}