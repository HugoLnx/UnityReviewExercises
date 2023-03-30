using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationRigging
{
    public class Wizard : MonoBehaviour
    {
        private WizardInput _input;
        private Animator _animator;
        private WizardAnimations _anim;
        private WizardMovement _movement;

        private WizardInput WizardInput => _input ??= InputSetup();

        private void Awake()
        {
            _anim = new WizardAnimations(GetComponentInChildren<Animator>());
            _movement = GetComponent<WizardMovement>();
        }

        private void Update()
        {
            ProcessMovement();
            UpdateAnimation();
        }

        private void ProcessMovement()
        {
            if (!WizardInput.AxisIsPressed)
            {
                _movement.Stop();
                return;
            }

            _movement.HeadTo(WizardInput.Axis);

            if (WizardInput.RunIsPressed)
            {
                _movement.Run();
            }
            else
            {
                _movement.Walk();
            }
        }

        private void UpdateAnimation()
        {
            _anim.SetDirection(_movement.Direction);
            _anim.SetNormalizedSpeed(_movement.NormalizedSpeed);
        }

        private WizardInput InputSetup()
        {
            _input = WizardInput.Build();
            _input.Enable();
            return _input;
        }
    }
}