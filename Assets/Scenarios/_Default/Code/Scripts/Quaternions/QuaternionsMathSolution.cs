using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuaternionsMath
{
    Quaternion Build(float angle, Vector3 axis);
    Quaternion Mult(Quaternion q1, Quaternion q2);
    float Dot(Quaternion q1, Quaternion q2);
    Quaternion Neg(Quaternion q1);
}

public class QuaternionsMathSolution : IQuaternionsMath
{
    public Quaternion Build(float angle, Vector3 axis)
    {
        float halfAngleRadians = angle / 2f * Mathf.Deg2Rad;
        float cos = Mathf.Cos(halfAngleRadians);
        float sin = Mathf.Sin(halfAngleRadians);
        return new Quaternion(
            axis.x * sin,
            axis.y * sin,
            axis.z * sin,
            cos
        );
    }

    public Quaternion Mult(Quaternion q1, Quaternion q2)
    {
        float w1 = q1.w;
        float w2 = q2.w;
        Vector3 v1 = new(q1.x, q1.y, q1.z);
        Vector3 v2 = new(q2.x, q2.y, q2.z);
        float w = w1 * w2 - Vector3.Dot(v1, v2);
        Vector3 v = w1 * v2 + w2 * v1 + Vector3.Cross(v1, v2);
        return new Quaternion(v.x, v.y, v.z, w);
    }

    public float Dot(Quaternion q1, Quaternion q2)
    {
        return (q1.w * q2.w) + (q1.x * q2.x) + (q1.y * q2.y) + (q1.z * q2.z);
    }

    public Quaternion Neg(Quaternion q)
    {
        return new Quaternion(-q.x, -q.y, -q.z, q.w);
    }
}