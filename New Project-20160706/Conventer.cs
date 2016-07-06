using System.Collections.Generic;

namespace DataWorks
{
    public static class Conventer
    {
        public static int RomanToInt(string input)
        {
            var dictionary = new Dictionary<string, int>
            {
                {"I", 1},
                {"IV", 4},
                {"V", 5},
                {"IX", 9},
                {"X", 10},
                {"XL", 40},
                {"L", 50},
                {"XC", 90},
                {"C", 100},
                {"CD", 400},
                {"D", 500},
                {"CM", 900},
                {"IM", 999},
                {"M", 1000}
            };
            var str = input + "0";
            var sum = 0;
            for (var i = 0; i < str.Length - 1; ++i)
            {
                int temp;
                if (dictionary.TryGetValue(str.Substring(i, 2), out temp))
                {
                    sum += temp;
                    ++i;
                }
                else if (dictionary.TryGetValue(str.Substring(i, 1), out temp))
                {
                    sum += temp;
                }
                else
                {
                    return -1;
                }
            }
            return sum;
        }
    }
}