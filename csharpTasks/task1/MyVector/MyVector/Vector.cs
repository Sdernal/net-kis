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
        public double x, y;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="X">координата по горизонтали </param>
        /// <param name="Y">координата по вертикали </param>
        public Vector(double X, double Y)
        {
            x = X;
            y = Y;
        }
        /// <summary>
        /// Длина вектора.
        /// </summary>
        /// <returns></returns>
        public double Length()
        {
            return Math.Sqrt(x * x + y * y);
        }
        /// <summary>
        /// Прибавление вектора к вектору.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Vector Add(Vector v)
        {
            x += v.x;
            y += v.y;
            return this;
        }
        /// <summary>
        /// Умножение вектора на число.
        /// </summary>
        /// <param name="k">число, на которое умножаем</param>
        /// <returns></returns>
        public Vector Scale(double k)
        {
            x *= k;
            y *= k;
            return this;
        }
        /// <summary>
        /// Скалярное произведение векторов
        /// </summary>
        /// <param name="v">вектор</param>
        /// <returns></returns>
        public double DotProduct(Vector v)
        {
            return x * v.x + y * v.y;
        }
        /// <summary>
        /// Векторное произведение.
        /// </summary>
        /// <param name="v">вектор</param>
        /// <returns></returns>
        public double CrossProduct(Vector v)
        {
            return x * v.y - y * v.x;
        }
        /// <summary>
        /// Приведение к строке.
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            return $"({x},{y})";
        }

        #region Operators        
        /* В этой секции нужно реализовать следующие опрераторы 
        - v + u, v - u (v,u - Vector)
        - v*k, k*v, v/k (k - double)
        - +v, -v 
        */
        // Такая семантика у операторов в C#
        /// <summary>
        /// Оператор сложения векторов.
        /// </summary>
        /// <param name="v">вектор</param>
        /// <param name="u">вектор</param>
        /// <returns></returns>
        public static Vector operator +(Vector v, Vector u)
        {
            Vector result = v;
            return result.Add(u);
        }
        /// <summary>
        /// Оператор разности векторов.
        /// </summary>
        /// <param name="v">вектор</param>
        /// <param name="u">вектор</param>
        /// <returns></returns>
        public static Vector operator -(Vector v, Vector u)
        {
            Vector result = v;
            Vector result2 = u;
            return result.Add(result2.Scale(-1));
        }
        /// <summary>
        /// Оператор умножения вектора на число.
        /// </summary>
        /// <param name="v">вектор</param>
        /// <param name="k">число</param>
        /// <returns></returns>
        public static Vector operator *(Vector v, double k)
        {
            Vector result = v;
            return result.Scale(k);
        }
        /// <summary>
        /// Оператор умножения вектора на число.
        /// </summary>
        /// <param name="k">число</param>
        /// <param name="v">вектор</param>
        /// <returns></returns>
        public static Vector operator *(double k, Vector v)
        {
            return v * k;
        }
        /// <summary>
        /// Оператор деления числа на вектор.
        /// </summary>
        /// <param name="v">вектор</param>
        /// <param name="k">число</param>
        /// <returns></returns>
        public static Vector operator /(Vector v, double k)
        {
            if (k == 0) throw new ArgumentException();
            return v.Scale(1 / k);
        }
        /// <summary>
        /// Оператор плюс.
        /// </summary>
        /// <param name="v">вектор</param>
        /// <returns></returns>
        public static Vector operator +(Vector v)
        {
            return v;
        }
        /// <summary>
        /// Оператор минус.
        /// </summary>
        /// <param name="v">вектор</param>
        /// <returns></returns>
        public static Vector operator -(Vector v)
        {
            return v.Scale(-1);
        }


        #endregion
    }
}
