using System;

namespace MyVector
{
    public enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    }

    // Для создания методов расширения нужен статический класс, в котором в статических методах у первого аргумента 
    // добавляется ключевое слово this, далее можно вызывать данный метод у объектов класса такого аргумента 
    // Ниже нужно реализовать методы-расширения для нашего вектора
    // И не забыть про документацию и тесты
    public static class VectorExtensions
    {
        /// <summary>
        /// Нормализация вектора
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <returns>
        /// Вектор длины 1, сонаправленный вектору v.
        /// Если длина v меньше 1e-9, то v считается нулевым - выбрасывается
        /// исключение DivideByZeroException
        /// </returns>
        public static Vector Normalize(this Vector v)
        {
            var l = v.Length();
            if (l < 1e-9)
            {
                throw new DivideByZeroException("Zero sized Vector");
            }

            return v / l;
        }

        /// <summary>
        /// Получить угол между векторами в радианах
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        /// <returns>
        /// Угол между векторами v и u.
        /// Если один из векторов v и u нулевой (длина меньше 1e-9),
        /// то угол не определён - выбрасывается DivisionByZeroException
        /// </returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            var a = v.Normalize();
            var b = u.Normalize();
            var p = a.DotProduct(b);
            if (p > 1)
            {
                p = 1;
            }
            else if (p < -1)
            {
                p = -1;
            }

            return Math.Acos(p);
        }

        /// <summary>
        /// Получить отношение векторов: параллельны, перпендикулярны, остальное
        /// TODO: Length=0?
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        /// <returns>
        /// VectorRelation:
        /// Parallel, если параллельны
        /// Orthogonal, если перпендикулярны
        /// General, иначе
        /// </returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (Math.Abs(v.CrossProduct(u)) < 1e-4) // TODO: think about it
            {
                return VectorRelation.Parallel;
            }

            return Math.Abs(v.DotProduct(u)) < 1e-4 // TODO: and here
                ? VectorRelation.Orthogonal
                : VectorRelation.General;
        }

        /// <summary>
        /// Еденичный вектор, ортогональный данному, полученный поворотом на 90
        /// градусов против часовой стрелки
        /// TODO: Length=0?
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <returns>
        /// Единичный вектор, повёрнутый относительно v на 90 градусов
        /// против часовой стрелки
        /// </returns>
        public static Vector GetOrthogonal(this Vector v) =>
            new Vector(-v.Y, v.X).Normalize();

        /// <summary>
        /// Повернуть вектор на заданный угол
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <param name="angle">
        /// Величина угла в радианах, на который осуществляется поворот
        /// против часовой стрелки
        /// </param>
        /// <returns>Результат поворота вектора v на угол angle</returns>
        public static Vector Rotate(this Vector v, double angle) =>
            new Vector(v.X * Math.Cos(angle) - v.Y * Math.Sin(angle),
                v.X * Math.Sin(angle) + v.Y * Math.Cos(angle));
    }
}