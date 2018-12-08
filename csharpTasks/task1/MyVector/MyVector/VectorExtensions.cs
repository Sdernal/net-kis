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
        /// Normalize vector
        /// </summary>
        /// <param name="v"></param>
        public static Vector Normalize(this Vector v)
        {
            return (v / v.Length());
        }

        // Получить угол между векторами в радианах
        /// <summary>
        /// Get angle between vectors
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            return (v.DotProduct(u) / (v.Length() * u.Length()));
        }

        // Получить отношение векторов: параллельны, перпендикулярны, остальное  21 - DEADLINE 2 HW
        /// <summary>
        /// Get relation between vectors: parallel or orthogonal or general (none of listed)
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (v.DotProduct(u) == 0)
            {
                return VectorRelation.Orthogonal;
            }
            else if (v.CrossProduct(u) == 0)
            {
                return VectorRelation.Parallel;
            }
            else return VectorRelation.General;
        }

        // Еденичный ортогональный вектор данному
        /// <summary>
        /// Get an otrhogonal vector with length 1
        /// </summary>
        /// <param name="v"></param>
        public static Vector GetOrthogonal(this Vector v)
        {
            //throw new NotImplementedException();
            Vector u = new Vector(-v.y, v.x);
            return u.Normalize();
        }

        // Повернуть вектор на заданный угол
        /// <summary>
        /// Rotate vector by some angle
        /// </summary>
        /// <param name="v"></param>
        /// <param name="angle"></param>
        public static Vector Rotate(this Vector v, double angle)
        {
            //throw new NotImplementedException();
            double newX = v.x * Math.Cos(angle) - v.y * Math.Sin(angle);
            double newY = v.x * Math.Sin(angle) + v.y * Math.Cos(angle);
            Vector u = new Vector(newX, newY);
            return u;
        }
    }
}
