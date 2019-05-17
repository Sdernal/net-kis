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
            // throw new NotImplementedException();
            return reviews.Where(review => review.UserId == userId);
        }

        // Оценивал ли кто-нибудь фильм
        public bool IsMovieReviewed(string movieName)
        {
            // throw new NotImplementedException();
            return reviews.Any(review => review.Movie == movieName);
        }

        // Получить общие фильмы у двух пользователей
        public IEnumerable<string> CompareUsers(int user1, int user2)
        {
            // throw new NotImplementedException();
            var films1 = GetUserReviews(user1).Select(review => review.Movie);
            var films2 = GetUserReviews(user2).Select(review => review.Movie);
            return films1.Intersect(films2);
        }

        // Получить "любимые" фильмы пользователя (оценка которых больше некоторого значения), упорядоченные по оценке
        public IEnumerable<string> GetFavouritesResources(int userId, int minimalMark = 5)
        {
            // throw new NotImplementedException();
            return reviews.Where(review => review.Mark > minimalMark && review.UserId == userId)
                .OrderBy(review => review.Mark).Select(review => review.Movie);
        }

        // Получить сумму четных оценок пользователя
        public int GetUserEvenSumMarks(int userId)
        {
            // throw new NotImplementedException();
            return GetUserReviews(userId).Select(review => review.Mark).Where(mark => mark % 2 == 0).Sum();
        }

        // Получить среднюю оценку для каждого фильма
        public IEnumerable<(string, double)> GetMoviesMeanMark()
        {
            // throw new NotImplementedException();
            return reviews.GroupBy(review => review.Movie).Select(film => (film.Key, film.Average(f => f.Mark)));
        }    
    }
}
