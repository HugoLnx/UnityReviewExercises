using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationRigging
{
    public class TodoWizardShooterInput : IWizardShooterInput
    {
        private readonly WizardRawInputTodo.PlayerActions _player;
        private readonly Camera _camera;
        private readonly AimTarget _aimOrigin;

        public bool ShootIsPressed => _player.Shoot.IsPressed();
        public bool ToggleShooterWasPerformed => _player.ToggleShooter.WasPressedThisFrame();
        public Vector3 AimPosition {
            get {
                // TODO: Return the aim position in the world space as the mouse was touching a plane
                // in the height of the aimOrigin
                return Vector3.zero;
            }
        }

        public TodoWizardShooterInput(WizardRawInputTodo.PlayerActions player, Camera camera, AimTarget targetOrigin)
        {
            _player = player;
            _camera = camera;
            _aimOrigin = targetOrigin;
        }

        public void Enable()
        {
            _player.Enable();
        }

        public static TodoWizardShooterInput Build(AimTarget aimOrigin) => new(new WizardRawInputTodo().Player, Camera.main, aimOrigin);
    }
}