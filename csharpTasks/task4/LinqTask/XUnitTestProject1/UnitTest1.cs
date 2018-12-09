using System;
using LinqTask;
using System.Linq;
using Xunit;
using System.Collections.Generic;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private List<Review> ReviewList = new List<Review> {
            new Review {UserId = 1, Mark = 4, Movie = "A"},
            new Review {UserId = 1, Mark = 6, Movie = "B"},
            new Review {UserId = 2, Mark = 7, Movie = "A"},
            new Review {UserId = 2, Mark = 7, Movie = "C"},
            new Review {UserId = 3, Mark = 5, Movie = "A"},
            new Review {UserId = 3, Mark = 8, Movie = "B"}
        };

        [Fact]
        public void TestFact()
        {
            // Arrange
            var reviewContext = new ReviewContext(ReviewList);

            // Act
            int sum = reviewContext.GetUserEvenSumMarks(1);

            // Assert
            Assert.Equal(10, sum);
        }

        [Theory]
        [InlineData("A", 16.0 / 3, true)]
        [InlineData("B", 7.0, true)]
        [InlineData("C", 100.0, false)]
        public void TestTheory(string movie, double mean, bool equals)
        {
            // Arrange
            var reviewContext = new ReviewContext(ReviewList);

            // Act
            var moviesMark = reviewContext.GetMoviesMeanMark();

            // Assert
            Assert.Equal(equals, (moviesMark.First(m => m.Item1 == movie).Item2 - mean) < 1e-9);
        }
    }
}
