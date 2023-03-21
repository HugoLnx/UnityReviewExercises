using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationBlendTrees
{
    public class WizardInput
    {
        private readonly WizardRawInput.PlayerActions _player;

        public bool RunIsPressed => _player.Run.IsPressed();
        public Vector2 Axis => _player.Movement.ReadValue<Vector2>();
        public bool AxisIsPressed => _player.Movement.IsPressed();

        public WizardInput(WizardRawInput.PlayerActions player)
        {
            _player = player;
        }

        public void Enable()
        {
            _player.Enable();
        }

        public static WizardInput Build() => new(new WizardRawInput().Player);
    }
}