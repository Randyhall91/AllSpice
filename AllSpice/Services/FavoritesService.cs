namespace AllSpice.Services
{
  public class FavoritesService
  {
    private readonly FavoritesRepository _repo;

    public FavoritesService(FavoritesRepository repo)
    {
      _repo = repo;
    }

    internal Favorite CreateFavorite(Favorite newFav)
    {
      return _repo.CreateFavorite(newFav);
    }

    internal List<FavoritedRecipe> GetFavorites(string userId)
    {
      return _repo.GetFavorites(userId);
    }
    internal Favorite GetFavoriteById(int favoriteId)
    {
      Favorite favorite = _repo.GetFavoriteById(favoriteId);
      if (favorite == null)
      {
        throw new Exception("favorite not found");
      }
      return favorite;
    }

    internal void DeleteFavorite(Account userInfo, int favoriteId)
    {
      Favorite favorite = GetFavoriteById(favoriteId);
      if (favorite.accountId != userInfo.Id)
      {
        throw new Exception("You can't delete a favorite thats not yours.");
      }
      _repo.DeleteFavorite(favoriteId);
    }
  }
}