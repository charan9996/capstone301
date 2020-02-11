using Moq;
using MT.OnlineRestaurant.BusinessEntities;
using MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel;
using MT.OnlineRestaurant.DataLayer.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MT.OnlineRestaurant.UT.DataLayerTest
{
    [TestFixture]
    class DataLayer
    {
        [Test]
        public void Get()
        {
            List<RestaurantReview> result = new List<RestaurantReview>();

            result.Add(new RestaurantReview
            {
                Id = 1,
                Rating = "5",
                Comments = "yoyo",
                RestaurantId = 1,
                CustomerId = 123,
                UserCreated = 1,
                UserModified = 1
            });

            result.Add(new RestaurantReview
            {
                Id = 3,
                Rating = "5",
                Comments = "Good",
                RestaurantId = 1,
                CustomerId = 123,
                UserCreated = 1,
                UserModified = 1
            });
            result.Add(new RestaurantReview
            {
                Id = 5,
                Rating = "4",
                Comments = "OKOK",
                RestaurantId = 1,
                CustomerId = 123,
                UserCreated = 11,
                UserModified = 11
            });
            RestaurantReviewParams restaurantReviewParams = new RestaurantReviewParams { CustomerID = 123, RestaurantID = 1 };
            // var mockReview = new Mock<IReviewRepository>();
            Mock<IReviewRepository> _mockBaseRepository = new Mock<IReviewRepository>();
            _mockBaseRepository.Setup(x => x.GetResturantReviews(restaurantReviewParams)).Returns(result);
            Mock<ReviewManagementContext> connectionMock = new Mock<ReviewManagementContext>();
          //var reviewRepository = new ReviewRepository(connectionMock.);
          //  var getDeatils=reviewRepository.GetResturantReviews(restaurantReviewParams);
          //  Assert.Equals(getDeatils.Count, 3);

        }
    }
}
