using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationRigging
{
    public class WizardMovement : MonoBehaviour
    {
        [SerializeField] private float _acceleration;
        [SerializeField] private float _deacceleration;
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _runSpeedAdd;
        [SerializeField] private float _turnSpeed;
        [SerializeField] private bool _smoothMovementTurn;
        private float _targetSpeed;
        private Vector2 _targetDirection;

        public Vector2 MovementDirection { get; private set; } = Vector2.up;
        public Vector2 Direction { get; private set; } = Vector2.up;
        public float Speed { get; private set; }
        public float NormalizedSpeed =>
                Mathf.InverseLerp(0f, _walkSpeed, Speed)
                + Mathf.InverseLerp(_walkSpeed, RunSpeed, Speed);
        private float RunSpeed => _walkSpeed + _runSpeedAdd;

        private void Update()
        {
            UpdateSpeed(Time.deltaTime);
            UpdateDirection(Time.deltaTime);
            ApplyMovement(Time.deltaTime);
        }

        private void ApplyMovement(float deltaTime)
        {
            this.transform.position += new Vector3(MovementDirection.x, 0f, MovementDirection.y) * Speed * deltaTime;
        }

        private void UpdateDirection(float deltaTime)
        {
            float toTarget = Vector2.SignedAngle(Direction, _targetDirection);
            float step = Mathf.Sign(toTarget) * _turnSpeed * deltaTime;
            if (Mathf.Abs(step) >= Mathf.Abs(toTarget))
            {
                Direction = _targetDirection;
            }
            else
            {
                Direction = Quaternion.AngleAxis(step, Vector3.forward) * Direction;
            }
            if (_smoothMovementTurn)
            {
                MovementDirection = Direction;
            }
            else
            {
                MovementDirection = _targetDirection;
            }
        }

        private void UpdateSpeed(float deltaTime)
        {
            float toTarget = _targetSpeed - Speed;
            bool isAccelerating = toTarget > 0f;
            float speedStep = (isAccelerating ? _acceleration : -_deacceleration) * deltaTime;
            if (Mathf.Abs(speedStep) >= Mathf.Abs(toTarget))
            {
                Speed = _targetSpeed;
            }
            else
            {
                Speed += speedStep;
            }
        }

        public void HeadTo(Vector2 direction)
        {
            _targetDirection = direction.normalized;
        }

        public void Run()
        {
            _targetSpeed = RunSpeed;
        }

        public void Walk()
        {
            _targetSpeed = _walkSpeed;
        }

        public void Stop()
        {
            _targetSpeed = 0f;
        }
    }
}