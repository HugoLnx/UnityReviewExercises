using System;
using System.Collections;
using AnimationRigging;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace AnimationRigging
{
    public class WizardShooterRiggingSolution : WizardShooterRigging
    {
        [SerializeField] private GameObject _gunInHandContainer;
        [SerializeField] private Rig _armsIKRig;
        private int _shooterLayerInx;
        public override bool IsInShooterMode => _gunInHandContainer.activeInHierarchy;

        private void Awake()
        {
            _shooterLayerInx = Animator.GetLayerIndex("Shooter");
        }

        public override void EnterShooterMode()
        {
            Animator.SetLayerWeight(_shooterLayerInx, 1f);
            _gunInHandContainer.SetActive(true);
            _armsIKRig.weight = 1f;
        }

        public override void ExitShooterMode()
        {
            Animator.SetLayerWeight(_shooterLayerInx, 0f);
            _gunInHandContainer.SetActive(false);
            _armsIKRig.weight = 0f;
        }
    }
}