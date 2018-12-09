using System;
using Xunit;
using LinqTask;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTestLinqTask
{
    public class ReviewContextTest
    {
        private List<Review> defaultReviewList = new List<Review> {
            new Review { UserId = 1, Mark = 4, Movie = "A" },
            new Review { UserId = 1, Mark = 6, Movie = "B" },
            new Review { UserId = 2, Mark = 7, Movie = "A" },
            new Review { UserId = 2, Mark = 7, Movie = "C" },
            new Review { UserId = 3, Mark = 5, Movie = "A" },
            new Review { UserId = 3, Mark = 8, Movie = "B" }
        };
    
        [Fact]
        public void IsUser1ReviewsCountMatchesTest()
        {
            // Arrange
            var reviewContext = new ReviewContext(defaultReviewList);

            // Act
            int user1ReviewsCount = reviewContext.GetUserReviews(1).Count();

            // Assert
            Assert.Equal(2, user1ReviewsCount);
        }

        [Theory]
        [InlineData("D", false)]
        [InlineData("A", true)]
        public void IsMovieReviewedTest(string movie, bool reviewed) {
            // Arrange
            var reviewContext = new ReviewContext(defaultReviewList);

            // Act
            bool isMovieReviewed = reviewContext.IsMovieReviewed(movie);

            // Assert
            Assert.Equal(isMovieReviewed, reviewed);
        }

        [Theory]
        [InlineData(3, 6, "A", false)]
        [InlineData(1, 5, "B", true)]
        public void IsFavouriteResourcesContainsMovieTest(int id1, int id2, string movie, bool contains) {
            // Arrange
            var reviewContext = new ReviewContext(defaultReviewList);

            // Act
            var favouriteResources = reviewContext.GetFavouritesResources(id1, id2);

            // Assert
            Assert.Equal(favouriteResources.Contains(movie), contains);
        }
    }
}
