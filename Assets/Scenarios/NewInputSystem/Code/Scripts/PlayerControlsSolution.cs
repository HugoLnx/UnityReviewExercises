using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ReviewNewInputSystem
{
    public class PlayerControlsSolution : MonoBehaviour
    {
        private Player _player;
        private PlayerInputActionsSolution _input;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _input = new PlayerInputActionsSolution();
            _input.Player.Enable();
            // _input.Player.Jump.performed += OnJump;
            // _input.Player.Jump.canceled += OnAbortJumpRise;
            _input.Player.Dash.performed += OnDash;
            _input.Player.Walk.performed += OnWalk;
            _input.Player.Walk.canceled += OnStopWalk;
        }

        private void Update()
        {
            if (Keyboard.current.spaceKey.IsPressed())
            {
                _player.Jump();
            } else {
                _player.AbortJumpRise();
            }
        }

        private void OnWalk(InputAction.CallbackContext obj)
        {
            Vector2 walkDirection = _input.Player.Walk.ReadValue<Vector2>();
            _player.StartWalk(walkDirection);
        }

        private void OnStopWalk(InputAction.CallbackContext obj)
        {
            _player.StopWalk();
        }

        private void OnJump(InputAction.CallbackContext obj)
        {
            _player.Jump();
        }

        private void OnAbortJumpRise(InputAction.CallbackContext obj)
        {
            _player.AbortJumpRise();
        }

        private void OnDash(InputAction.CallbackContext obj)
        {
            _player.Dash();
        }
    }
}