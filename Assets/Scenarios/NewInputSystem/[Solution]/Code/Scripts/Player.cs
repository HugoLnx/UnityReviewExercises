using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReviewNewInputSystem
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _jumpImpulseForce;
        [SerializeField] private float _jumpRiseForce;
        [SerializeField] private float _jumpRiseMaxDuration;
        [SerializeField] private float _dashSpeed;
        [SerializeField] private float _dashDuration;
        private Rigidbody _rigid;
        private bool _isGrounded;
        private bool _jumpRising;
        private Vector2 _dashDirection;
        private Vector2 _currentDirection;
        private Vector2 _walkDirection;
        private bool _isWalking;
        private bool _walkPaused;

        private bool IsDashing => _dashDirection != Vector2.zero;

        private void Awake()
        {
            _currentDirection = Vector2.up;
            _rigid = GetComponent<Rigidbody>();
            StartCoroutine(ConditionMonitor(
                condition: (_) => _jumpRising,
                onStay: (deltaTime) => {
                    _rigid.AddForce(Vector3.up * _jumpRiseForce * deltaTime, ForceMode.VelocityChange);
                },
                onTimeout: (_) => _jumpRising = false,
                timeout: _jumpRiseMaxDuration,
                waitInstruction: new WaitForEndOfFrame(),
                getDeltaTime: () => Time.deltaTime
            ));
            StartCoroutine(ConditionMonitor(
                condition: (_) => IsDashing,
                onStay: (deltaTime) => {
                    // Debug.Log($"[Dashing] {deltaTime}");
                    _rigid.velocity = new Vector3(_rigid.velocity.x, _rigid.velocity.y, 0f);
                    Vector2 movement = _dashSpeed * deltaTime * _dashDirection;
                    _rigid.MovePosition(_rigid.position + new Vector3(movement.x, 0f, movement.y));
                },
                onTimeout: (_) => {
                    _dashDirection = Vector2.zero;
                    ResumeWalk();
                },
                timeout: _dashDuration,
                timeoutOnlyWhenTrue: false,
                waitInstruction: new WaitForEndOfFrame(),
                getDeltaTime: () => Time.deltaTime
                //debug: true
            ));

            StartCoroutine(ConditionMonitor(
                condition: (_) => _isWalking,
                onStay: (deltaTime) => {
                    Vector2 movement = _walkSpeed * deltaTime * _currentDirection;
                    _rigid.MovePosition(_rigid.position + new Vector3(movement.x, 0f, movement.y));
                },
                waitInstruction: new WaitForEndOfFrame(),
                getDeltaTime: () => Time.deltaTime
            ));
        }

        public void StartWalk(Vector2 direction)
        {
            _walkDirection = direction;
            _isWalking = true;
            if (!_walkPaused) {
                _currentDirection = _walkDirection;
            }
        }

        public void StopWalk()
        {
            _isWalking = false;
        }

        private void PauseWalk()
        {
            _walkPaused = true;
        }

        private void ResumeWalk()
        {
            _walkPaused = false;
            if (_isWalking) {
                _currentDirection = _walkDirection;
            }
        }

        public void Jump()
        {
            if (!_isGrounded || _jumpRising) return;
            _rigid.AddForce(Vector3.up * _jumpImpulseForce, ForceMode.VelocityChange);
            _jumpRising = true;
        }

        public void AbortJumpRise()
        {
            _jumpRising = false;
        }

        public void Dash(Vector2? direction = null)
        {
            if (IsDashing) return;
            PauseWalk();
            AbortJumpRise();
            _dashDirection = direction.GetValueOrDefault(_currentDirection);
            _currentDirection = _dashDirection;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Ground")) {
                _isGrounded = true;
            }
        }
        private void OnCollisionStay(Collision other)
        {
            if (other.collider.CompareTag("Ground")) {
                _isGrounded = true;
            }
        }
        private void OnCollisionExit(Collision other)
        {
            if (other.collider.CompareTag("Ground")) {
                _isGrounded = false;
            }
        }

        private IEnumerator ConditionMonitor(Func<float, bool> condition,
        Action<float> onEnter = null, Action<float> onStay = null, Action<float> onExit = null,
        float timeout = -1f, Func<float> getDeltaTime = null, Action<float> onTimeout = null,
        bool timeoutOnlyWhenTrue = true, YieldInstruction waitInstruction = null, bool debug = false)
        {
            waitInstruction ??= new WaitForEndOfFrame();
            bool hasTimeout = timeout > 0f;
            if (hasTimeout)
            {
                getDeltaTime ??= AutoGetDeltaTimeFor(waitInstruction);
                if (getDeltaTime == null)
                {
                    throw new ConditionMonitorWithTimeoutNeedIncrement();
                }
            }

            bool wasTrue = false;
            bool timeoutHasBlown = false;
            float elapsed = 0f;
            while (true)
            {
                yield return waitInstruction;
                float deltaTime = getDeltaTime?.Invoke() ?? 0f;
                bool isTrue = condition.Invoke(deltaTime);

                if (timeoutHasBlown)
                {
                    if (debug) Debug.Log($"[{Time.time}] TimeoutHasBlown isTrue={isTrue}");
                    if (isTrue)
                    {
                        continue;
                    }
                    else
                    {
                        wasTrue = false;
                        timeoutHasBlown = false;
                    }
                }
                else if (hasTimeout && elapsed > timeout && elapsed != Mathf.Infinity)
                {
                    if (debug) Debug.Log($"[{Time.time}] Timing Out NOW wasTrue={wasTrue}");
                    onExit?.Invoke(deltaTime);
                    onTimeout?.Invoke(deltaTime);
                    elapsed = Mathf.Infinity;
                    if (wasTrue)
                    {
                        timeoutHasBlown = true;
                        continue;
                    }
                }

                if (isTrue)
                {
                    if (debug) Debug.Log($"[{Time.time}] OnCondition wasTrue={wasTrue}");
                    if (wasTrue)
                    {
                        onStay?.Invoke(deltaTime);
                    }
                    else
                    {
                        elapsed = 0f;
                        timeoutHasBlown = false;
                        wasTrue = true;
                        onEnter?.Invoke(deltaTime);
                        onStay?.Invoke(deltaTime);
                    }
                }
                else
                {
                    if (wasTrue)
                    {
                        if (debug) Debug.Log($"[{Time.time}] OnExit");
                        onExit?.Invoke(deltaTime);
                        wasTrue = false;
                    }
                }
                if (timeoutOnlyWhenTrue && !isTrue)
                {
                    elapsed = 0f;
                }
                else if (hasTimeout && !timeoutHasBlown)
                {
                    elapsed += deltaTime;
                }
            }
        }

        private Func<float> AutoGetDeltaTimeFor(YieldInstruction waitInstruction)
        {
            if (waitInstruction is WaitForEndOfFrame)
            {
                return () => Time.deltaTime;
            }
            else if (waitInstruction is WaitForFixedUpdate)
            {
                return () => Time.fixedDeltaTime;
            }
            return null;
        }
    }
}