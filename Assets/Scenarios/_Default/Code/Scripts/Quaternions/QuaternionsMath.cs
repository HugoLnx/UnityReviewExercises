
using UnityEngine;

public class QuaternionsMath : IQuaternionsMath
{
    public Quaternion Build(float angle, Vector3 axis)
    {
        return Quaternion.identity;
    }

    public float Dot(Quaternion q1, Quaternion q2)
    {
        return 0f;
    }

    public Quaternion Mult(Quaternion q1, Quaternion q2)
    {
        return Quaternion.identity;
    }

    public Quaternion Neg(Quaternion q1)
    {
        return Quaternion.identity;
    }
}
