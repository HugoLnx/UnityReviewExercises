using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


namespace AnimationRigging
{
    public class AimTarget : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _targetDistance;
        [SerializeField] private bool _aiming3D;
        public Transform Origin => transform;
        public Vector2 OriginPosition2D => ToXZ(Origin.position);
        public float Height => Origin.position.y;
        public Vector2 OriginDirection {
            get => Origin.forward;
            set => Origin.forward = FromXZ(value);
        }

        public Vector3 TargetPosition {
            get => _target.position;
            set {
                OriginDirection = ToXZ(value - Origin.position);
                _target.position = value;
            }
        }

        private void Awake()
        {
            ResetTarget();
        }

        [Button]
        private void ResetTarget()
        {
            TargetPosition = Origin.position + Vector3.forward * _targetDistance;
        }

        public void AimTo(Vector3 position)
        {
            if (_aiming3D)
            {
                TargetPosition = position;
            }
            else
            {
                OriginDirection = ToXZ(position) - OriginPosition2D;
            }
        }

        private Vector2 ToXZ(Vector3 v) => new(v.x, v.z);
        private Vector3 FromXZ(Vector2 v) => new(v.x, 0f, v.y);
    }
}