using System.Collections;
using System.Collections.Generic;
using System.Text;
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
    private const bool LogOperations = false;
    private const string HighPrecisionFormat = "0.###";
    private const string LowPrecisionFormat = "0.##";

    public Quaternion Build(float angle, Vector3 axis)
    {
        float halfAngleRadians = angle / 2f * Mathf.Deg2Rad;
        float cos = Mathf.Cos(halfAngleRadians);
        float sin = Mathf.Sin(halfAngleRadians);
        Quaternion q = new(
            axis.x * sin,
            axis.y * sin,
            axis.z * sin,
            cos
        );

        Log($"BUILD: {AsStr(angle, highPrecision: true, name: "angle")} {AsStr(axis, highPrecision: true, name: "axis")} => {AsStr(q)}");
        return q;
    }

    public Quaternion Mult(Quaternion q1, Quaternion q2)
    {
        float w1 = q1.w;
        float w2 = q2.w;
        Vector3 v1 = new(q1.x, q1.y, q1.z);
        Vector3 v2 = new(q2.x, q2.y, q2.z);
        float w1MultW2 = w1 * w2;
        float v1DotV2 = Vector3.Dot(v1, v2);
        float w = w1MultW2 - v1DotV2;

        Vector3 w1MultV2 = w1 * v2;
        Vector3 w2MultV1 = w2 * v1;
        Vector3 v1CrossV2 = Vector3.Cross(v1, v2);
        Vector3 v = w1MultV2 + w2MultV1 + v1CrossV2;
        Quaternion q = new(v.x, v.y, v.z, w);
        StringBuilder strBuilder = new();
        Log(strBuilder
            .Append($"MULT: {AsStr(q1, highPrecision: true)} * {AsStr(q2, highPrecision: true)} = {AsStr(q)}")
            .Append("\nDATA: ")
            .Append(AsStr(w1MultW2, highPrecision:true, name: "w1 * w2"))
            .Append(" ")
            .Append(AsStr(v1DotV2, highPrecision:true, name: "v1 dot v2"))
            .Append(" ")
            .Append(AsStr(w1MultV2, highPrecision:true, name: "w1 * v2"))
            .Append(" ")
            .Append(AsStr(w2MultV1, highPrecision:true, name: "w2 * v1"))
            .Append(" ")
            .Append(AsStr(v1CrossV2, highPrecision:true, name: "v1 x v2"))
            .ToString());

        return q;
    }

    public float Dot(Quaternion q1, Quaternion q2)
    {
        float dot = (q1.w * q2.w) + (q1.x * q2.x) + (q1.y * q2.y) + (q1.z * q2.z);
        Log($"DOT: {AsStr(q1, highPrecision: true)} . {AsStr(q2, highPrecision: true)} = {AsStr(dot)}");
        return dot;
    }

    public Quaternion Neg(Quaternion qIn)
    {
        Quaternion qNeg = new(-qIn.x, -qIn.y, -qIn.z, qIn.w);
        Log($"NEG: {AsStr(qIn)} = {AsStr(qNeg)}");
        return qNeg;
    }

    private string AsStr(Quaternion q, bool highPrecision = false, string name = "quat")
    {
        string numFormat = highPrecision ? HighPrecisionFormat : LowPrecisionFormat;
        string format = $"[{name}|x:{{0:{numFormat}}} y:{{1:{numFormat}}} z:{{2:{numFormat}}} w:{{3:{numFormat}}}]";
        return string.Format(format, q.x, q.y, q.z, q.w);
    }

    private string AsStr(Vector3 v, bool highPrecision = false, string name = "vec3")
    {
        string numFormat = highPrecision ? HighPrecisionFormat : LowPrecisionFormat;
        string format = $"[{name}|x:{{0:{numFormat}}} y:{{1:{numFormat}}} z:{{2:{numFormat}}}]";
        return string.Format(format, v.x, v.y, v.z);
    }

    private string AsStr(float v, bool highPrecision = false, string name = "float")
    {
        string numFormat = highPrecision ? HighPrecisionFormat : LowPrecisionFormat;
        string format = $"[{name}|{{0:{numFormat}}}]";
        return string.Format(format, v);
    }

    private void Log(string str)
    {
        if (LogOperations)
        {
            Debug.Log(str);
        }
    }
}