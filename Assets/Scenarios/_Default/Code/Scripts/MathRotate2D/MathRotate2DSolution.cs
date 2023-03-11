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

        public void TransformRotate2DWithTransformDirectionVector(Transform t, float degreesClockwise)
        {
            Vector2 up2D = Rotate(t.up, -degreesClockwise);
            t.up = new Vector3(up2D.x, up2D.y, t.up.z);
        }

        public void TransformRotate2DWithQuaternion(Transform t, float degreesClockwise)
        {
            t.rotation *= Quaternion.AngleAxis(-degreesClockwise, Vector3.forward);
        }

        public void TransformRotate2DWithEulerAngles(Transform t, float degreesClockwise)
        {
            Vector3 rot = t.rotation.eulerAngles;
            t.rotation = Quaternion.Euler(rot.x, rot.y, rot.z - degreesClockwise);
        }
    }
}