using Microsoft.EntityFrameworkCore;

namespace MVCBookingFinal_YARAB_.Repositories
{
        public class FavoritesService(ApplicationDbContext context) : IFavoritesService
        {
        public void CreateFavorite(FavoritesViewModel f, string userId)
        {
            if (GetFavoritesByUser(userId).FirstOrDefault(fav => fav.HotelId == f.HotelId) is  null)
            {
                 Favorite favorite = new()
                 {
                     HotelId = f.HotelId,
                     UserId = userId
                 };
                context.Favorites.Add(favorite);
                 context.SaveChanges();
            }
        }


        public void DeleteFavorite(int id)
            {
                var deletedFav = context.Favorites.FirstOrDefault(f => f.Id == id);
                context.Favorites.Remove(deletedFav);
                context.SaveChanges();
            }

            public List<Favorite> GetAllFavorites()
            {
                return context.Favorites.Include(f=>f.Hotel)
                .Include(f => f.User)
                .ToList();
            }

            public Favorite GetFavoriteById(int id)
            {
                return context.Favorites.Include(f=>f.Hotel).FirstOrDefault(f => f.Id == id);
            }
            public List<Favorite> GetFavoritesByUser(string userId)
            {
                var userFavs = context.Favorites.Include(f => f.Hotel).Include(f => f.User)
                .Where(f => f.UserId == userId).ToList();
                return userFavs;
            }
        public IEnumerable<Favorite> GetAllFavoritesWithUsers()
        {
            return context.Favorites
                           .Include(f => f.User)  
                           .Include(f => f.Hotel) 
                           .ToList();
        }

        public void UpdateFavorite(FavoritesViewModel favorite)
        {
            var updatedFav = context.Favorites.FirstOrDefault(f => f.Id == favorite.Id);
            if (updatedFav != null)
            {
                updatedFav.HotelId = favorite.HotelId;
                context.SaveChanges();
            }
        }

    }

}

