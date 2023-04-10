using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace AnimationRigging
{
    public abstract class WizardShooterRigging : MonoBehaviour
    {
        private static readonly int IsShootingPropId = Animator.StringToHash("IsShooting");
        private Animator _animator;
        protected Animator Animator => _animator ??= GetComponentInChildren<Animator>();

        public abstract void EnterShooterMode();
        public abstract void ExitShooterMode();
        public abstract bool IsInShooterMode {get;}

        private void Start()
        {
            EnforceShooterMode();
        }

        public void ToggleShooterMode()
        {
            if (IsInShooterMode)
            {
                ExitShooterMode();
            }
            else
            {
                EnterShooterMode();
            }
        }

        public void ShootingStart()
        {
            _animator.SetBool(IsShootingPropId, true);
        }

        public void ShootingStop()
        {
            _animator.SetBool(IsShootingPropId, false);
        }

        private void EnforceShooterMode()
        {
            if (IsInShooterMode)
            {
                EnterShooterMode();
            }
            else
            {
                ExitShooterMode();
            }
        }
    }
}