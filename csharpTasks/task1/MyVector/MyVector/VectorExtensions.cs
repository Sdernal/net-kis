using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Константа для сравнения вещественных чисел
        /// </summary>
        private const double EPS = 1e-8;

        /// <summary>
        /// Функция, проверающая вектор на нулевой
        /// </summary>
        /// <param name="v">Вектор, про который мы хотим узнать ответ</param>
        /// <returns>True, если нулевой, false иначе</returns>
        private static bool isZero(this Vector v)
        {
            return Math.Abs(v.X) < EPS && Math.Abs(v.Y) < EPS;
        }

        /// <summary>
        /// Нормализация вектора
        /// </summary>
        /// <param name="v">Вектор, который необходимо нормализовать</param>
        /// <returns>Нормализованный вектор</returns>
        public static Vector Normalize(this Vector v)
        {
            var length = v.Length();
            return (v.isZero() ? v : v / length);
        }

        /// <summary>
        /// Получения угла между двумя векторами
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        /// <returns>Угол в радианах между векторами</returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.isZero() || u.isZero())
            {
                return 0.0;
            }
            return Math.Acos(v.Normalize().DotProduct(u.Normalize()));
        }

        /// <summary>
        /// Получение отношения между векторами
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        /// <returns>Orthogonal, Parallel или General</returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (v.DotProduct(u) < EPS)
            {
                return VectorRelation.Orthogonal;
            }
            if (v.CrossProduct(u) < EPS)
            {
                return VectorRelation.Parallel;
            }
            return VectorRelation.General;
        }
        
        /// <summary>
        /// Вычисление единичного вектора, который ортоганален данному
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <returns>Единичный вектор ортоганальный заданному</returns>
        public static Vector GetOrthogonal(this Vector v)
        {
            if (v.isZero())
            {
                return new Vector(1, 0);
            }
            return new Vector(-v.Y, v.X);
        }

        // Повернуть вектор на заданный угол
        /// <summary>
        /// Поворот вектора на заданный угол
        /// </summary>
        /// <param name="v">Вектор, который надо повернуть</param>
        /// <param name="angle">Угол, на который надо повернуть</param>
        /// <returns>Вектор, который повернут на заданный угол от данного</returns>
        public static Vector Rotate(this Vector v, double angle)
        {
            return new Vector(v.X * Math.Cos(angle) - v.Y * Math.Sin(angle), v.X * Math.Sin(angle) + v.Y * Math.Cos(angle));
        }
    }
}
