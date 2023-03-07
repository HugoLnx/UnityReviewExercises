using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ReviewVectorAngle;

public class VectorAngleTests
{
    private const float Precision = 10e-2f;
    // public IVectorAngle VectorAngle => new VectorAngle();
    public IVectorAngle VectorAngle => new VectorAngleSolution();
    [Test]
    public void SmallestAngleToVectorRightWithArccos_ReturnsAngleBetween0And180()
    {
        Assert.That(
            VectorAngle.SmallestAngleToVectorRightWithArccos(new Vector2(2f, -5f)),
            Is.EqualTo(68.2f).Within(Precision)
        );
        Assert.That(
            VectorAngle.SmallestAngleToVectorRightWithArccos(new Vector2(-1f, 7f)),
            Is.EqualTo(98.13f).Within(Precision)
        );
        Assert.That(
            VectorAngle.SmallestAngleToVectorRightWithArccos(new Vector2(-3f, -2f)),
            Is.EqualTo(146.31f).Within(Precision)
        );
        Assert.That(
            VectorAngle.SmallestAngleToVectorRightWithArccos(new Vector2(9f, 4f)),
            Is.EqualTo(23.96f).Within(Precision)
        );
    }

    [Test]
    public void VectorToFullAngleWithArccos_ReturnsAngleBetween0And360()
    {
        Assert.That(
            VectorAngle.VectorToFullAngleWithArccos(new Vector2(2f, -5f)),
            Is.EqualTo(291.8f).Within(Precision)
        );
        Assert.That(
            VectorAngle.VectorToFullAngleWithArccos(new Vector2(-1f, 7f)),
            Is.EqualTo(98.13f).Within(Precision)
        );
        Assert.That(
            VectorAngle.VectorToFullAngleWithArccos(new Vector2(-3f, -2f)),
            Is.EqualTo(213.69f).Within(Precision)
        );
        Assert.That(
            VectorAngle.VectorToFullAngleWithArccos(new Vector2(9f, 4f)),
            Is.EqualTo(23.96f).Within(Precision)
        );
    }

    [Test]
    public void Atan2UsingArctan_ReturnsAngleBetweenNegative180AndPositive180()
    {
        Assert.That(
            VectorAngle.Atan2UsingArctan(new Vector2(2f, -5f)),
            Is.EqualTo(-68.2f).Within(Precision)
        );
        Assert.That(
            VectorAngle.Atan2UsingArctan(new Vector2(-1f, 7f)),
            Is.EqualTo(98.13f).Within(Precision)
        );
        Assert.That(
            VectorAngle.Atan2UsingArctan(new Vector2(-3f, -2f)),
            Is.EqualTo(-146.31f).Within(Precision)
        );
        Assert.That(
            VectorAngle.Atan2UsingArctan(new Vector2(9f, 4f)),
            Is.EqualTo(23.96f).Within(Precision)
        );
    }

    [Test]
    public void VectorToFullAngleWithAtan2_ReturnsAngleBetween0And360()
    {
        Assert.That(
            VectorAngle.VectorToFullAngleWithAtan2(new Vector2(2f, -5f)),
            Is.EqualTo(291.8f).Within(Precision)
        );
        Assert.That(
            VectorAngle.VectorToFullAngleWithAtan2(new Vector2(-1f, 7f)),
            Is.EqualTo(98.13f).Within(Precision)
        );
        Assert.That(
            VectorAngle.VectorToFullAngleWithAtan2(new Vector2(-3f, -2f)),
            Is.EqualTo(213.69f).Within(Precision)
        );
        Assert.That(
            VectorAngle.VectorToFullAngleWithAtan2(new Vector2(9f, 4f)),
            Is.EqualTo(23.96f).Within(Precision)
        );
    }
}
