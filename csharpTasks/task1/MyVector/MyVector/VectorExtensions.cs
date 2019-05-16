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
        // Нормализовать вектор
        /// <summary>
        /// Нормализуем вектор.
        /// </summary>
        /// <param name="v">вектор</param>
        /// <returns></returns>
        public static Vector Normalize(this Vector v)
        {
            if (v.Length() == 0) throw new ArgumentException();
            return v / v.Length();
        }

        // Получить угол между векторами в радианах
        /// <summary>
        /// Возвращает угол между векторами в радианах.
        /// </summary>
        /// <param name="v">вектор</param>
        /// <param name="u">вектор</param>
        /// <returns></returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if(v.Length() == 0 || u.Length() == 0) throw new ArgumentException();
            return Math.Acos(v.DotProduct(u) / (v.Length() * u.Length()));
        }

        // Получить отношение векторов: параллельны, перпендикулярны, остальное
        /// <summary>
        /// Отношение векторов.
        /// </summary>
        /// <param name="v">вектор</param>
        /// <param name="u">вектор</param>
        /// <returns></returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            VectorRelation relation = VectorRelation.General;
            if (v.CrossProduct(u) == 0)
                relation = VectorRelation.Parallel;
            else if (v.DotProduct(u) == 0)
                relation = VectorRelation.Orthogonal;
            return relation;
        }

        // Еденичный ортогональный вектор данному
        /// <summary>
        /// Еденичный ортогональный вектор данному
        /// </summary>
        /// <param name="v">вектор</param>
        /// <returns></returns>
        public static Vector GetOrthogonal(this Vector v)
        {
            if (v.Length() == 0) throw new ArgumentException();
            return new Vector(-v.y, v.x) / v.Length();
        }

        // Повернуть вектор на заданный угол
        /// <summary>
        /// Поворот вектора на угол.
        /// </summary>
        /// <param name="v">вектор</param>
        /// <param name="angle">угол</param>
        /// <returns></returns>
        public static Vector Rotate(this Vector v, double angle)
        {
            return new Vector(v.x * Math.Cos(angle) - v.y * Math.Sin(angle), v.x * Math.Sin(angle) + v.y * Math.Cos(angle));
        }
    }
}
