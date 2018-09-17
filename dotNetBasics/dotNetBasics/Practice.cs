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
            throw new NotImplementedException();
        }

        // А теперь как можно получить эту константу самим?
        public static double GetNaN()
        {
            throw new NotImplementedException();
        }

        // Функция сравнения двух даблов
        public static int Compare(/*тут нужно подумать над сигнатурой*/)
        {
            throw new NotImplementedException();
        }

        // Получить половину максимального инта без использования деления. Есть полезная константа
        public static int HalfMaxInt()
        {
            throw new NotImplementedException();
        }

        // Возведение числа в степень
        public static int Pow(int a, int n)
        {
            throw new NotImplementedException();
        }

        // Возведение числа в степень с контролем переполнения
        public static int PowChecked(int a, int n)
        {
            throw new NotImplementedException();
        }
        // Умножить число на 10, не используя операцию умножения
        public static int TenTimes(int a)
        {
            throw new NotImplementedException();
        }

        // Привести к строке или вернуть дефолнтную
        public static string ToStringOrDefault(int? n, string defaultValue = "Default")
        {
            throw new NotImplementedException();
        }

    }
}
