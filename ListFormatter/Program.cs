using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFormatter
{
    class Program
    {
        public static void Main(string[] args)
        {
            var numbers = new List<int>
            {
                1, 2, 3, 4,
                5, 6, 7, 8,
                9, 2, 6, 3,
                7, 4, 5, 10,
                11, 12, 13, 20,
                22, 23, 11, 9,
                6, 4, 22, 23,
                24, 25, 26, 5,
                21, 6, 11, 2,
                3, 4, 5, 6,
                7, 8, 9, 10
            };

            Console.WriteLine(GetRangeString(numbers));
            Console.Write("Press any key to continue..");
            Console.ReadKey();
        }

        private static bool IsDiff(int x, int y)
        {
            return y - x == 1;
        }

        public static string GetRangeString(int[] arr)
        {
            // Return fast if array is null or contains less than 2 items
            if (arr == null || !arr.Any()) return string.Empty;
            if (arr.Length == 1) return arr[0].ToString();

            var rangeString = new StringBuilder();
            bool isRange = false;

            for (int i = 0; i < arr.Length; i++)
            {
                while (i < arr.Length - 1 && arr[i] + 1 == arr[i + 1])
                {
                    if (!isRange) rangeString.Append($"{arr[i]}");
                    isRange = true;
                    i++;
                }

                if (isRange)
                {
                    rangeString.Append("-");
                    isRange = false;
                }

                rangeString.Append($"{arr[i]},");
            }

            return rangeString.ToString().TrimEnd(',');
        }

        public static string GetRangeString(List<int> list)
        {
            // Return fast if list is null or contains less than 2 items
            if (list == null || !list.Any()) return string.Empty;
            if (list.Count == 1) return list[0].ToString();

            var rangeString = new StringBuilder();
            bool isRange = false;
            int rangeCount = 0;
            int difference = 0;

            for (int i = 0; i < list.Count; i++)
            {
                while (i < list.Count - 1 && list[i] + 1 == list[i + 1])
                {
                    if (!isRange) rangeString.Append($"(# days from ) {list[i]}");
                    isRange = true;
                    rangeCount++;
                    i++;
                }

                if (isRange)
                {
                    rangeString.Append(" to ");
                    isRange = false;
                    // This line is ok.....
                    rangeString.Replace("#", $"{rangeCount + 1}");
                    // Under Development....
                    rangeString.Replace("@", $"{difference - 1}");
                    rangeCount = 0;
                    difference = 0;
                }

                rangeString.Append($"{list[i]},");

                if (difference == 0)
                    rangeString.Append(" (@) ");

                difference++;
            }

            rangeString.Replace(" (0) ", "");
            rangeString.Replace(" (@) ", "");
            
            return rangeString.ToString().TrimEnd(',');      // ... ... 
        }
    }
}
