using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqTask
{
    // Контекст, который хранит список отзывов,
    // нужно реализовать методы-заглушки
    public class ReviewContext
    {
        private IEnumerable<Review> reviews;

        // Инициализируется перечислением отзывов
        public ReviewContext(IEnumerable<Review> visitings)
        {
            this.reviews = visitings;
        }

        // Получение объектов отзывов у конкретного пользователя
        public IEnumerable<Review> GetUserReviews(int userId)
        {
            return reviews
                .Where(r => r.UserId == userId);
        }

        // Оценивал ли кто-нибудь фильм
        public bool IsMovieReviewed(string movieName)
        {
            return reviews
                .Any(r => r.Movie == movieName);
        }

        // Получить общие фильмы у двух пользователей
        public IEnumerable<string> CompareUsers(int user1, int user2)
        {
            return reviews
                .Where(r => r.UserId == user1)
                .Select(r => r.Movie)
                .Intersect(reviews.Where(r => r.UserId == user2).Select(r => r.Movie));
        }

        // Получить "любимые" фильмы пользователя (оценка которых больше некоторого значения), упорядоченные по оценке
        public IEnumerable<string>
            GetFavouritesResources(int userId, int minimalMark = 5)
        {
            return reviews
                .Where(r => r.UserId == userId && r.Mark > minimalMark)
                .OrderBy(r => r.Mark)
                .Select(r => r.Movie);
        }

        // Получить сумму четных оценок пользователя
        public int GetUserEvenSumMarks(int userId)
        {
            return reviews
                .Where(r => r.UserId == userId && r.Mark % 2 == 0)
                .Sum(r => r.Mark);
        }

        // Получить среднюю оценку для каждого фильма
        public IEnumerable<(string, double)> GetMoviesMeanMark()
        {
            return reviews
                .GroupBy(r => r.Movie)
                .Select(g => (g.Key, g.Average(r => r.Mark)));
        }
    }
}
