using System;
using System.Collections;
using AnimationRigging;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace AnimationRigging
{
    public class WizardShooterRigging : MonoBehaviour
    {
        private static readonly int IsShootingPropId = Animator.StringToHash("IsShooting");
        private static readonly int ReloadPropId = Animator.StringToHash("Reload");
        [SerializeField] private Transform _gunRigConstraintsContainer;
        [SerializeField] private GameObject _gunInHandContainer;
        private Animator _animator;
        private IRigConstraintWrapper[] _gunRigConstraints;
        private int _shooterLayerInx;

        public bool IsInShooterMode => _gunInHandContainer.activeInHierarchy;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _shooterLayerInx = _animator.GetLayerIndex("Shooter");
            _gunRigConstraints = RigConstraintWrapper.BuildForAllInContainer(_gunRigConstraintsContainer);
        }

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

        public void EnterShooterMode()
        {
            _animator.SetLayerWeight(_shooterLayerInx, 1f);
            _gunInHandContainer.SetActive(true);
            SetGunRigConstraintsWeight(1f);
        }

        public void ExitShooterMode()
        {
            _animator.SetLayerWeight(_shooterLayerInx, 0f);
            _gunInHandContainer.SetActive(false);
            SetGunRigConstraintsWeight(0f);
        }

        public void ShootingStart()
        {
            _animator.SetBool(IsShootingPropId, true);
        }

        public void ShootingStop()
        {
            _animator.SetBool(IsShootingPropId, false);
        }

        public void Reload()
        {
            _animator.SetTrigger(ReloadPropId);
        }

        private void SetGunRigConstraintsWeight(float weight)
        {
            foreach (IRigConstraintWrapper constraint in _gunRigConstraints)
            {
                constraint.Weight = weight;
            }
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