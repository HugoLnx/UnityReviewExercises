using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Math4GamedevRotate2D
{
    public interface IMathRotate2D
    {
        Vector2 Rotate(Vector2 v, float angle);
        void TransformRotate2D(Transform t, float degreesClockwise);
    }
}