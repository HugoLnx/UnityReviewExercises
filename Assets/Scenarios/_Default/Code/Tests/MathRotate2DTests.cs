using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Math4GamedevRotate2D;
using UnityEngine.TestTools.Utils;

public class MathRotate2DTests
{
    private const float Precision = 0.1f;
    private static readonly Vector2 North = new(0f, 17f);
    private static readonly Vector2 South = new(0f, -5f);
    private static readonly Vector2 East = new(7f, 0f);
    private static readonly Vector2 West = new(-13f, 0f);
    private static readonly Vector2 Northeast = new(23f, 23f);
    private static readonly Vector2 Northwest = new(-29f, 29f);
    private static readonly Vector2 Southeast = new(37f, -37f);
    private static readonly Vector2 Southwest = new(-31f, -31f);
    private static readonly Vector2 NormNorth = new(0f, 1f);
    private static readonly Vector2 NormSouth = new(0f, -1f);
    private static readonly Vector2 NormEast = new(1f, 0f);
    private static readonly Vector2 NormWest = new(-1f, 0f);
    private static readonly Vector3 NormNorthV3 = NormNorth;
    private static readonly Vector3 NormSouthV3 = NormSouth;
    private static readonly Vector3 NormEastV3 = NormEast;
    private static readonly Vector3 NormWestV3 = NormWest;
    private static Vector2 NormNortheast => Northeast.normalized;
    private static Vector2 NormNorthwest => Northwest.normalized;
    private static Vector2 NormSoutheast => Southeast.normalized;
    private static Vector2 NormSouthwest => Southwest.normalized;
    // private static IMathRotate2D MathRotate2D => new MathRotate2D();
    private static IMathRotate2D MathRotate2D => new MathRotate2DSolution();
    private static readonly Vector2EqualityComparer V2Comparer = new(10e-3f);
    private static readonly Vector3EqualityComparer V3Comparer = new(10e-3f);

    
    [Test]
    public void Rotate2D_RotatesAVector()
    {

        Assert.That(MathRotate2D.Rotate(NormWest, -90f), Is.EqualTo(NormNorth).Using(V2Comparer));
        Assert.That(MathRotate2D.Rotate(NormEast, 90f), Is.EqualTo(NormNorth).Using(V2Comparer));
        Assert.That(MathRotate2D.Rotate(NormSouth, -180f), Is.EqualTo(NormNorth).Using(V2Comparer));
        Assert.That(MathRotate2D.Rotate(NormSouth, 180f), Is.EqualTo(NormNorth).Using(V2Comparer));
        Assert.That(MathRotate2D.Rotate(NormNorthwest, -45f), Is.EqualTo(NormNorth).Using(V2Comparer));
        Assert.That(MathRotate2D.Rotate(NormSouthwest, -135f), Is.EqualTo(NormNorth).Using(V2Comparer));
        Assert.That(MathRotate2D.Rotate(NormSouthwest, 225f), Is.EqualTo(NormNorth).Using(V2Comparer));
    }

    [Test]
    public void TransformRotate2D_WithTransformDirectionVector_RotatesATransform()
    {
        Transform t = new GameObject().transform;

        t.up = NormNorth;
        MathRotate2D.TransformRotate2DWithTransformDirectionVector(t, degreesClockwise: 90f);
        Assert.That(t.up, Is.EqualTo(NormEastV3).Using(V3Comparer));

        t.up = NormNorth;
        MathRotate2D.TransformRotate2DWithTransformDirectionVector(t, degreesClockwise: -90f);
        Assert.That(t.up, Is.EqualTo(NormWestV3).Using(V3Comparer));

        t.up = NormNorth;
        MathRotate2D.TransformRotate2DWithTransformDirectionVector(t, degreesClockwise: 180f);
        Assert.That(t.up, Is.EqualTo(NormSouthV3).Using(V3Comparer));
    }

    [Test]
    public void TransformRotate2D_WithQuaternion_RotatesATransform()
    {
        Transform t = new GameObject().transform;

        t.up = NormNorth;
        MathRotate2D.TransformRotate2DWithQuaternion(t, degreesClockwise: 90f);
        Assert.That(t.up, Is.EqualTo(NormEastV3).Using(V3Comparer));

        t.up = NormNorth;
        MathRotate2D.TransformRotate2DWithQuaternion(t, degreesClockwise: -90f);
        Assert.That(t.up, Is.EqualTo(NormWestV3).Using(V3Comparer));

        t.up = NormNorth;
        MathRotate2D.TransformRotate2DWithQuaternion(t, degreesClockwise: 180f);
        Assert.That(t.up, Is.EqualTo(NormSouthV3).Using(V3Comparer));
    }

    [Test]
    public void TransformRotate2D_WithEulerAngles_RotatesATransform()
    {
        Transform t = new GameObject().transform;

        t.up = NormNorth;
        MathRotate2D.TransformRotate2DWithEulerAngles(t, degreesClockwise: 90f);
        Assert.That(t.up, Is.EqualTo(NormEastV3).Using(V3Comparer));

        t.up = NormNorth;
        MathRotate2D.TransformRotate2DWithEulerAngles(t, degreesClockwise: -90f);
        Assert.That(t.up, Is.EqualTo(NormWestV3).Using(V3Comparer));

        t.up = NormNorth;
        MathRotate2D.TransformRotate2DWithEulerAngles(t, degreesClockwise: 180f);
        Assert.That(t.up, Is.EqualTo(NormSouthV3).Using(V3Comparer));
    }
}
