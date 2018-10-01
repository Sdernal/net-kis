using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetBasics
{
    public static class Practice
    {
        // Иногда может возникнуть ситуация, когда при арифметических операций мы получили "не число"
        // Нужно написать сравнение с такой штукой. Подсказка: есть специальная константа 
        public static bool IsNaN(double d)
        {
            return Double.IsNaN(d);
        }

        // А теперь как можно получить эту константу самим?
        public static double GetNaN()
        {
            return 0D / 0D;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="presicion"></param>
        /// <returns></returns>
        public static int Compare(double x, double y, double presicion)
        {
            double diff = x - y;
            if (Math.Abs(diff) < presicion)
            {
                return 0;
            }
            else if (diff < 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        // Получить половину максимального инта без использования деления. Есть полезная константа
        public static int HalfMaxInt()
        {
            return Int32.MaxValue >> 1;
        }

        // Возведение числа в степень
        public static int Pow(int a, int n)
        {
            if (n == 1)
                return a;
            else if ((n & 1) == 1)
                return a * Pow(a, n - 1);
            else
            {
                int y = Pow(a, n / 2);
                return y * y;
            }
        }

        // Возведение числа в степень с контролем переполнения
        public static int PowChecked(int a, int n)
        {
            if (n == 1)
                return a;
            else if ((n & 1) == 1)
                return checked((int)(a * Pow(a, n - 1)));
            else
            {
                int y = Pow(a, n / 2);
                return checked((int)(y * y));
            }
        }
        // Умножить число на 10, не используя операцию умножения
        public static int TenTimes(int a)
        {
            return Int32.Parse(a.ToString() + '0');
        }

        // Привести к строке или вернуть дефолнтную
        public static string ToStringOrDefault(int? n, string defaultValue = "Default")
        {
            return n?.ToString() ?? defaultValue;
        }

    }
}
