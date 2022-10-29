namespace AllSpice.Repositories
{
  public class FavoritesRepository : BaseRepository
  {
    public FavoritesRepository(IDbConnection db) : base(db)
    {
    }

    internal Favorite CreateFavorite(Favorite newFav)
    {
      string sql = @"
      INSERT INTO favorites(accountId, recipeId)
      VALUES(@AccountId, @RecipeId);
      SELECT LAST_INSERT_ID()
      ;";
      int favoriteId = _db.ExecuteScalar<int>(sql, newFav);
      newFav.id = favoriteId;
      return newFav;
    }

    internal List<Favorite> GetFavorites(Account userInfo)
    {
      string sql = @"
      SELECT 
      f.*,
      r.*
      FROM favorites f
      JOIN recipes r ON r.id = f.recipeId
      WHERE f.accountId = @id
      ;";
      return _db.Query<Favorite, Recipe, Favorite>(sql, (favorite, recipes) =>
      {
        favorite.recipeId = recipes.id;
        favorite.accountId = userInfo.Id;
        return favorite;
      }, userInfo).ToList();
    }

    internal void DeleteFavorite(int favoriteId)
    {
      string sql = "DELETE FROM favorites WHERE id = @favoriteId;";
      var rowsAffected = _db.Execute(sql, new { favoriteId });
      if (rowsAffected == 0)
      {
        throw new Exception("Delete Failed");
      }
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
      string sql = @"
      SELECT 
      *
      FROM favorites
      WHERE id = @favoriteId
      ;";
      return _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
    }
  }
}