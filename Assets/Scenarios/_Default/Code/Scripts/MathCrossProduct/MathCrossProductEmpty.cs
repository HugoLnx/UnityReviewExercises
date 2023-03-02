using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Math4GamedevCrossProduct
{
    public class MathCrossProductEmpty : IMathCrossProduct
    {
        public Vector3 CrossProduct(Vector3 v1, Vector3 v2)
        {
            return Vector3.zero;
        }
        public bool IsClockWise(Vector3 from, Vector3 to)
        {
            return false;
        }
    }
}