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
        /// <summary>
        /// Поля стуктуры гориз и вертикальная состовляющая
        /// </summary>
        public readonly double X;
        public readonly double Y;
        /// <summary>
        /// Констркутор с параметрами для стукутуры
        /// </summary>
        /// <param name="x">горизонтальная состовляющая</param>
        /// <param name="y">вертикальная состовляющая</param>
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Length()
        {
            return Math.Sqrt(this.X*this.X + this.Y*this.Y);
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
            return X * v.X +Y * v.Y;
        }

        public double CrossProduct(Vector v)
        {
            return X * v.Y - Y * v.X;
        }

        override public string ToString()
        {
            return $"({this.X};{this.Y})";
        }

        #region Operators        
        /* В этой секции нужно реализовать следующие опрераторы 
        - v + u, v - u (v,u - Vector)
        - v*k, k*v, v/k (k - double)
        - +v, -v 
        */
        // Такая семантика у операторов в C#
        /// <summary>
        /// Обратим внимание, что структура это не ссылочный тип, поэтому при создании нового вектора происходит копирование
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Vector operator+ (Vector v, Vector u)
        { 
            return v.Add(u);
        }        
        /// <summary>
        /// Разность двух векторов, возвращает новый вектор
        /// </summary>
        /// <param name="v">левый операнд</param>
        /// <param name="u">правый операнд</param>
        /// <returns></returns>
        public static Vector operator-(Vector v, Vector u)
        {
            return v.Add(-u);
        }

        /// <summary>
        ///Операция умножения вектора на скаляр в конечномерном линейном пространстве над полем действительных чисел
        /// </summary>
        /// <param name="v"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Vector operator*(Vector v, double k)
        {
            return v.Scale(k);
        }
        /// <summary>
        /// Перегрузка предыдущего метода
        /// </summary>
        /// <param name="k"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector operator*(double k, Vector v)
        {
            return v * k;
        }
        /// <summary>
        /// операция деления вектора на число
        /// </summary>
        /// <param name="v"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Vector operator/(Vector v, double k)
        {
            if (k == 0) throw new ArgumentException();
            return v * (1/k);
        }
        public static Vector operator+(Vector v)
        {
            return v;
        } 
        public static Vector operator-(Vector v)
        {
            return v.Scale(-1); 
        }
        #endregion
    }
}
