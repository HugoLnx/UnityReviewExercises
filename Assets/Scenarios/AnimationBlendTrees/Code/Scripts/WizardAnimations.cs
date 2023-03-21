using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AnimationBlendTrees
{
    public class WizardAnimations
    {
        private static readonly int PropIdHeadX = Animator.StringToHash("HeadX");
        private static readonly int PropIdHeadZ = Animator.StringToHash("HeadZ");
        private static readonly int PropIdSpeed = Animator.StringToHash("Speed");
        private readonly Animator _animator;

        public WizardAnimations(Animator animator)
        {
            _animator = animator;
        }

        public void SetDirection(Vector2 direction)
        {
            _animator.SetFloat(PropIdHeadX, direction.x);
            _animator.SetFloat(PropIdHeadZ, direction.y);
        }

        public void SetNormalizedSpeed(float normalizedSpeed)
        {
            _animator.SetFloat(PropIdSpeed, normalizedSpeed);
        }
    }
}