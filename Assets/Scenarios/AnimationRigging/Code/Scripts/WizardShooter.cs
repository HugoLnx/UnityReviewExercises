using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationRigging
{
    public class WizardShooter : MonoBehaviour
    {
        private WizardShooterAiming _aiming;
        private WizardShooterRigging _rigging;
        private WizardShooterInput _input;

        private WizardShooterInput ShooterInput => _input ??= InputSetup();

        private void Awake()
        {
            _aiming = GetComponent<WizardShooterAiming>();
            _rigging = GetComponent<WizardShooterRigging>();
        }

        private WizardShooterInput InputSetup()
        {
            _input = WizardShooterInput.Build(_aiming.AimHeightRef);
            _input.Enable();
            return _input;
        }

        private void Update()
        {
            ProcessShooterToggle();
            ProcessAiming();
            ProcessShoot();
        }

        private void ProcessShooterToggle()
        {
            if (ShooterInput.ToggleShooterWasPerformed)
            {
                _rigging.ToggleShooterMode();
            }
        }

        private void ProcessAiming()
        {
            _aiming.AimDirection = ShooterInput.AimPosition;
        }

        private void ProcessShoot()
        {
            if (ShooterInput.ShootIsPressed)
            {
                _rigging.ShootingStart();
            }
            else
            {
                _rigging.ShootingStop();
            }
        }
    }
}