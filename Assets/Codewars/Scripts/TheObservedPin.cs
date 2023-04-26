// https://www.codewars.com/kata/5263c6999e0f40dee200059d/train/csharp
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;

namespace Codewars.TheObservedPin
{
    public class Kata
    {
        private static int[][] _adjacentsIndex;

        public static List<string> GetPINs(string observed)
        {
            if (observed.Length == 0) return new();
            _adjacentsIndex ??= BuildAdjacentsIndex();
            int[][] observedAdjacents = observed.Select(c => _adjacentsIndex[c - '0']).ToArray();

            List<List<int>> pins = new();
            pins.AddRange(observedAdjacents[0].Select(n => new List<int>() {n}));
            for (int observedInx = 1; observedInx < observedAdjacents.Length; observedInx++)
            {
                int[] adjacents = observedAdjacents[observedInx];
                int prevPinsCount = pins.Count;
                for (int adjacentInx = 0; adjacentInx < adjacents.Length; adjacentInx++)
                {
                    int adjacent = adjacents[adjacentInx];
                    for (int prevPinInx = 0; prevPinInx < prevPinsCount; prevPinInx++)
                    {
                        List<int> pin;
                        if (adjacentInx == adjacents.Length - 1)
                        {
                            pin = pins[prevPinInx];
                        }
                        else
                        {
                            pin = new();
                            pin.AddRange(pins[prevPinInx]);
                            pins.Add(pin);
                        }
                        pin.Add(adjacent);
                    }
                }
            }
            return pins.ConvertAll(numbers => string.Join("", numbers));
        }

        private static int[][] BuildAdjacentsIndex()
        {
            List<int>[] adjacentLists = Enumerable
            .Range(1, 9)
            .Select(n => AdjacentsOf(n).ToList())
            .Prepend(new List<int> { 0 , 8 })
            .ToArray();
            adjacentLists[8].Add(0);
            return adjacentLists.Select(l => l.ToArray()).ToArray();
        }

        private static IEnumerable<int> AdjacentsOf(int n)
        {
            return NumbersAround(n)
                .Where(n => n >= 1 && n <= 9);
        }

        private static IEnumerable<int> NumbersAround(int n)
        {
            yield return n;
            if ((n - 1) % 3 != 2) yield return n + 1;
            if ((n - 1) % 3 != 0) yield return n - 1;
            if ((n - 1) / 3 != 2) yield return n + 3;
            if ((n - 1) / 3 != 0) yield return n - 3;
        }
    }
}