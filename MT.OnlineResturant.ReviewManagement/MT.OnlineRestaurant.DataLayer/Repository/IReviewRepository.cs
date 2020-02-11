using MT.OnlineRestaurant.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MT.OnlineRestaurant.DataLayer.Repository
{
   public interface IReviewRepository
    {
        List<RestaurantReview> GetResturantReviews(RestaurantReviewParams restaurantReviewParams);
        RestaurantReview PostResturantReview(RestaurantReview restaurantReview);
    }
}
