using UnityEngine.Animations.Rigging;

namespace AnimationRigging
{
    public class MultiAimConstraintWrapper : RigConstraintWrapper<MultiAimConstraint>
    {
        public MultiAimConstraintWrapper(MultiAimConstraint constraint) : base(constraint)
        {}
        public override float Weight {get => _constraint.weight; set => _constraint.weight = value;}
    }
}