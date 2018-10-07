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
        /// Конструирует вектор по его координатам
        /// </summary>
        /// <param name="x">Координата по оси абцисс</param>
        /// <param name="y">Координата по оси ординат</param>
        public Vector(double x, double y)
        {
            if (double.IsNaN(x) || double.IsNaN(y))
            {
                throw new ArgumentException("Coordinates can\'t be NaN");
            }

            X = x;
            Y = y;
        }

        /// <summary>
        /// Вычисляет длину вектора
        /// </summary>
        /// <returns>Длина вектора</returns>
        public double Length() => Math.Sqrt(X * X + Y * Y);

        /// <summary>
        /// Складывает два вектора
        /// </summary>
        /// <param name="v">Вектор, который нужно сложить с данным</param>
        /// <returns>Вектор-сумма данного вектора и вектора v</returns>
        public Vector Add(Vector v) => new Vector(X + v.X, Y + v.Y);

        /// <summary>
        /// Умножение вектора на скаляр
        /// </summary>
        /// <param name="k">Число, на которое умножается вектор</param>
        /// <returns>Вектор - произведение данного на число k</returns>
        public Vector Scale(double k) => new Vector(X * k, Y * k);

        /// <summary>
        /// Скалярное произведение векторов
        /// </summary>
        /// <param name="v">Вектор, на который данный умножается скалярно</param>
        /// <returns>Скалярное призведение данного вектора на вектор v</returns>
        public double DotProduct(Vector v) => X * v.X + Y * v.Y;

        /// <summary>
        /// Плоское "векторное" произведение векторов
        /// </summary>
        /// <param name="v">Вектор, на который данный умножается векторно</param>
        /// <returns>Векторное призведение данного вектора на вектор v</returns>
        public double CrossProduct(Vector v) => X * v.Y - Y * v.X;

        /// <summary>
        /// Строковое представление в форме (X; Y)
        /// </summary>
        /// <returns>Строковое представление</returns>
        public override string ToString() => $"({X}; {Y})";

        #region Operators        

        /* В этой секции нужно реализовать следующие опрераторы 
        - v + u, v - u (v,u - Vector)
        - v*k, k*v, v/k (k - double)
        - +v, -v 
        */
        // Такая семантика у операторов в C#

        /// <summary>
        /// Сумма векторов
        /// </summary>
        /// <param name="v">Первое слагаемое</param>
        /// <param name="u">Второе слагаемое</param>
        /// <returns>Сумма векторов v и u</returns>
        public static Vector operator +(Vector v, Vector u) =>
            new Vector(v.X + u.X, v.Y + u.Y);

        /// <summary>
        /// Разность векторов
        /// </summary>
        /// <param name="v">Уменьшаемое</param>
        /// <param name="u">Вычитаемое</param>
        /// <returns>Разность векторв v и u</returns>
        public static Vector operator -(Vector v, Vector u) =>
            new Vector(v.X - u.X, v.Y - u.Y);

        /// <summary>
        /// Домножение вектора на скаляр (число)
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <param name="k">Скаляр</param>
        /// <returns>Произведение вектора на скаляр</returns>
        public static Vector operator *(Vector v, double k) =>
            new Vector(v.X * k, v.Y * k);

        /// <summary>
        /// Домножение вектора на скаляр (число)
        /// </summary>
        /// <param name="k">Скаляр</param>
        /// <param name="v">Вектор</param>
        /// <returns>Произведение вектора на скаляр</returns>
        public static Vector operator *(double k, Vector v) =>
            new Vector(v.X * k, v.Y * k);

        /// <summary>
        /// Деление вектора на число
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <param name="k">Число</param>
        /// <returns>
        /// Результат деления вектора на число.
        /// При делении на число около нуля компоненты результирующего вектора
        /// могут стать бесконечными
        /// </returns>
        public static Vector operator /(Vector v, double k) =>
            new Vector(v.X / k, v.Y / k);

        /// <summary>
        /// Ничего не делает: возвращает тот же вектор, что и на входе
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <returns>Тот же самый вектор v</returns>
        public static Vector operator +(Vector v) => v;

        /// <summary>
        /// Возвращает противоположный вектор
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <returns>Вектор, противоположный вектору v</returns>
        public static Vector operator -(Vector v) => new Vector(-v.X, -v.Y);

        #endregion

        public double X { get; }
        public double Y { get; }
    }
}