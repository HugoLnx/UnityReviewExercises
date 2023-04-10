using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Math4GamedevCrossProduct;
using UnityEngine.TestTools.Utils;

public class MathCrossProductTests
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
    private static Vector2 NormNortheast => Northeast.normalized;
    private static Vector2 NormNorthwest => Northwest.normalized;
    private static Vector2 NormSoutheast => Southeast.normalized;
    private static Vector2 NormSouthwest => Southwest.normalized;
    // private static IMathCrossProduct MathCrossProduct => new MathCrossProduct();
    private static IMathCrossProduct MathCrossProduct => new MathCrossProductSolution();
    private static readonly Vector3EqualityComparer V3Comparer = new(10e-3f);


    [Test]
    [Category("Cross Product")]
    public void TestCross()
    {
        Assert.That(MathCrossProduct.CrossProduct(new Vector3(0f, 17f, 0f), new Vector3(7f, 0f, 0f)), Is.EqualTo(new Vector3(0f, 0f, -119f)).Using(V3Comparer));
        Assert.That(MathCrossProduct.CrossProduct(new Vector3(7f, 0f, 0f), new Vector3(0f, 17f, 0f)), Is.EqualTo(new Vector3(0f, 0f, 119f)).Using(V3Comparer));
        Assert.That(MathCrossProduct.CrossProduct(new Vector3(0f, 0f, 17f), new Vector3(7f, 0f, 0f)), Is.EqualTo(new Vector3(0f, 119f, 0f)).Using(V3Comparer));
        Assert.That(MathCrossProduct.CrossProduct(new Vector3(7f, 0f, 0f), new Vector3(0f, 0f, 17f)), Is.EqualTo(new Vector3(0f, -119f, 0f)).Using(V3Comparer));
        Assert.That(MathCrossProduct.CrossProduct(new Vector3(0f, 17f, 0f), new Vector3(0f, 0f, 7f)), Is.EqualTo(new Vector3(119f, 0f, 0f)).Using(V3Comparer));
        Assert.That(MathCrossProduct.CrossProduct(new Vector3(0f, 0f, 17f), new Vector3(0f, 7f, 0f)), Is.EqualTo(new Vector3(-119f, 0f, 0f)).Using(V3Comparer));
        Assert.That(MathCrossProduct.CrossProduct(new Vector3(7f, 0f, 0f), new Vector3(17f, 0f, 0f)), Is.EqualTo(new Vector3(0f, 0f, 0f)).Using(V3Comparer));
        Assert.That(MathCrossProduct.CrossProduct(new Vector3(7f, 0f, 0f), new Vector3(-17f, 0f, 0f)), Is.EqualTo(new Vector3(0f, 0f, 0f)).Using(V3Comparer));
    }

    [Test]
    [Category("IsClockwise")]
    public void TestIsClockwise()
    {
        Assert.True(MathCrossProduct.IsClockWise(from: North, to: Northeast));
        Assert.False(MathCrossProduct.IsClockWise(from: Northeast, to: North));
        Assert.True(MathCrossProduct.IsClockWise(from: North, to: South));
        Assert.False(MathCrossProduct.IsClockWise(from: North, to: Northwest));
        Assert.True(MathCrossProduct.IsClockWise(from: East, to: Southeast));
        Assert.True(MathCrossProduct.IsClockWise(from: Southwest, to: Northwest));
    }
}