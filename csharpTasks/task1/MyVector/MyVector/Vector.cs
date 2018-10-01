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

        public double x { get; private set; }
        public double y { get; private set; }

        /// <summary>
        /// Creates Vector object with x- and y-coordinates.
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinate</param>
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Returns eucledean norm of Vector
        /// </summary>
        /// <returns>Length of Vector(x, y): sqrt(x^2+y^2)</returns>
        public double Length()
        {
            return Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Adds Vector v to this Vector
        /// </summary>
        /// <param name="v">Vector v</param>
        /// <returns>This Vector</returns>
        public Vector Add(Vector v)
        {
            return new Vector(this.x + v.x, this.y + v.y);
        }

        /// <summary>
        /// Multiplies this Vector by scalar k
        /// </summary>
        /// <param name="k">Scalar k</param>
        /// <returns>This Vector</returns>
        public Vector Scale(double k)
        {
            return new Vector(this.x * k, this.y * k);
        }

        /// <summary>
        /// Calculates dot product of this Vector and Vector v
        /// </summary>
        /// <param name="v">Vector v</param>
        /// <returns></returns>
        public double DotProduct(Vector v)
        {
            return this.x * v.x + this.y * v.y;
        }
        
        /// <summary>
        /// надоело...
        /// из сигнатур методов и так все ясно
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double CrossProduct(Vector v)
        {
            return Math.Abs(this.x * v.y - this.y * v.x);
        }

        override public string ToString()
        {
            return $"Vector({this.x}, {this.y})";
        }

        #region Operators        
        /* В этой секции нужно реализовать следующие опрераторы 
        - v + u, v - u (v,u - Vector)
        - v*k, k*v, v/k (k - double)
        - +v, -v 
        */
        // Такая семантика у операторов в C#
        public static Vector operator+ (Vector v, Vector u)
        {
            return new Vector(v.x + u.x, v.y + u.y);
        }

        public static Vector operator- (Vector v, Vector u)
        {
            return new Vector(v.x - u.x, v.y - u.y);
        }

        public static Vector operator *(Vector v, double k)
        {
            return new Vector(v.x * k, v.y * k);
        }

        public static Vector operator *(double k, Vector v)
        {
            return new Vector(v.x * k, v.y * k);
        }

        public static Vector operator /(Vector v, double k)
        {
            return new Vector(v.x / k, v.y / k);
        }

        public static Vector operator +(Vector v)
        {
            return new Vector(+v.x, +v.y);
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.x, -v.y);
        }
        #endregion
    }
}
