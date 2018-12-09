using System;
using LinqTask;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UnitTestApp.Controllers;
using Xunit;
using System.Collections.Generic;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        List<Review> GenerateReviewList()
        {
            return new List<Review>
            {
                new Review {UserId = 1, Mark = 4, Movie ="A"},
                new Review {UserId = 1, Mark = 6, Movie ="B"},
                new Review {UserId = 2, Mark = 7, Movie ="A"},
                new Review {UserId = 2, Mark = 7, Movie ="C"},
                new Review {UserId = 3, Mark = 5, Movie ="A"},
                new Review {UserId = 3, Mark = 8, Movie ="B"}
            };
        }

        [Fact]
        public void TestFact()
        {
            // Arrange
            List<Review> reviews = GenerateReviewList();
            var reviewContext = new ReviewContext(reviews);

            // Act
            var user1ReviewsCount = reviewContext.GetUserReviews(1).Count();

            // Assert
            Assert(reviewContext.GetUserReviews(1).Count() == 2);
            Debug.Assert(reviewContext.IsMovieReviewed("A"));
            Debug.Assert(!reviewContext.IsMovieReviewed("D"));
            Debug.Assert(reviewContext.CompareUsers(1, 2).Contains("A"));
            Debug.Assert(reviewContext.CompareUsers(1, 3).Count() == 2);
            Debug.Assert(reviewContext.GetFavouritesResources(1, 5).Contains("B"));
            Debug.Assert(!reviewContext.GetFavouritesResources(3, 6).Contains("A"));
            Debug.Assert(reviewContext.GetUserEvenSumMarks(1) == 10);


            var moviesMark = reviewContext.GetMoviesMeanMark();
            Debug.Assert((moviesMark.First(m => m.Item1 == "A").Item2 - 16.0 / 3) < 1e-9);
            Debug.Assert((moviesMark.First(m => m.Item1 == "B").Item2 - 14.0 / 2) < 1e-9);
        }

        [Theory]
        public void TestTheory(List<Review> reviews)
        {
            var reviewContext = new ReviewContext(reviews);
            Debug.Assert(reviewContext.GetUserReviews(1).Count() == 2);
            Debug.Assert(reviewContext.IsMovieReviewed("A"));
            Debug.Assert(!reviewContext.IsMovieReviewed("D"));
            Debug.Assert(reviewContext.CompareUsers(1, 2).Contains("A"));
            Debug.Assert(reviewContext.CompareUsers(1, 3).Count() == 2);
            Debug.Assert(reviewContext.GetFavouritesResources(1, 5).Contains("B"));
            Debug.Assert(!reviewContext.GetFavouritesResources(3, 6).Contains("A"));
            Debug.Assert(reviewContext.GetUserEvenSumMarks(1) == 10);

            var moviesMark = reviewContext.GetMoviesMeanMark();
            Debug.Assert((moviesMark.First(m => m.Item1 == "A").Item2 - 16.0 / 3) < 1e-9);
            Debug.Assert((moviesMark.First(m => m.Item1 == "B").Item2 - 14.0 / 2) < 1e-9);
        }
    }
}
