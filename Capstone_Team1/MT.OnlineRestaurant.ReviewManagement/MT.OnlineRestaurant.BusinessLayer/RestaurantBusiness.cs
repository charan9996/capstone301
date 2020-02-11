using System;
using System.Collections.Generic;
using MT.OnlineRestaurant.BusinessEntities;
using MT.OnlineRestaurant.DataLayer.Repository;

namespace MT.OnlineRestaurant.BusinessLayer
{
    public class RestaurantBusiness : IRestaurantBusiness
    {
        private readonly IReviewRepository _reviewRepository;
        public RestaurantBusiness(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public bool EditResturantReview(RestaurantReview restaurantReview)
        {
            try
            {
                var result = _reviewRepository.EditResturantReview(restaurantReview);
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<RestaurantReview> GetResturantReviews(RestaurantReviewParams restaurantReviewParams)
        {
            List<RestaurantReview> result = new List<RestaurantReview>();
            try {
                 
                   result= _reviewRepository.GetResturantReviews(restaurantReviewParams);
                return result;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string PostResturantReview(RestaurantReview restaurantReview)
        {
            try
            {
               return _reviewRepository.PostResturantReview(restaurantReview);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
