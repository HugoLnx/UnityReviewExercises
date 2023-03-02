using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Math4GamedevRotate2D
{
    public class MathRotate2DSolution : IMathRotate2D
    {
        public Vector2 Rotate(Vector2 v, float angle)
        {
            float radians = angle * Mathf.Deg2Rad;
            float cos = Mathf.Cos(radians);
            float sin = Mathf.Sin(radians);
            float x = (v.x * cos) - (v.y * sin);
            float y = (v.x * sin) + (v.y * cos);
            return new Vector2(x, y);
        }

        public void TransformRotate2D(Transform t, float degreesClockwise)
        {
            float radiansAnticlockwise = -Mathf.Deg2Rad * degreesClockwise;
            Vector3 p = t.up;
            float x = p.x * Mathf.Cos(radiansAnticlockwise) - p.y * Mathf.Sin(radiansAnticlockwise);
            float y = p.x * Mathf.Sin(radiansAnticlockwise) + p.y * Mathf.Cos(radiansAnticlockwise);
            t.up = new Vector3(x, y, p.z);
        }
    }
}