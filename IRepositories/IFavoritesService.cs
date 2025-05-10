namespace MVCBookingFinal_YARAB_.IRepositories
{
    public interface IFavoritesService
    {
        public List<Favorite> GetAllFavorites();
        IEnumerable<Favorite> GetAllFavoritesWithUsers();
        public List<Favorite> GetFavoritesByUser(string userId);
        public Favorite GetFavoriteById(int id);
        public void CreateFavorite(FavoritesViewModel f, string userId);
        public void UpdateFavorite(FavoritesViewModel f);
        public void DeleteFavorite(int id);

    }
}
