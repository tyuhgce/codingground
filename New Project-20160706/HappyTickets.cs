using System;
using System.Collections.Generic;
using System.Linq;

namespace DataWorks
{
    internal class HappyTickets
    {
        private int _currIndex;
        private ulong[] _firstArray;
        private ulong[] _secondArray;
        private bool _tern = true;

        private static ulong[] GetCalc(ulong[] first, ulong[] second, int i)
        {
            ulong value = 0;
            for (var j = 0; j < 10; ++j)
            {
                value += first[j];
                second[j] = value;
            }

            for (var j = 10; j <= i*9; ++j)
            {
                value += first[j];
                value -= first[j - 10];
                second[j] = value;
            }
            return second;
        }

        private bool DefaultInitialization(List<int> counts)
        {
            if (!counts.Any() || counts.Any(t => t < 1 || t%2 != 0))
                return false;
            counts.Sort();

            if (_currIndex == 0 || counts.Any(t => t <= 2*_currIndex))
            {
                _currIndex = 2;
                _firstArray = new ulong[counts.Last()*9 + 1];
                _secondArray = new ulong[counts.Last()*9 + 1];

                for (var i = 0; i < 10; ++i)
                    _firstArray[i] = 1;

                _tern = true;
            }
            else
            {
                var newFirstArr = new ulong[counts.Last()*9 + 1];
                var newSecondArr = new ulong[counts.Last()*9 + 1];
                Array.Copy(_firstArray, newFirstArr, _firstArray.Length);
                Array.Copy(_secondArray, newSecondArr, _secondArray.Length);
                _firstArray = newFirstArr;
                _secondArray = newSecondArr;
            }

            return true;
        }

        public List<ulong> GetCountTickets(List<int> counts)
        {
            if (!DefaultInitialization(counts))
                return null;

            var currArray = _firstArray;

            var result = new List<ulong>(counts.Count());
            foreach (var j in counts.Select(t => t/2))
            {
                for (; _currIndex <= j; ++_currIndex)
                {
                    currArray =
                        _tern
                            ? GetCalc(_firstArray, _secondArray, _currIndex)
                            : GetCalc(_secondArray, _firstArray, _currIndex);
                    _tern = !_tern;
                }
                result.Add(checked(currArray.Aggregate<ulong, ulong>(0, (current, t) => current + t*t)));
            }
            return result;
        }
    }
}