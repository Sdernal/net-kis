using NUnit.Framework;
using LinqTask;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Tests
{
    public class Tests
    {

        private readonly ReviewContext _reviews;
        private readonly IEnumerable<Review> ListOfReviews;

        public Tests()
        {
            ListOfReviews = new[] {
                new Review {UserId = 1, Mark = 5, Movie="Game of thrones"},
                new Review {UserId = 1, Mark = 10, Movie="The Lord of the rings"},
                new Review {UserId = 1, Mark = 8, Movie="Avatar"},
                new Review {UserId = 1, Mark = 4, Movie = "Avengers"},
                new Review {UserId = 2, Mark = 10, Movie="Titanic"},
                new Review {UserId = 2, Mark = 10, Movie="The quent Don"},
                new Review {UserId = 2, Mark = 9, Movie="Master and Margaret"},
                new Review {UserId = 3, Mark = 4, Movie="Avengers"},
                new Review {UserId = 3, Mark = 10, Movie = "The reader"}, //10!!!
                new Review {UserId = 3, Mark = 7, Movie = "Notre Dame de Paris"}
            };
            _reviews = new ReviewContext(ListOfReviews);
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsMovieReviewedTrue()
        {
            foreach (var review in ListOfReviews)
            {
                Assert.IsTrue(_reviews.IsMovieReviewed(review.Movie), $"The film {review.Movie} is in reviews");
            }
        }

        [TestCase("Inception")]
        [TestCase("The Lion King")]
        [TestCase("The Prestige")]
        public void IsMovieReviewedFalse(string FakeMovie)
        {
            Assert.IsFalse(_reviews.IsMovieReviewed(FakeMovie));
        }

        [Test]
        public void UsersReviews()
        {
            var users = ListOfReviews.Select(r => r.UserId);
            foreach (var user in users)
            {
                Assert.IsNotEmpty(_reviews.GetUserReviews(user));
            }
            Assert.IsEmpty(_reviews.GetUserReviews(ListOfReviews.Count() + 1));
            Assert.IsEmpty(_reviews.GetUserReviews(ListOfReviews.Count() + 10));
        }

        [TestCase(1, 6, new string[] { "Avatar", "The Lord of the rings"})]
        [TestCase(2, 10, new string[] { })]
        [TestCase(3, 7, new string[] {"The reader"})]
        [TestCase(100, 3, new string[] { })]
        [TestCase(1, 20, new string[] { })]
        public void BestMovies(int userId, int minimalRate, string[] testMovies)
        {
            var movies = _reviews.GetFavouritesResources(userId, minimalRate);
            if(testMovies.Count() == 0)
            {
                Assert.IsEmpty(movies);
            }
            for(int i = 0; i < movies.Count(); i++)
            {
                Assert.AreEqual(testMovies[i], movies.ElementAt(i));
            }
        }

        [TestCase(1, 22)]
        [TestCase(2, 20)]
        [TestCase(3, 14)]
        [TestCase(1000, 0)]
        public void SumMarks(int userId, double trueSum)
        {
            Assert.AreEqual(trueSum, _reviews.GetUserEvenSumMarks(userId), 1e-3);
        }

        [TestCase("Game of thrones", 5)]
        [TestCase("Avengers", 4)]
        [TestCase("Titanic", 10)]
        public void MoviesMeanMark(string film, double Mark)
        {
            var MoviesMeanRank = _reviews.GetMoviesMeanMark();
            Assert.IsNotEmpty(MoviesMeanRank.Where(r => r.Item1 == film));
            Assert.AreEqual(MoviesMeanRank.Where(r => r.Item1 == film).First().Item2, Mark, 1e-3);
        }

        [TestCase(1, 3, new string[] { "Avengers" })]
        [TestCase(1, 2, new string[] { })]
        public void UsersComparation(int user1, int user2, string [] commonFilms) 
        {
            Assert.IsTrue(new HashSet<string>(_reviews.CompareUsers(user1, user2)).SetEquals(commonFilms));
        }

    }
}
