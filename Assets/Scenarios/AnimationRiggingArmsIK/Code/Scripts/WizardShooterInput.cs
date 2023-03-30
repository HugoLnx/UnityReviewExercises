using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationRigging
{
    public class WizardShooterInput
    {
        private readonly WizardRawInput.PlayerActions _player;
        private readonly Camera _camera;
        private readonly AimTarget _aimOrigin;

        public bool ShootIsPressed => _player.Shoot.IsPressed();
        public bool ToggleShooterWasPerformed => _player.ToggleShooter.WasPressedThisFrame();
        public Vector3 AimPosition {
            get {
                Vector3 mouseScreenPosition = _player.Aim.ReadValue<Vector2>();
                mouseScreenPosition.z = _camera.nearClipPlane; 
                Vector3 cameraFramePt = _camera.ScreenToWorldPoint(mouseScreenPosition);
                return WhereLineIntersectsPlane(
                    planeNormal: Vector3.up,
                    planeOrigin: new Vector3(0f, _aimOrigin.Height, 0f),
                    lineOrigin: _camera.transform.position,
                    lineEnd: cameraFramePt
                );
            }
        }

        public WizardShooterInput(WizardRawInput.PlayerActions player, Camera camera, AimTarget targetOrigin)
        {
            _player = player;
            _camera = camera;
            _aimOrigin = targetOrigin;
        }

        public void Enable()
        {
            _player.Enable();
        }

        public static WizardShooterInput Build(AimTarget aimOrigin) => new(new WizardRawInput().Player, Camera.main, aimOrigin);
        public static Vector3 WhereLineIntersectsPlane(Vector3 planeNormal, Vector3 planeOrigin, Vector3 lineOrigin, Vector3 lineEnd)
        {
            // Calculate the direction of the line
            Vector3 lineDirection = lineEnd - lineOrigin;

            // Calculate the dot product of the plane normal and the line direction
            float dot = Vector3.Dot(planeNormal, lineDirection);

            // If the dot product is zero, the line is parallel to the plane
            if (Mathf.Approximately(dot, 0f))
            {
                // In this case, we'll return the line start point
                return lineOrigin;
            }

            // Calculate the distance from the line start point to the plane
            Vector3 lineToPlane = planeOrigin - lineOrigin;
            float t = Vector3.Dot(planeNormal, lineToPlane) / dot;

            // Calculate the intersection point by moving along the line by the distance
            return lineOrigin + lineDirection * t;
        }
    }
}