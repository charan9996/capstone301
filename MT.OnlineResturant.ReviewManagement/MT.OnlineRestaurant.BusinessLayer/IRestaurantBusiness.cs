﻿using MT.OnlineRestaurant.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MT.OnlineRestaurant.BusinessLayer
{
    public interface IRestaurantBusiness
    {
        List<RestaurantReview> GetResturantReviews(RestaurantReviewParams restaurantReviewParams);
        RestaurantReview PostResturantReview(RestaurantReview restaurantReview);
    }
}
