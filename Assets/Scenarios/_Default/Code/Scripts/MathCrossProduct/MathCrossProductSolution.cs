using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Math4GamedevCrossProduct
{
    public class MathCrossProductSolution : IMathCrossProduct
    {
        public Vector3 CrossProduct(Vector3 v1, Vector3 v2)
        {
            return new Vector3(
                x: v1.y * v2.z - v1.z * v2.y,
                y: v1.z * v2.x - v1.x * v2.z,
                z: v1.x * v2.y - v1.y * v2.x
            );
        }
        public bool IsClockWise(Vector3 from, Vector3 to)
        {
            return CrossProduct(from, to).z < 0f;
        }
    }
}