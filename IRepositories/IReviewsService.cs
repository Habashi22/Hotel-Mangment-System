using Microsoft.AspNetCore.Mvc;

namespace MVCBookingFinal_YARAB_.IRepositories
{
    public interface IReviewsService
    {
        public List<Review> GetAllReview();
        public List<Review> GetReviewByUser(string userId);
        public Review GetReviewById(int id);
        public void CreateReview(ReviewViewModel r, string userId);
        public void UpdateReview(ReviewViewModel r);
        public void DeleteReview(int id);

        public void GetTopReviews();
        public List<Review> GetReviewByHotel(int Id);
    }
}
