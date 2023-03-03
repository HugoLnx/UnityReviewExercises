using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReviewDelegates
{
    public class FilterEmpty<T>
    {
        // Make a delegates for parameter predicate and use it to implement the method
        public IEnumerable<T> FindAll(IEnumerable<T> numbers, System.Func<T, bool> predicate)
        {
            yield break;
        }
    }
}