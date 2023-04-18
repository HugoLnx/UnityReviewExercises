using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ReviewLinq
{
    public class Querier
    {
        private readonly List<int> _list;

        public Querier(List<int> list)
        {
            _list = list;
        }

        public bool IsEmpty()
        {
            return false;
        }

        public bool IsAnyEven()
        {
            return false;
        }

        public bool IsAllEven()
        {
            return false;
        }

        public int OneThatsHigherThan4()
        {
            return 0;
        }

        public List<int> MiddleX(int amount)
        {
            return _list;
        }

        public List<int> LastX(int amount)
        {
            return _list;
        }

        public List<int> FirstSequenceOfEvens()
        {
            return _list;
        }

        public List<int> SortEvenFirstThenDescending()
        {
            return _list;
        }

        public List<int> Unique()
        {
            return _list;
        }

        public List<int> UniqueCommonValuesWith(List<int> otherNumbers)
        {
            return _list;
        }

        public List<int> UniqueValuesExcludingOnesFrom(List<int> otherNumbers)
        {
            return _list;
        }

        public List<int> UniqueValuesIncludingOnesFrom(List<int> otherNumbers)
        {
            return _list;
        }

        public Dictionary<int, List<int>> GroupByMod3()
        {
            return new Dictionary<int, List<int>>();
        }

        public List<List<int>> SplitByMod3()
        {
            return new List<List<int>>();
        }

        public List<List<int>> QuerySyntaxSplitByMod3ExcludingZero()
        {
            return new List<List<int>>();
        }

        public List<int> MultipliedBy1By2By3LessThan9()
        {
            return _list;
        }

        public int MultiplyAll()
        {
            return 0;
        }

        public int SumAllMod3()
        {
            return 0;
        }

        public float AvgAllMod3()
        {
            return 0;
        }
    }
}