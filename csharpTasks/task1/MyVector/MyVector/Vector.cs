using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVector
{
    public struct Vector
    {
        /* Нужно реализовать струкруру двумерный вектор (double X, double Y):
         - Добавить коструктор
         - Реализовать методы-заглушки:
            - Длина, сложение векторов, умножение на число
            - Скалярное и векторное произведение
            - Приведение к строке: выводить (X; Y)
         - Реализовать Операторы
         - В Main протестировать все методы, пока без использования фреймворков: просто зовем метод, сравниваем результат и пишем в консоль
         - К каждому полю структуры создать документацию: шаблон создается по "///" над тем, что документируем:
        /// <summary>
        /// Привмер использования Xml documentation comments
        /// </summary>
        private void Foo()
        {

        }        
        */
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public Vector Add(Vector v)
        {
            return new Vector(X + v.X, Y + v.Y);
        }

        public Vector Scale(double k)
        {
            return new Vector(X * k, Y * k);
        }

        public double DotProduct(Vector v)
        {
            return X * v.X + Y * v.Y;
        }

        public double CrossProduct(Vector v)
        {
            return X * v.Y - Y * v.X;
        }

        public override string ToString()
        {
            return $"({X}; {Y})";
        }

        #region Operators        

        /* В этой секции нужно реализовать следующие опрераторы 
        - v + u, v - u (v,u - Vector)
        - v*k, k*v, v/k (k - double)
        - +v, -v 
        */
        // Такая семантика у операторов в C#
        public static Vector operator +(Vector v, Vector u)
        {
            return new Vector(v.X + u.X, v.Y + u.Y);
        }

        public static Vector operator -(Vector v, Vector u)
        {
            return new Vector(v.X - u.X, v.Y - v.Y);
        }

        public static Vector operator *(Vector v, double k)
        {
            return new Vector(v.X * k, v.Y * k);
        }

        public static Vector operator *(double k, Vector v)
        {
            return new Vector(v.X * k, v.Y * k);
        }

        public static Vector operator /(Vector v, double k)
        {
            return new Vector(v.X / k, v.Y / k);
        }

        public static Vector operator +(Vector v)
        {
            return v;
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y);
        }

        #endregion

        public readonly double X;
        public readonly double Y;
    }
}