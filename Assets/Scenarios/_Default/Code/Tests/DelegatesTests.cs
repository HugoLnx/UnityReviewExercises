using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using ReviewDelegates;

public class DelegatesTests
{
    // public Filter<int> Filter => new();
    public FilterSolution<int> Filter => new();

    [Test]
    public void Test_Filter()
    {
        List<int> numbers = new(){1, 10, 3, 5, 7};
        IEnumerable<int> filtered = Filter.FindAll(numbers, IsEven);
        Assert.That(filtered.Single(), Is.EqualTo(10));
    }

    public static bool IsEven(int n) => n % 2 == 0;
}