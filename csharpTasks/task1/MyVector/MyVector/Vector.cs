using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVector
{
    public struct Vector
    {
        /// <summary>
        /// Первая координата двумерного вектора
        /// </summary>
        public double X { get; private set; }
        
        /// <summary>
        /// Вторая координата двумерного вектора
        /// </summary>
        public double Y { get; private set; }
        
        /// <summary>
        /// Конструктор объекта двумерного вектора
        /// </summary>
        /// <param name="x">Первая координата двумерного вектора</param>
        /// <param name="y">Вторая координата двумерного вектора</param>
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        /// <summary>
        /// Рассчитывает длину двумерного вектора
        /// </summary>
        /// <returns>Число - длина вектора</returns>
        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        /// <summary>
        /// Прибавляет двумерный вектор к данному
        /// </summary>
        /// <param name="v">Двумерный вектор</param>
        /// <returns>Вектор - результат сложения двух векторов</returns>
        public Vector Add(Vector v)
        {
            return new Vector(X + v.X, Y + v.Y);
        }

        /// <summary>
        /// Домножает вектор на скаляр
        /// </summary>
        /// <param name="k">Скаляр</param>
        /// <returns>Вектор - результат домножения данного вектора на скаляр</returns>
        public Vector Scale(double k)
        {
            return new Vector(X * k, Y * k);
        }

        /// <summary>
        /// Рассчитывает скалярное произведение двух векторов
        /// </summary>
        /// <param name="v">Двумерный вектор</param>
        /// <returns>Число - скалярное произведение двух векторов</returns>
        public double DotProduct(Vector v)
        {
            return X * v.X + Y * v.Y;
        }

        /// <summary>
        /// Рассчитывает длину векторного произведения двух векторов
        /// </summary>
        /// <param name="v">Двумерный вектор</param>
        /// <returns>Число - длина векторного произведения двух векторов</returns>
        public double CrossProduct(Vector v)
        {
            return Math.Abs(X * v.Y - Y * v.X);
        }

        /// <summary>
        /// Приводит вектор к строковому представлению 
        /// </summary>
        /// <returns>Строка - строковое представление данного вектора</returns>
        override public string ToString()
        {
            return $"({X}; {Y})";
        }

        /// <summary>
        /// Оператор сложения двух векторов
        /// </summary>
        /// <param name="v1">Двумерный вектор</param>
        /// <param name="v2">Двумерный вектор</param>
        /// <returns>Вектор - сумма двух векторов</returns>
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }
        
        /// <summary>
        /// Оператор вычитания двух векторов
        /// </summary>
        /// <param name="v1">Двумерный вектор</param>
        /// <param name="v2">Двумерный вектор</param>
        /// <returns>Вектор - разность двух векторов</returns>
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y);
        }
        
        /// <summary>
        /// Оператор умножения вектора на число
        /// </summary>
        /// <param name="v">Двумерный вектор</param>
        /// <param name="k">Число</param>
        /// <returns>Вектор - результат умножения вектора на число</returns>
        public static Vector operator *(Vector v, double k)
        {
            return new Vector(v.X * k, v.Y * k);
        }
        
        /// <summary>
        /// Оператор умножения числа на вектор
        /// </summary>
        /// <param name="k">Число</param>
        /// <param name="v">Двумерный вектор</param>
        /// <returns>Вектор - результат умножения числа на вектор</returns>
        public static Vector operator *(double k, Vector v)
        {
            return new Vector(v.X * k, v.Y * k);
        }
        
        /// <summary>
        /// Оператор деления вектора на число
        /// </summary>
        /// <param name="v">Двумерный вектор</param>
        /// <param name="k">Число</param>
        /// <returns>Вектор - результат деления вектора на число</returns>
        public static Vector operator /(Vector v, double k)
        {
            return k != 0 ? new Vector(v.X / k, v.Y / k) : throw new DivideByZeroException();
        }

    }
}
