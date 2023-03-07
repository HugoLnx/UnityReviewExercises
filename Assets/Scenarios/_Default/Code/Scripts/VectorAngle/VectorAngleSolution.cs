using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ReviewVectorAngle
{
    public class VectorAngleSolution : IVectorAngle
    {
        public float SmallestAngleToVectorRightWithArccos(Vector2 vec)
        {
            return Mathf.Acos(vec.x/vec.magnitude) * Mathf.Rad2Deg;
        }

        public float VectorToFullAngleWithArccos(Vector2 vec)
        {
            float angle = SmallestAngleToVectorRightWithArccos(vec);
            if (vec.y < 0f) angle = 360f - angle;
            return angle;
        }

        public float Atan2UsingArctan(Vector2 vec)
        {
            float atan = Mathf.Atan(vec.y/vec.x);
            float xModifier = vec.x < 0f ? 180f : 0f;
            float yModifier = Mathf.Sign(vec.y);
            return atan * Mathf.Rad2Deg + xModifier * yModifier;
        }

        public float VectorToFullAngleWithAtan2(Vector2 vec)
        {
            float atan2 = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            return atan2 < 0f ? 360f + atan2 : atan2;
        }
    }
}