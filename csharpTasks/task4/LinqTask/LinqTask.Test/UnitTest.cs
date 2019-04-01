using System;
using LinqTask;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace LinqTask.Test
{
    public class UnitTest
    {
        [Fact]
        public void EmptyReviewsTest()
        {
            var reviewContext = new ReviewContext(new Review[0]);
            Assert.Empty(reviewContext.GetUserReviews(456456));
            Assert.False(reviewContext.IsMovieReviewed("Avatar"));
            Assert.Empty(reviewContext.CompareUsers(0, 1));
            Assert.Empty(reviewContext.GetFavouritesResources(2));
            Assert.Equal(0, reviewContext.GetUserEvenSumMarks(1));
            Assert.Empty(reviewContext.GetMoviesMeanMark());
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 4)]
        [InlineData(3, 6)]
        public void GetUserReviewTest(int id, int count)
        {
            var reviewContext = GetReviewContext();
            Assert.Empty(reviewContext.GetUserReviews(1000+id));
            Assert.Equal(reviewContext.GetUserReviews(id). Count(), count);
        }

        [Fact]
        public void IsMovieReviewedTest()
        {
            var reviewContext = GetReviewContext();
            Assert.False(reviewContext.IsMovieReviewed("W"));
            Assert.True(reviewContext.IsMovieReviewed("A"));
        }

        [Fact]
        public void CompareUsersTest()
        {
            var reviewContext = GetReviewContext();
            Assert.Empty(reviewContext.CompareUsers(1, 6));
            Assert.Equal(2, reviewContext.CompareUsers(1, 2).Count());
        }


        [Theory]
        [InlineData(1, 8, new[] { "C" })]
        [InlineData(5, 6, new [] { "C" })]
        public void GetFavouritesResourcesTest(int id, int minimalMark, string[] content)
        {
            var favorites = GetReviewContext().GetFavouritesResources(id, minimalMark);
            Assert.Equal(content.Count(), favorites.Count());
            foreach (var movie in content)
            {
                Assert.Contains(movie, favorites);
            }
        }

        [Theory]
        [InlineData(1, 12)]
        [InlineData(2, 14)]
        [InlineData(3, 8)]
        [InlineData(16, 0)]
        public void GetUserEvenSumMarksTest(int id, int answer)
        {
            Assert.Equal(answer, GetReviewContext().GetUserEvenSumMarks(id));
        }

        [Theory]
        [InlineData("E", 4.5)]
        [InlineData("Q", 0.0)]
        [InlineData("W", 0.0)]
        public void GetMoviesMeanMarkTest(string movie, double mark)
        {
            var marks = GetReviewContext().GetMoviesMeanMark();
            Assert.Equal(mark, marks.FirstOrDefault(p => p.Item1 == movie).Item2, 1);
        }

        private static ReviewContext GetReviewContext()
        {
            return new ReviewContext(GetReviews());
        }

        private static ICollection<Review> GetReviews()
        {
            return new[]{
                new Review {UserId = 1, Mark = 8, Movie ="A"},
                new Review {UserId = 1, Mark = 4, Movie ="B"},
                new Review {UserId = 1, Mark = 9, Movie ="C"},
                new Review {UserId = 2, Mark = 8, Movie ="D"},
                new Review {UserId = 2, Mark = 7, Movie ="E"},
                new Review {UserId = 2, Mark = 6, Movie ="A"},
                new Review {UserId = 2, Mark = 5, Movie ="B"},
                new Review {UserId = 3, Mark = 4, Movie ="C"},
                new Review {UserId = 3, Mark = 3, Movie ="D"},
                new Review {UserId = 3, Mark = 2, Movie ="E"},
                new Review {UserId = 3, Mark = 1, Movie ="F"},
                new Review {UserId = 3, Mark = 2, Movie ="G"},
                new Review {UserId = 3, Mark = 3, Movie ="H"},
                new Review {UserId = 4, Mark = 4, Movie ="A"},
                new Review {UserId = 5, Mark = 5, Movie ="B"},
                new Review {UserId = 5, Mark = 9, Movie ="C"},
                new Review {UserId = 5, Mark = 5, Movie ="D"},
                new Review {UserId = 6, Mark = 0, Movie ="Q"},
            };
        }
    }
}
