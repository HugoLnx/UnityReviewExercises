using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ReviewEvents
{
    public class Life
    {
        public enum DeathCause { NATURAL, MURDER, ACCIDENT }

        // 1. Implement OnBorn event with EventHandler receiving (Life father) and (Life mother) as arguments
        // 2. Implement OnGrown event with EventHandler receiving no arguments
        // 3. Implement OnReproduced event with Action receiving (Life partner) as argument
        // 4. Implement OnDied event with delegates receiving (DeathCause cause) as argument

        public void Live()
        {
            // 5. Call OnBorn event passing father and mother arguments
            // 6. Call OnGrown event passing no arguments
            // 7. Call OnReproduced event partner argument
            // 8. Call OnDied passing DeathCause argument
        }
    }
}