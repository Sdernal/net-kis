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
        /// Нулевой вектор
        /// </summary>
        public static Vector ZERO = new Vector(0, 0);

        /// <summary>
        /// Невалидный вектор
        /// </summary>
        public static Vector INVALID = new Vector(double.NaN, double.NaN);

        /// <summary>
        /// Первая координата вектора
        /// </summary>
        public double X { get; private set; }

        /// <summary>
        /// Вторая координата вектора
        /// </summary>
        public double Y { get; private set; }

        /// <summary>
        /// Конструктор для вектора
        /// </summary>
        /// <param name="X">Первая координата</param>
        /// <param name="Y">Вторая координата</param>
        public Vector(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Функция, которая вычисляет и возвращает длину вектора
        /// </summary>
        /// <returns>Длина вектора</returns>
        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        /// <summary>
        /// Функция, которая складывает текущий вектор с заданным
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <returns>Результат сложения двух векторов</returns>
        public Vector Add(Vector v)
        {
            return new Vector(X + v.X, Y + v.Y);
        }

        /// <summary>
        /// Функция, которая растягивает вектор в k раз
        /// </summary>
        /// <param name="k">Числа типа double, на которое происходит умножение</param>
        /// <returns>Результат умножения вектора на число</returns>
        public Vector Scale(double k)
        {
            return new Vector(X * k, Y * k);
        }

        /// <summary>
        /// Вычисляет скалярное произведение двух векторов
        /// </summary>
        /// <param name="v">Вектор, с которым берется скалярное произведение</param>
        /// <returns>Результат скалярного умножения двух векторов</returns>
        public double DotProduct(Vector v)
        {
            return X * v.X + Y * v.Y;
        }

        /// <summary>
        /// Вычисляет длину векторного произведения двух векторов
        /// </summary>
        /// <param name="v">Вектор, с которым берется векторное произведение</param>
        /// <returns>Число, которое по модулю равно длине векторного произведения двух векторов</returns>
        public double CrossProduct(Vector v)
        {
            return X * v.Y - Y * v.X;
        }

        /// <summary>
        /// Возвращает строковое представление вектора
        /// </summary>
        /// <returns>Строковое представление вектора</returns>
        override public string ToString()
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

        /// <summary>
        /// Сложение двух векторов
        /// </summary>
        /// <param name="v">Первое слагаемое</param>
        /// <param name="u">Второе слагаемое</param>
        /// <returns>Сумма двух векторов</returns>
        public static Vector operator +(Vector v, Vector u)
        {
            return new Vector(v.X + u.X, v.Y + u.Y);
        }

        /// <summary>
        /// Вычитание двух векторов
        /// </summary>
        /// <param name="v">Уменьшаемое</param>
        /// <param name="u">Вычитаемое</param>
        /// <returns>Разность двух векторов</returns>
        public static Vector operator -(Vector v, Vector u)
        {
            return new Vector(v.X - u.X, v.Y - u.Y);
        }

        /// <summary>
        /// Умножение вектора на число
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <param name="k">Число, на которое будет умножаться вектор</param>
        /// <returns>Результат растяжения</returns>
        public static Vector operator *(Vector v, double k)
        {
            return new Vector(v.X * k, v.Y * k);
        }

        /// <summary>
        /// Умножение числа на вектор
        /// </summary>
        /// <param name="k">Число, на которое будет умножаться вектор</param>
        /// <param name="v">Вектор</param>
        /// <returns>Результат растяжения</returns>
        public static Vector operator *(double k, Vector v)
        {
            return new Vector(v.X * k, v.Y * k);
        }

        /// <summary>
        /// Деление вектора на число
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <param name="k">Число, на которое будет производиться деление</param>
        /// <returns>Результат деления вектора на число</returns>
        public static Vector operator /(Vector v, double k)
        {
            if (k == 0)
            {
                return INVALID;
            }
            return new Vector(v.X / k, v.Y / k);
        }

        #endregion
    }
}
