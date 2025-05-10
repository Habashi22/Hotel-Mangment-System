using Microsoft.EntityFrameworkCore;
using MVCBookingFinal_YARAB_.IRepositories;

namespace MVCBookingFinal_YARAB_.Repositories
{
        public class ReviewsService(ApplicationDbContext context) : IReviewsService
        {
        public void CreateReview(ReviewViewModel r, string userId)
        {
            var hotel = context.Hotels.FirstOrDefault(h => h.id == r.HotelId);
            

            Review review = new()
            {
                HotelId = r.HotelId,
                Hotel = hotel,       
                UserId = userId,    
                Rating = r.Rating,
                Description = r.Description,
                ReviewDate = DateTime.Now
            };

            context.Reviews.Add(review);
            context.SaveChanges();
        }

        public void DeleteReview(int id)
            {
                var deletedReview = context.Reviews.FirstOrDefault(r => r.Id == id);
            deletedReview.isDeleted = true;

            //context.Reviews.Remove(deletedReview);
            context.SaveChanges();
        }


            public List<Review> GetAllReview()
            {
                return context.Reviews.Where(r => !r.isDeleted).Include(h=>h.Hotel).Include(u=>u.User).ToList();
                
                
            }

            public Review GetReviewById(int id)
            {
                return context.Reviews.FirstOrDefault(r => r.Id == id);
            }

            public List<Review> GetReviewByUser(string userId)
            {

                //var userReviews = context.Reviews.Include(r => r.Hotel).Where(r => r.UserId == userId && !r.isDeleted).ToList();

                var userReviews = context.Reviews.Include(r => r.Hotel).Include(r=>r.User).Where(r => r.UserId == userId && !r.isDeleted).ToList();

                return userReviews;
            }
        public List<Review> GetReviewByHotel(int Id)
        {
            var userReviews = context.Reviews.Include(r => r.Hotel).Where(r => r.HotelId == Id&& !r.isDeleted).ToList();
            return userReviews;
        }

        public void GetTopReviews()
        {
            var reviews =  context.Reviews
         .Include(r => r.User)
         .OrderByDescending(r => r.Rating) 
         .Take(5)
         .Select(r => new ReviewViewModel2
         {
             UserName = r.User.UserName,
             Rating=r.Rating,
             Description = r.Description
         })
         .ToList();
        }

        public void UpdateReview(ReviewViewModel reviewVM)
            {
                var updatedReview = context.Reviews.FirstOrDefault(r => r.Id == reviewVM.Id);
                if (updatedReview == null)
                {
                    return;

                }

                updatedReview.Rating = reviewVM.Rating;
                updatedReview.Description = reviewVM.Description;
          

                context.SaveChanges();
            }
        
    }

}

