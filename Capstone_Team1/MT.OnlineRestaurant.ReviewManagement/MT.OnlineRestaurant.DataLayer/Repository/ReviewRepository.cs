using System;
using System.Collections.Generic;
using System.Text;
using MT.OnlineRestaurant.DataLayer.EntityFrameWorkModel;
using System.Linq;

using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using MT.OnlineRestaurant.BusinessEntities;
using Microsoft.EntityFrameworkCore;

namespace MT.OnlineRestaurant.DataLayer.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ReviewManagementContext _connection;
        public ReviewRepository(ReviewManagementContext connection)
        {
            _connection = connection;
        }

        public bool EditResturantReview(RestaurantReview restaurantReview)
        {
            try
            {
               // RestaurantReview EditedResult = new RestaurantReview();
                var Users = _connection.TblRating.Where(e => e.TblRestaurantId == restaurantReview.RestaurantId && e.TblCustomerId == restaurantReview.CustomerId).ToList();
                
               // RestaurantReview editedUser = new RestaurantReview();
                if (Users.Count == 0)
                    return false;
                else
                {
                    List<TblRating> usertobeedited= _connection.TblRating.Where(x => x.Id == restaurantReview.Id).ToList();
                    usertobeedited.FirstOrDefault().Rating = (restaurantReview.Rating);
                    usertobeedited.FirstOrDefault().RecordTimeStamp = usertobeedited.FirstOrDefault().RecordTimeStamp;
                    usertobeedited.FirstOrDefault().RecordTimeStampCreated = usertobeedited.FirstOrDefault().RecordTimeStampCreated;
                    usertobeedited.FirstOrDefault().Comments = restaurantReview.Comments;
                    _connection.Update(usertobeedited.FirstOrDefault());
                    _connection.SaveChanges();
                    //editedUser = restaurantReview;

                }
                #region Comments
                //foreach (var User in Users)
                //{
                //    //if (Users.Count == 1)
                //    //{
                //    if (User.Id == restaurantReview.Id)
                //    {
                //        _connection.Entry(
                //            new TblRating
                //            {
                //                Rating = restaurantReview.Rating,
                //                UserModified = restaurantReview.UserModified,
                //                Comments = restaurantReview.Comments,
                //                 RecordTimeStamp=User.RecordTimeStamp,
                //                RecordTimeStampCreated=User.RecordTimeStampCreated}).State = EntityState.Added;
                //    this._connection.TblRating.Add(new TblRating
                //    {
                //        Rating = restaurantReview.Rating,
                //        UserModified = restaurantReview.UserModified,
                //        Comments = restaurantReview.Comments,
                //        RecordTimeStamp = User.RecordTimeStamp,
                //        RecordTimeStampCreated = User.RecordTimeStampCreated
                //    });


                //    _connection.SaveChanges();
                //        // RestaurantReview editedUser = new RestaurantReview() 
                //        editedUser.Comments = restaurantReview.Comments;
                //        editedUser.Id = restaurantReview.Id;
                //        editedUser.Rating = restaurantReview.Rating;
                //        editedUser.CustomerId = restaurantReview.CustomerId;
                //        editedUser.UserCreated = restaurantReview.UserCreated;
                //        editedUser.UserModified = restaurantReview.UserModified;
                //        editedUser.RestaurantId = restaurantReview.RestaurantId ;

                //        return editedUser;
                //    }
                //    //}
                //    //else
                //    //{
                //    //    foreach(var MutliUser in Users)
                //    //    {
                //    //        if(MutliUser.Id==User.Id)
                //    //        {
                //    //            _connection.Entry(User).State = EntityState.Modified;

                //    //            _connection.SaveChanges();
                //    //            RestaurantReview editedUser = new RestaurantReview() { Comments = User.Comments, Id = User.Id, Rating = User.Rating, CustomerId = User.TblCustomerId, UserCreated = User.UserCreated, UserModified = User.UserModified, RestaurantId = User.TblRestaurantId };
                //    //            EditedResult.Add(editedUser);
                //    //            break;
                //    //        }
                //    //    }
                //    //}

                //}
                #endregion
                return true;


                //return EditedResult;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<RestaurantReview> GetResturantReviews(RestaurantReviewParams restaurantReviewParams)
        {
            List<RestaurantReview> ratings = new List<RestaurantReview>();
            try
            {
                var ratingList = _connection.TblRating.Where(e => e.TblRestaurantId == restaurantReviewParams.RestaurantID).ToList();
                foreach (var rating in ratingList)
                {
                    RestaurantReview restaurantReview = new RestaurantReview()
                    {

                        Id = rating.Id,
                        Rating =( rating.Rating),
                        Comments = rating.Comments,
                        RestaurantId = rating.TblRestaurantId,
                        CustomerId = rating.TblCustomerId,
                        UserCreated = rating.UserCreated,
                        UserModified = rating.UserCreated,
            



                    };
                    ratings.Add(restaurantReview);

                }
                return ratings;
            }
            catch (Exception ex)
            {
                return ratings;
            }


        }

        public string PostResturantReview(RestaurantReview restaurantReview)
        {
            try
            {
                _connection.TblRating.Add(new TblRating { TblRestaurantId = restaurantReview.RestaurantId, TblCustomerId = restaurantReview.CustomerId, Rating = restaurantReview.Rating, UserCreated = restaurantReview.UserCreated, UserModified = restaurantReview.UserModified, Comments = restaurantReview.Comments });
                _connection.SaveChanges();
                return "Comments submiited Successfully";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

}
