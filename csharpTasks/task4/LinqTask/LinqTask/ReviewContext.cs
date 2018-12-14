using System.Collections.Generic;
using System.Linq;

namespace LinqTask
{
    // Контекст, который хранит список отзывов,
    // нужно реализовать методы-заглушки
    class ReviewContext
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
            return from review in reviews
                where review.UserId == userId
                select review;
        }

        // Оценивал ли кто-нибудь фильм
        public bool IsMovieReviewed(string movieName)
        {
            return reviews.Any(r => r.Movie == movieName);
        }

        // Получить общие фильмы у двух пользователей
        public IEnumerable<string> CompareUsers(int user1, int user2)
        {
            var first = reviews.Where(r => r.UserId == user1)
                .Select(r => r.Movie);
            var second = reviews.Where(r => r.UserId == user2)
                .Select(r => r.Movie);
            return first.Intersect(second);
        }

        // Получить "любимые" фильмы пользователя (оценка которых больше некоторого значения), упорядоченные по оценке
        public IEnumerable<string> GetFavouritesResources(int userId,
            int minimalMark = 5)
        {
            return from review in reviews
                where review.UserId == userId && review.Mark >= minimalMark
                orderby review.Mark
                select review.Movie;
        }

        // Получить сумму четных оценок пользователя
        public int GetUserEvenSumMarks(int userId)
        {
            return reviews.Where(r => r.UserId == userId && r.Mark % 2 == 0)
                .Sum(r => r.Mark);
        }

        // Получить среднюю оценку для каждого фильма
        public IEnumerable<(string, double)> GetMoviesMeanMark()
        {
            return from review in reviews
                group review by review.Movie
                into movieGroup
                select (movieGroup.Key,
                    (double) movieGroup.Sum(r => r.Mark) / movieGroup.Count());
        }
    }
}
