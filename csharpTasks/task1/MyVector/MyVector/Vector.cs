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
            _x = x;
            _y = y;
        }

        public double Length()
        {
            return Math.Sqrt(_x * _x + _y * _y);
        }

        public Vector Add(Vector v)
        {
            return new Vector(_x + v._x, _y + v._y);
        }

        public Vector Scale(double k)
        {
            return new Vector(_x * k, _y * k);
        }

        public double DotProduct(Vector v)
        {
            return _x * v._x + _y * v._y;
        }

        public double CrossProduct(Vector v)
        {
            return _x * v._y - _y * v._x;
        }

        public override string ToString()
        {
            return $"({_x}; {_y})";
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
            return new Vector(v._x + u._x, v._y + u._y);
        }

        public static Vector operator -(Vector v, Vector u)
        {
            return new Vector(v._x - u._x, v._y - v._y);
        }

        public static Vector operator *(Vector v, double k)
        {
            return new Vector(v._x * k, v._y * k);
        }

        public static Vector operator *(double k, Vector v)
        {
            return new Vector(v._x * k, v._y * k);
        }

        public static Vector operator /(Vector v, double k)
        {
            return new Vector(v._x / k, v._y / k);
        }

        public static Vector operator +(Vector v)
        {
            return v;
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v._x, -v._y);
        }

        #endregion

        private readonly double _x;
        private readonly double _y;
    }
}