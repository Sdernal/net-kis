using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsCollections
{
    static class Program
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 1, 2, 3, 4, 5 });
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            MyGeneric<string> myGeneric = new MyGeneric<string>();
            myGeneric.SomeProperty = "Hello";
            Console.WriteLine(myGeneric.SomeMethod<int>(5));

            #region Covariance&Contravariance
            ICovariance<Child> covariance = new Covariance();
            Child child = covariance.DoSmth();
            child.DoSmth();
            ICovariance<Parent> covariance2 = covariance;
            Parent parent = covariance2.DoSmth();
            parent.DoSmth();

            child = new Child();
            parent = new Parent();

            IContravariance<Parent> contravariance = new Contravariance<Parent>();
            contravariance.DoSmth(parent);
            IContravariance<Child> contravariance2 = contravariance;
            contravariance2.DoSmth(child);
            #endregion

            #region Arrays&Tuples
            (int, int) tuple = (1, 4);
            Console.WriteLine($"{tuple.Item1} {tuple.Item2}");
            var (name, age) = ("Tom", 23);

            int[][] jagged = new int[2][];
            jagged[0] = new int[3] { 1, 2, 3 };
            jagged[1] = new int[2] { 4, 5 };
            foreach (var line in jagged)
            {
                foreach (var item in line)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
            #endregion

            #region Enumerable
            foreach (var item in new MyEnumerable(7))
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            foreach (var item in new MyEnumerableYield(7))
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            foreach (var item in new MyEnumerableYield(15))
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            #endregion
        }
    }
}
