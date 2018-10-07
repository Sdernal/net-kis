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

    public static class VectorExtensions
    {
        /// <summary>
        /// Нормализует вектор
        /// </summary>
        /// <param name="v">Двумерный вектор</param>
        /// <returns>Вектор - результат нормализации данного вектора</returns>
        /// <exception cref="ArgumentException">Выбрасывается при вызове для нулевого вектора, так как его нормализация невозможна</exception>
        public static Vector Normalize(this Vector v)
        {
            if (v.Length() == 0)
            {
                throw new ArgumentException();
            }
            
            return v / v.Length();
        }

        /// <summary>
        /// Рассчитывает угол между векторами
        /// </summary>
        /// <param name="v">Двумерный вектор</param>
        /// <param name="u">Двумерный вектор</param>
        /// <returns>Число - угол между векторами в радианах</returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.Length() == 0 || u.Length() == 0)
            {
                return 0;
            }
            
            return Math.Acos(v.DotProduct(u) / (v.Length() * u.Length()));
        }

        /// <summary>
        /// Определяет отношение между векторами
        /// </summary>
        /// <param name="v">Двумерный вектор</param>
        /// <param name="u">Двумерный вектор</param>
        /// <returns>VectorRelation - отношение между векторами</returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (v.DotProduct(u) == 0)
            {
                return VectorRelation.Orthogonal;
            }
            
            if (v.CrossProduct(u) == 0)
            {
                return VectorRelation.Parallel;
            }

            return VectorRelation.General;
        }

        /// <summary>
        /// Рассчитывает единичный вектор, ортогональный данному
        /// </summary>
        /// <param name="v">Двумерный вектор</param>
        /// <returns>Единичный вектор, ортогональный данному</returns>
        public static Vector GetOrthogonal(this Vector v)
        {
            if (v.Length() == 0)
            {
                return new Vector(1, 0);
            }
            
            return new Vector(v.Y, -v.X) / v.Length();
        }

        /// <summary>
        /// Поворачивает вектор против часовой стрелки на заданный угол
        /// </summary>
        /// <param name="v">Двумерный вектор</param>
        /// <param name="angle">Число - угол поворота в радианах</param>
        /// <returns>Вектор - результат поворота данного вектора на заданный угол</returns>
        public static Vector Rotate(this Vector v, double angle)
        {
            return new Vector(v.X * Math.Cos(angle) - v.Y * Math.Sin(angle), v.X * Math.Sin(angle) + v.Y * Math.Cos(angle));
        }
    }
}
