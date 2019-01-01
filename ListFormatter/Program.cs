using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFormatter
{
    class Program
    {
        public static void Main(string[] args) {
            var numbers = new List<int> {
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
            Console.Write("Press any key to continue.");
            Console.ReadKey();
            //   
        }

        private static bool IsDiff(int x, int y) {
            return y - x == 1;
        }

        public static string GetRangeString(List<int> list) {
            // Return fast if list is null or contains less than 2 items
            if (list == null || !list.Any()) return string.Empty;
            if (list.Count == 1) return list[0].ToString();

            var rangeString = new StringBuilder();
            bool isRange = false;
            int rangeCount = 0;
            int difference = 0;

            for (int i = 0; i < list.Count; i++) {
                while (i < list.Count - 1 && IsDiff(list[i], list[i + 1])) {
                    if (!isRange) rangeString.Append($" # from {list[i]}");
                    isRange = true;
                    rangeCount++;
                    i++;
                }

                if (isRange) {
                    rangeString.Append(" to ");
                    isRange = false;
                    // This line is ok.....
                    rangeString.Replace("#", $"{rangeCount + 1}" + NumberStr(rangeCount + 1));
                    
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

            string temp = rangeString.ToString().TrimEnd(',');
            temp += $" ({list.Count} days.)";

            return temp; // ... ... 
        }

        public static string NumberStr(int n) {
            if (n == 1)
                return " number";

            return " numbers";
        }
    }
}