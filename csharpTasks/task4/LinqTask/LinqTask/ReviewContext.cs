using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqTask
{
    // Контекст, который хранит список отзывов,
    // нужно реализовать методы-заглушки
    class ReviewContext
    {
        private IEnumerable<Review> reviews_;

        // Инициализируется перечислением отзывов
        public ReviewContext(IEnumerable<Review> visitings)
        {
            reviews_ = visitings;
        }

        // Получение объектов отзывов у конкретного пользователя
        public IEnumerable<Review> GetUserReviews(int userId)
        {
            return reviews_.Where(review => review.UserId == userId);
        }

        // Оценивал ли кто-нибудь фильм
        public bool IsMovieReviewed(string movieName)
        {
            return reviews_.Any(review => review.Movie == movieName);
        }

        // Получить общие фильмы у двух пользователей
        public IEnumerable<string> CompareUsers(int user1, int user2)
        {
            Func<int, IEnumerable<string>> getMovies = userId => reviews_.Where(review => review.UserId == userId)
                                                                      .Select(review => review.Movie);

            return getMovies(user1).Intersect(getMovies(user2));
        }

        // Получить "любимые" фильмы пользователя (оценка которых больше некоторого значения), упорядоченные по оценке
        public IEnumerable<string> GetFavouritesResources(int userId, int minimalMark = 5)
        {
            return reviews_.Where(review => review.UserId == userId && review.Mark > minimalMark).Select(review => review.Movie);
        }

        // Получить сумму четных оценок пользователя
        public int GetUserEvenSumMarks(int userId)
        {
            return reviews_.Where(review => review.UserId == userId && review.Mark % 2 == 0).Select(review => review.Mark).Sum();
        }

        // Получить среднюю оценку для каждого фильма
        public IEnumerable<(string, double)> GetMoviesMeanMark()
        {
            return reviews_.GroupBy(review => review.Movie)
                           .Select(group => (group.Key, group.Select(review => review.Mark).Average()));
        }    
    }
}
