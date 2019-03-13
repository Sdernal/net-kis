using System;

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
        /// Конструктор
        /// </summary>
        /// <param name="X">горизонтальная составляющая</param>
        /// <param name="Y">вертикальная составляющая</param>
        public Vector(double X, double Y)
        {
            _x = X;
            _y = Y;
        }

        /// <summary>
        /// горизонтальная составляющая
        /// </summary>
        public double X
        {
            get => _x;
        }

        /// <summary>
        /// вертикальная составляющая
        /// </summary>
        public double Y
        {
            get => _y;
        }

        /// <summary>
        /// длина вектора 
        /// </summary>
        public double Length()
        {
            return Math.Sqrt(_x * _x + _y * _y);
        }

        /// <summary>
        /// добавление вектора
        /// </summary>
        public Vector Add(Vector v)
        {
            return new Vector(_x+v._x, _y + v._y);
        }

        /// <summary>
        /// домножение на число
        /// </summary>
        public Vector Scale(double k)
        {
            return new Vector(_x * k, _y * k);
        }

        /// <summary>
        /// скалярное произведение
        /// </summary>
        public double DotProduct(Vector v)
        {
            return _x * v._x + _y * v._y;
        }

        /// <summary>
        /// векторное произведение с учетом знака
        /// </summary>
        public double CrossProduct(Vector v)
        {
            return _x * v._y - _y * v._x;
        }

        /// <summary>
        /// переопределенный ToString()
        /// </summary>
        override public string ToString()
        {
            return $"({_x},{_y})";
        }

        #region Operators        
        /* В этой секции нужно реализовать следующие опрераторы 
        - v + u, v - u (v,u - Vector)
        - v*k, k*v, v/k (k - double)
        - +v, -v 
        */
        // Такая семантика у операторов в C#

        /// <summary>
        /// сумма векторов
        /// </summary>
        public static Vector operator +(Vector v, Vector u)
        {
            return new Vector(v._x + u._x, v._y + u._y);
        }

        /// <summary>
        /// разность векторов
        /// </summary>
        public static Vector operator -(Vector v, Vector u)
        {
            return new Vector(v._x - u._x, v._y - u._y);
        }

        /// <summary>
        /// умножение на число
        /// </summary>
        public static Vector operator *(Vector v, double k)
        {
            return new Vector(v._x * k, v._y * k);
        }

        /// <summary>
        /// умножение на число в другом порядке
        /// </summary>
        public static Vector operator *(double k, Vector v)
        {
            return v * k;
        }

        /// <summary>
        /// деление на число
        /// </summary>
        public static Vector operator /(Vector v, double k)
        {
            if (k == 0) throw new ArgumentException();
            return new Vector(v._x / k, v._y / k);
        }

        /// <summary>
        /// унарный минус
        /// </summary>
        public static Vector operator -(Vector v)
        {
            return new Vector(-v._x, -v._y);
        }

        /// <summary>
        /// унарный плюс
        /// </summary>
        public static Vector operator +(Vector v)
        {
            return new Vector(v._x, v._y);
        }
        #endregion

        private double _x;
        private double _y;
    }
}
