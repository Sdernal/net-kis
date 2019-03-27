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
         - Добавить конструктор
         - Реализовать методы-заглушки:
            - Длина, сложение векторов, умножение на число
            - Скалярное и векторное произведение
            - Приведение к строке: выводить (X; Y)
         - Реализовать Операторы
         - В Main протестировать все методы, пока без использования фреймворков: просто зовем метод, сравниваем результат и пишем в консоль
         - К каждому полю структуры создать документацию: шаблон создается по "///" над тем, что документируем:
        /// <summary>
        /// Пример использования Xml documentation comments
        /// </summary>
        private void Foo()
        {

        }        
        */
        public double X, Y;

        public Vector(double x_, double y_)
        {
            X = x_;
            Y = y_;
        }
        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public Vector Add(Vector v)
        {
            X += v.X;
            Y += v.Y;
            return this;
        }

        public Vector Scale(double k)
        {
            this.X *= k;
            this.Y *= k;
            return this;
        }

        public double DotProduct(Vector v)
        {
            return (this.X * v.X + this.Y * v.Y);
        }

        public double CrossProduct(Vector v)
        {
            return this.X * v.Y - this.Y * v.X;
        }

        override public string ToString()
        {
            String s = "(" + this.X.ToString() + "; " + this.Y.ToString() + ")";
            return s;
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
            MyVector.Vector x = new MyVector.Vector(v.X + u.X, v.Y + u.Y);
            return x;
        }
        public static Vector operator -(Vector v, Vector u)
        {
            MyVector.Vector x = new MyVector.Vector(v.X - u.X, v.Y - u.Y);
            return x;
        }
        public static Vector operator *(Vector v, double k)
        {
            MyVector.Vector x = new MyVector.Vector(v.X * k, v.Y * k);
            return x;
        }
        public static Vector operator *(double k, Vector v)
        {
            MyVector.Vector x = new MyVector.Vector(v.X * k, v.Y * k);
            return x;
        }
        public static Vector operator /(Vector v, double k)
        {
            MyVector.Vector x = new MyVector.Vector(v.X / k, v.Y / k);
            return x;
        }
        public static Vector operator +(Vector v)
        {
            return v;
        }
        public static Vector operator -(Vector v)
        {
            return v.Scale(-1);
        }
        #endregion
    }
}
