using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReviewDelegates
{
    public class FilterSolution<T>
    {
        public delegate bool Predicate(T val);
        public IEnumerable<T> FindAll(IEnumerable<T> values, Predicate predicate)
        {
            foreach (T val in values)
            {
                if (predicate(val)) yield return val;
            }
        }
    }
}