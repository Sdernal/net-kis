using System;

namespace dotNetBasics
{
    static class Program
    {
        public static void Main(string[] args)
        {
            // Ну куда же без Hello world
            Console.WriteLine("Hello world!");

            #region Про числа
            // Разные численные типы имеют разные суффиксы:
            int a1 = 1;
            uint a2 = 1U;
            long a3 = 1L;
            ulong a4 = 1UL;

            double b1 = 1.1;
            float b2 = 1.1f; // 1.1F
            decimal b3 = 1.1m; // 1.1M

            // Отличия double от decimal
            double a = 0.1;
            double b = 0.2;

            decimal c = 0.1m;
            decimal d = 0.2m;
            Console.WriteLine($"a + b == 0.3? {a + b == 0.3}");
            Console.WriteLine($"c + d == 0.3? {c + d == 0.3m}");
            #endregion
            
            #region Про типы
            var x1 = new RefType { n = 1 };
            var x2 = new ValueType { n = 1 };
            RefMethod(x1);
            ValueMethod(x2);
            Console.WriteLine($"x1:{x1.n} x2:{x2.n}");
            // В итоге у x1 поменялось значение, а у x2 - нет.
            #endregion

            #region ref и out
            ValueType x3 = x2;
            ValueMethodRef(ref x3);
            ValueMethodOut(out ValueType x4);
            Console.WriteLine($"x3:{x3.n} x4:{x4.n}");

            // Что будет, есть в качестве ref-параметра передать ссылочный тип?
            RefMethodRef(x1);
            Console.WriteLine($"x1:{x1.n}");
            RefMethodRef(ref x1);
            Console.WriteLine($"x1:{x1.n}");
            #endregion

            #region is/as
            int a_is = 5;
            Console.WriteLine($"a is int: {a_is is int}; a is short: {a_is is short}; a is double: {a_is is double}; a is object: {a_is is object}");
            object o = 5;
            int? a_as = o as int?;
            if (a_as != null)
            {
                Console.WriteLine($"a as int");
            }
            else
            {
                Console.WriteLine($"a not as int");
            }
            #endregion

            #region Pattern matching
            object ptn = 5;
            switch(ptn)
            {               
                case int as_int:
                    Console.WriteLine("As int");
                    break;
                case string as_string:
                    Console.WriteLine("As string");
                    break;
                case object as_object:
                    Console.WriteLine("As Object");
                    break;
                    // Попробуем поменять кейсы местами
            }
            #endregion

            #region Контроль переполнения 
            byte byteA = 200;
            byte byteB;
            try
            {
                byteB = checked((byte)(2 * byteA));
                //byteB = unchecked((byte)(2 * byteA));
                //byteB = (byte)checked(2 * byteA);
                Console.WriteLine(byteB);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            try
            {
                checked
                {
                    byteB = checked((byte)(2 * byteA));
                    Console.WriteLine(byteB);
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion
        }

        #region Для RefType и ValueType 
        struct ValueType
        {
            public int n;
        }

        class RefType
        {
            public int n;
        }

        static void ValueMethod(ValueType x)
        {
            x.n += 1;
        }

        static void ValueMethodRef(ref ValueType x)
        {
            x.n += 1;
        }

        static void ValueMethodOut(out ValueType x)
        {
            x = new ValueType { n = 2 };
            // x.n = 2;
        }

        static void RefMethod(RefType x)
        {
            x.n += 1;
        }

        static void RefMethodRef(ref RefType x)
        {
            x = new RefType { n = 5 };
        }
        static void RefMethodRef(RefType x)
        {
            x = new RefType { n = 5 };
        }
        #endregion
    }
}
