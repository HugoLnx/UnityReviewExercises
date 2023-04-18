using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ReviewLinq
{
    public class QuerierSolution
    {
        private readonly List<int> _list;

        public QuerierSolution(List<int> list)
        {
            _list = list;
        }

        public bool IsEmpty()
        {
            return !_list.Any();
        }

        public bool IsAnyEven()
        {
            return _list.Any(n => n % 2 == 0);
        }

        public bool IsAllEven()
        {
            return _list.All(n => n % 2 == 0);
        }

        public int OneThatsHigherThan4()
        {
            return _list
                .Where(n => n > 4)
                .Single();
        }

        public List<int> MiddleX(int amount)
        {
            return _list
                .Skip((_list.Count-amount)/2)
                .Take(amount)
                .ToList();
        }

        public List<int> LastX(int amount)
        {
            return _list
                .TakeLast(amount)
                .ToList();
        }

        public List<int> FirstSequenceOfEvens()
        {
            return _list
                .SkipWhile(n => n % 2 != 0)
                .TakeWhile(n => n % 2 == 0)
                .ToList();
        }

        public List<int> SortEvenFirstThenDescending()
        {
            return _list
                .OrderBy(n => n % 2)
                .ThenByDescending(n => n)
                .ToList();
        }

        public List<int> Unique()
        {
            return _list
                .Distinct()
                .ToList();
        }

        public List<int> UniqueCommonValuesWith(List<int> otherNumbers)
        {
            return _list
                .Intersect(otherNumbers)
                .ToList();
        }

        public List<int> UniqueValuesExcludingOnesFrom(List<int> otherNumbers)
        {
            return _list
                .Except(otherNumbers)
                .ToList();
        }

        public List<int> UniqueValuesIncludingOnesFrom(List<int> otherNumbers)
        {
            return _list
                .Union(otherNumbers)
                .ToList();
        }

        public Dictionary<int, List<int>> GroupByMod3()
        {
            return _list
                .GroupBy(n => n % 3)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<List<int>> SplitByMod3()
        {
            return _list
                .GroupBy(n => n % 3)
                .OrderBy(g => g.Key)
                .Select(g => g.ToList())
                .ToList();
        }

        public List<List<int>> QuerySyntaxSplitByMod3ExcludingZero()
        {
            return (
                from n in _list
                group n by n % 3 into gn
                where gn.Key > 0
                orderby gn.Key
                select gn.ToList()
            ).ToList();
        }

        public List<int> MultipliedBy1By2By3LessThan9()
        {
            return _list
                .SelectMany(n => new int[]{n, n*2, n*3})
                .Where(n => n < 9)
                .ToList();
        }

        public int MultiplyAll()
        {
            return _list.Aggregate(1, (acc, n) => acc *= n);
        }

        public int SumAllMod3()
        {
            return _list
                .Select(n => n % 3)
                .Sum();
        }

        public float AvgAllMod3()
        {
            return _list
                .Select(n => n % 3f)
                .Where(n => n > 0)
                .Average();
        }
    }
}