using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ReviewEvents
{
    public class LifeSolution
    {
        public class BornEventArgs : EventArgs
        {
            public Life Father {get; set;}
            public Life Mother {get; set;}
        }

        // With Event Handler
        public event EventHandler<BornEventArgs> OnBorn;
        public event EventHandler OnGrown;

        // With Action
        public event Action<LifeSolution, Life> OnReproduced;

        // With Delegates
        public delegate void Died(LifeSolution sender, Life.DeathCause cause);
        public event Died OnDied;

        public void Live()
        {
            OnBorn?.Invoke(this, new BornEventArgs{Father=new Life(), Mother=new Life()});
            OnGrown?.Invoke(this, EventArgs.Empty);
            OnReproduced?.Invoke(this, new Life());
            OnDied?.Invoke(this, Life.DeathCause.NATURAL);
        }
    }
}