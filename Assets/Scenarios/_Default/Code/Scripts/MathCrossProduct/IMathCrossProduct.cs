using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Math4GamedevCrossProduct
{
    public interface IMathCrossProduct
    {
        Vector3 CrossProduct(Vector3 v1, Vector3 v2);
        bool IsClockWise(Vector3 from, Vector3 to);
    }
}