using UnityEngine;

namespace AnimationRigging
{
    public interface IWizardShooterInput
    {
        Vector3 AimPosition {get;}
        bool ShootIsPressed {get;}
        bool ToggleShooterWasPerformed {get;}
    }
}