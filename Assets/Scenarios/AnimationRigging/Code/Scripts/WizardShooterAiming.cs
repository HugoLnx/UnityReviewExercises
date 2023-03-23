using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationRigging
{
    public class WizardShooterAiming : MonoBehaviour
    {
        [SerializeField] private PositionRelativeToChild _positionable;
        [SerializeField] private Transform _aimHeightRef;
        public Transform AimHeightRef => _aimHeightRef;
        private IPositionable Positionable => _positionable;
        public float Height => _aimHeightRef.position.y;
        public Vector2 Origin => new Vector2(_aimHeightRef.position.x, _aimHeightRef.position.z);
        public Vector2 AimDirection {
            get => (new Vector2(Positionable.Position.x, Positionable.Position.z) - Origin).normalized;
            set {
                const float targetDistance = 3f;
                Vector2 absPosition = Origin + value * targetDistance;
                Positionable.Position = new Vector3(absPosition.x, Height, absPosition.y);
            }
        }
        public Vector3 AbsAim {
            get => Positionable.Position;
            set => Positionable.Position = value;
        }

        private void Awake()
        {
            _aimHeightRef.position = new Vector3(transform.position.x, Height, transform.position.z);
        }
    }
}