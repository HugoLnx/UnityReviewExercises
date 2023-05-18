using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Utils;

public class QuaternionsMathTests
{
    private static IQuaternionsMath QMath = new QuaternionsMathSolution();
    // private static IQuaternionsMath QMath = new QuaternionsMath();
    private const bool LogOperations = false;
    private const float Precision = 1e-3f;
    private static readonly QuaternionEqualityComparer QuaternionComparer = new(Precision);

    private const string HighPrecisionFormat = "0.###";
    private const string LowPrecisionFormat = "0.##";

    [Test]
    public void Quaternion_Build()
    {
        var cases = new (float angle, Vector3 axis)[]
        {
            (30f, Vector3.one.normalized),
            (45f, new Vector3(1, 2, 3).normalized),
            (60f, new Vector3(7, 13, 11).normalized),
            (120f, new Vector3(37, 19, 5).normalized),
        };
        AssertQuaternionBuildIn(cases[0]);
        AssertQuaternionBuildIn(cases[1]);
        AssertQuaternionBuildIn(cases[2]);
        AssertQuaternionBuildIn(cases[3]);
    }

    [Test]
    public void Quaternion_Mult()
    {
        var cases = new (Quaternion q1, Quaternion q2)[]
        {
            (
                Quaternion.AngleAxis(30f, Vector3.one.normalized),
                Quaternion.AngleAxis(45f, new Vector3(1, 2, 3).normalized)
            ),
            (
                Quaternion.AngleAxis(60f, new Vector3(7, 13, 11).normalized),
                Quaternion.AngleAxis(90f, new Vector3(37, 19, 5).normalized)
            ),
            (
                Quaternion.AngleAxis(30f, new Vector3(5, 7, 11).normalized),
                Quaternion.AngleAxis(60f, new Vector3(1, 2, 3).normalized)
            ),
        };
        AssertQuaternionMultIn(cases[0]);
        AssertQuaternionMultIn(cases[1]);
        AssertQuaternionMultIn(cases[2]);
    }

    [Test]
    public void Quaternion_Dot()
    {
        var cases = new (Quaternion q1, Quaternion q2)[]
        {
            (
                Quaternion.AngleAxis(30f, Vector3.one.normalized),
                Quaternion.AngleAxis(45f, new Vector3(1, 2, 3).normalized)
            ),
            (
                Quaternion.AngleAxis(60f, new Vector3(7, 13, 11).normalized),
                Quaternion.AngleAxis(90f, new Vector3(37, 19, 5).normalized)
            ),
            (
                Quaternion.AngleAxis(30f, new Vector3(5, 7, 11).normalized),
                Quaternion.AngleAxis(60f, new Vector3(1, 2, 3).normalized)
            ),
        };
        AssertQuaternionDotIn(cases[0]);
        AssertQuaternionDotIn(cases[1]);
        AssertQuaternionDotIn(cases[2]);
    }

    [Test]
    public void Quaternion_Neg()
    {
        var cases = new Quaternion[]
        {
            Quaternion.AngleAxis(30f, Vector3.one.normalized),
            Quaternion.AngleAxis(45f, new Vector3(1, 2, 3).normalized),
            Quaternion.AngleAxis(60f, new Vector3(7, 13, 11).normalized)
        };
        AssertQuaternionNegIn(cases[0]);
        AssertQuaternionNegIn(cases[1]);
        AssertQuaternionNegIn(cases[2]);
    }

    private void AssertQuaternionBuildIn((float angle, Vector3 axis) c)
    {
        (float angle, Vector3 axis) = c;
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        Log($"BUILD: {AsStr(angle, highPrecision: true, name: "angle")} {AsStr(axis, highPrecision: true, name: "axis")} => {AsStr(q)}");
        Assert.That(
            q,
            Is.EqualTo(QMath.Build(angle, axis)).Using(QuaternionComparer)
        );
    }

    private void AssertQuaternionMultIn((Quaternion q1, Quaternion q2) v)
    {
        (Quaternion q1, Quaternion q2) = v;
        Quaternion q = q1 * q2;
        Log($"MULT: {AsStr(q1, highPrecision: true)} * {AsStr(q2, highPrecision: true)} = {AsStr(q)}");
        Assert.That(
            q,
            Is.EqualTo(QMath.Mult(q1, q2)).Using(QuaternionComparer)
        );
    }

    private void AssertQuaternionDotIn((Quaternion q1, Quaternion q2) v)
    {
        (Quaternion q1, Quaternion q2) = v;
        float dot = Quaternion.Dot(q1, q2);
        Log($"DOT: {AsStr(q1, highPrecision: true)} . {AsStr(q2, highPrecision: true)} = {AsStr(dot)}");
        Assert.That(
            dot,
            Is.EqualTo(QMath.Dot(q1, q2)).Within(Precision)
        );
    }

    private void AssertQuaternionNegIn(Quaternion q)
    {
        Quaternion qNeg = Quaternion.Inverse(q);
        Log($"NEG: {AsStr(q)} = {AsStr(qNeg)}");
        Assert.That(
            qNeg,
            Is.EqualTo(QMath.Neg(q)).Using(QuaternionComparer)
        );
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
