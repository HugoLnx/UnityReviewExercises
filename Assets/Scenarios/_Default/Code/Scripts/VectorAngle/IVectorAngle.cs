using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReviewVectorAngle
{
    public interface IVectorAngle
    {
        float SmallestAngleToVectorRightWithArccos(Vector2 vec);
        float VectorToFullAngleWithArccos(Vector2 vec);
        float Atan2UsingArctan(Vector2 vec);
        float VectorToFullAngleWithAtan2(Vector2 vec);
    }
}