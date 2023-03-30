using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationRigging
{
    public abstract class WizardShooter : MonoBehaviour
    {
        private WizardShooterRigging _rigging;
        private IWizardShooterInput _input;

        protected IWizardShooterInput ShooterInput => _input ??= InputSetup();
        private WizardShooterRigging Rigging => _rigging ??= GetComponent<WizardShooterRigging>();

        protected abstract IWizardShooterInput InputSetup();
        protected abstract void ProcessAiming();

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
                Rigging.ToggleShooterMode();
            }
        }

        private void ProcessShoot()
        {
            if (ShooterInput.ShootIsPressed)
            {
                Rigging.ShootingStart();
            }
            else
            {
                Rigging.ShootingStop();
            }
        }
    }
}