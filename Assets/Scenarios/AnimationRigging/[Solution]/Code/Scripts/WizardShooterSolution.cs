using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationRigging
{
    public class WizardShooterSolution : WizardShooter
    {
        private AimTarget _aim;

        private void Awake()
        {
            _aim = GetComponentInChildren<AimTarget>();
        }

        protected override IWizardShooterInput InputSetup()
        {
            var input = WizardShooterInputSolution.Build(_aim);
            input.Enable();
            return input;
        }

        protected override void ProcessAiming()
        {
            _aim.AimTo(ShooterInput.AimPosition);
        }
    }
}