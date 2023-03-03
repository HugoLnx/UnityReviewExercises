using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReviewDelegates
{
    public class FilterSolution<T>
    {
        public delegate bool Predicate(T number);
        public IEnumerable<T> FindAll(IEnumerable<T> numbers, Predicate predicate)
        {
            foreach (T n in numbers)
            {
                if (predicate(n)) yield return n;
            }
        }
    }
}