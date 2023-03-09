using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ReviewNewInputSystem
{
    public class PlayerControlsEmpty : MonoBehaviour
    {
        private Player _player;

        private void Awake()
        {
            _player = GetComponent<Player>();
            // TODO: Call _player.StartWalk(Vector2)
            // TODO: Call _player.StopWalk()
            // TODO: Call _player.Jump()
            // TODO: Call _player.AbortJumpRise()
            // TODO: Call _player.Dash()
        }
    }
}