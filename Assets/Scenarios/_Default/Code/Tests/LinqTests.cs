using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.TestTools;
using ReviewLinq;

public class LinqTests
{
    private static readonly List<int> Numbers = new() {3, 4, 2, 5, 1, 3, 2};
    private static readonly List<int> OtherNumbers = new() {4, 1, 9, 3, 6, 0};
    // private static readonly Querier NumbersQuerier = new(Numbers);
    // private static readonly Querier OtherNumbersQuerier = new(OtherNumbers);
    // private static readonly Querier EmptyQuerier = new(new List<int>());
    private static readonly QuerierSolution NumbersQuerier = new(Numbers);
    private static readonly QuerierSolution OtherNumbersQuerier = new(OtherNumbers);
    private static readonly QuerierSolution EmptyQuerier = new(new List<int>());

    [Test]
    public void TestIsEmpty()
    {
        // Any as IsEmpty
        Assert.That(NumbersQuerier.IsEmpty(), Is.False);
        Assert.That(EmptyQuerier.IsEmpty(), Is.True);
    }


    [Test]
    public void TestIsAnyEven()
    {
        // Any
        Assert.That(NumbersQuerier.IsAnyEven(), Is.True);
    }

    [Test]
    public void TestIsAllEven()
    {
        Assert.That(NumbersQuerier.IsAllEven(), Is.False);
    }

    [Test]
    public void TestOneThatsHigherThan4()
    {
        Assert.That(NumbersQuerier.OneThatsHigherThan4(), Is.EqualTo(5));
        Assert.Throws<System.InvalidOperationException>(() => {
            OtherNumbersQuerier.OneThatsHigherThan4();
        });
    }

    [Test]
    public void TestMiddleX()
    {
        // Skip/Take
        Assert.That(NumbersQuerier.MiddleX(3), Is.EqualTo(new List<int>(){2, 5, 1}));
    }

    [Test]
    public void TestLastX()
    {
        // TakeLast
        Assert.That(NumbersQuerier.LastX(3), Is.EqualTo(new List<int>(){1, 3, 2}));
    }

    [Test]
    public void TestFirstSequenceOfEvens()
    {
        // SkipWhile/TakeWhile
        Assert.That(NumbersQuerier.FirstSequenceOfEvens(), Is.EqualTo(new List<int>(){4, 2}));
    }

    [Test]
    public void TestSortEvenFirstThenDescending()
    {
        // OrderBy / ThenBy
        Assert.That(NumbersQuerier.SortEvenFirstThenDescending(), Is.EqualTo(new List<int>(){4, 2, 2, 5, 3, 3, 1}));
    }

    [Test]
    public void TestUnique()
    {
        // Distinct
        Assert.That(NumbersQuerier.Unique(), Is.EqualTo(new List<int>(){3, 4, 2, 5, 1}));
    }

    [Test]
    public void TestUniqueCommonValuesWith()
    {
        // Intersect
        Assert.That(NumbersQuerier.UniqueCommonValuesWith(OtherNumbers), Is.EqualTo(new List<int>(){3, 4, 1}));
    }

    [Test]
    public void TestUniqueValuesExcludingOnesFrom()
    {
        // Except
        Assert.That(NumbersQuerier.UniqueValuesExcludingOnesFrom(OtherNumbers), Is.EqualTo(new List<int>(){2, 5}));
    }

    [Test]
    public void TestUniqueValuesIncludingOnesFrom()
    {
        // Union
        Assert.That(NumbersQuerier.UniqueValuesIncludingOnesFrom(OtherNumbers), Is.EqualTo(new List<int>(){3, 4, 2, 5, 1, 9, 6, 0}));
    }

    [Test]
    public void TestGroupByMod3()
    {
        // GroupBy / ToDictionary
        Assert.That(NumbersQuerier.GroupByMod3(), Is.EqualTo(new Dictionary<int, List<int>>(){
            {0, new List<int>(){3, 3}},
            {1, new List<int>(){4, 1}},
            {2, new List<int>(){2, 5, 2}},
        }));
    }

    [Test]
    public void TestSplitByMod3()
    {
        // GroupBy / OrderBy / Select / ToList
        Assert.That(NumbersQuerier.SplitByMod3(), Is.EqualTo(new List<List<int>>(){
            new List<int>(){3, 3},
            new List<int>(){4, 1},
            new List<int>(){2, 5, 2},
        }));
    }

    [Test]
    public void TestQuerySyntaxSplitByMod3()
    {
        // GroupBy / OrderBy / Select / ToList
        Assert.That(NumbersQuerier.QuerySyntaxSplitByMod3ExcludingZero(), Is.EqualTo(new List<List<int>>(){
            new List<int>(){4, 1},
            new List<int>(){2, 5, 2},
        }));
    }

    [Test]
    public void TestMultipliedBy2By3LessThan9()
    {
        // SelectMany / Where
        Assert.That(NumbersQuerier.MultipliedBy2By3LessThan9(), Is.EqualTo(new List<int>(){3, 6,  4, 8,  2, 4, 6,  5,  1, 2, 3,  3, 6,  2, 4, 6}));
    }

    [Test]
    public void TestMultiplyAll()
    {
        // Aggregate
        Assert.That(NumbersQuerier.MultiplyAll(), Is.EqualTo(3*4*2*5*1*3*2));
    }

    [Test]
    public void TestSumAllMod3()
    {
        // Sum
        Assert.That(NumbersQuerier.SumAllMod3(), Is.EqualTo(8));
    }

    [Test]
    public void TestAvgAllMod3()
    {
        // Average
        Assert.That(NumbersQuerier.AvgAllMod3(), Is.EqualTo(8f/5f).Within(10e-3f));
    }
}
