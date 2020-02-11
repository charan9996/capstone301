using MT.OnlineRestaurant.BusinessEntities;

using MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel;
using System.Collections.Generic;
using System.Linq;

namespace MT.OnlineRestaurant.DataLayer.Repository
{
    public interface IReviewRepository
    {
        List<RestaurantReview> GetResturantReviews(RestaurantReviewParams restaurantReviewParams);
        string PostResturantReview(RestaurantReview restaurantReview);
        bool EditResturantReview(RestaurantReview restaurantReview);

    }
}
