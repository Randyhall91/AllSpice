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

    internal List<FavoritedRecipe> GetFavorites(string userId)
    {
      string sql = @"
      SELECT 
      a.*,
      r.*,
      f.id AS favoriteId
      FROM favorites f
      JOIN recipes r ON r.id = f.recipeId
      JOIN accounts a ON a.id = r.creatorId
      WHERE f.accountId = @userId
      ;";
      return _db.Query<Account, FavoritedRecipe, FavoritedRecipe>(sql, (account, recipe) =>
      {
        recipe.Creator = account;
        return recipe;
      }, new { userId }).ToList();
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