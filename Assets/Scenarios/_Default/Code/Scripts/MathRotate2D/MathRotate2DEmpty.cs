using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Math4GamedevRotate2D
{
    public class MathRotate2DEmpty : IMathRotate2D
    {
        public Vector2 Rotate(Vector2 v, float angle)
        {
            return Vector2.zero;
        }

        public void TransformRotate2DWithTransformDirectionVector(Transform t, float degreesClockwise)
        {
        }

        public void TransformRotate2DWithQuaternion(Transform t, float degreesClockwise)
        {
        }

        public void TransformRotate2DWithEulerAngles(Transform t, float degreesClockwise)
        {
        }
    }
}