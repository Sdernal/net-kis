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
        /// <param name="eps">epsilon для сравнения вещетвенных чисел</param>
        /// <returns>
        /// Вектор длины 1, сонаправленный вектору v.
        /// Если длина v меньше eps, то v считается нулевым - выбрасывается
        /// исключение DivideByZeroException
        /// </returns>
        public static Vector Normalize(this Vector v, double eps = 1e-9)
        {
            var l = v.Length();
            if (l < eps)
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
        /// <param name="eps">epsilon для сравнения вещетвенных чисел</param>
        /// <returns>
        /// Угол между векторами v и u.
        /// Если один из векторов v и u нулевой (длина меньше eps),
        /// то угол не определён - выбрасывается DivideByZeroException
        /// </returns>
        public static double GetAngleBetween(this Vector v, Vector u,
            double eps = 1e-9)
        {
            var a = v.Normalize(eps);
            var b = u.Normalize(eps);
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
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        /// <param name="eps">epsilon для сравнения вещетвенных чисел</param>
        /// <returns>
        /// VectorRelation:
        /// Parallel, если параллельны
        /// Orthogonal, если перпендикулярны
        /// General, иначе
        /// Нулевой вектор (длина меньше eps) считается параллельным любому другому
        /// </returns>
        public static VectorRelation GetRelation(this Vector v, Vector u,
            double eps = 1e-9)
        {
            Vector a, b;
            try
            {
                a = v.Normalize(eps);
                b = u.Normalize(eps);
            }
            catch (DivideByZeroException)
            {
                return VectorRelation.Parallel;
            }

            if (Math.Abs(a.CrossProduct(b)) < eps)
            {
                return VectorRelation.Parallel;
            }

            return Math.Abs(a.DotProduct(b)) < eps
                ? VectorRelation.Orthogonal
                : VectorRelation.General;
        }

        /// <summary>
        /// Еденичный вектор, ортогональный данному, полученный поворотом на 90
        /// градусов против часовой стрелки
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <param name="eps">epsilon для сравнения вещетвенных чисел</param>
        /// <returns>
        /// Единичный вектор, повёрнутый относительно v на 90 градусов
        /// против часовой стрелки. Для нулевого вектора (длина меньше eps)
        /// выбрасывается DivideByZeroException
        /// </returns>
        public static Vector GetOrthogonal(this Vector v, double eps = 1e-9) =>
            new Vector(-v.Y, v.X).Normalize(eps);

        /// <summary>
        /// Повернуть вектор на заданный угол
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <param name="angle">
        /// Величина угла в радианах, на который осуществляется поворот
        /// против часовой стрелки. Результат поворота нулевого вектора -
        /// нулевой вектор
        /// </param>
        /// <returns>Результат поворота вектора v на угол angle</returns>
        public static Vector Rotate(this Vector v, double angle) =>
            new Vector(v.X * Math.Cos(angle) - v.Y * Math.Sin(angle),
                v.X * Math.Sin(angle) + v.Y * Math.Cos(angle));
    }
}