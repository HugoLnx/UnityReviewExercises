using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationRigging
{
    public class WizardInput
    {
        private readonly WizardRawInputSolution.PlayerActions _player;

        public bool RunIsPressed => _player.Run.IsPressed();
        public Vector2 Axis => _player.Movement.ReadValue<Vector2>();
        public bool AxisIsPressed => _player.Movement.IsPressed();

        public WizardInput(WizardRawInputSolution.PlayerActions player)
        {
            _player = player;
        }

        public void Enable()
        {
            _player.Enable();
        }

        public static WizardInput Build() => new(new WizardRawInputSolution().Player);
    }
}