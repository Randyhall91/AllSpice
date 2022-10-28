namespace AllSpice.Repositories


{
  public class RecipeRepository : BaseRepository
  {
    public RecipeRepository(IDbConnection db) : base(db)
    {
    }

    internal Recipe CreateRecipe(Recipe newRecipe)
    {
      string sql = @"
      INSERT INTO recipes(title, instructions, img, category, creatorId)
      VALUES(@Title, @Instructions, @Img, @Category, @CreatorId);
      SELECT LAST_INSERT_ID()
      ;";
      int recipeId = _db.ExecuteScalar<int>(sql, newRecipe);
      newRecipe.id = recipeId;
      return newRecipe;
    }

    internal Recipe getRecipeById(int recipeId)
    {
      string sql = @"
      SELECT 
      r.*,
      a.*
      FROM recipes r
      JOIN accounts a ON a.id = r.creatorId
      WHERE r.id = @recipeId
      ;";
      return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
      {
        recipe.Creator = account;
        return recipe;
      }, new { recipeId }).FirstOrDefault();
    }

    internal void updateRecipe(Recipe updatedRecipe)
    {
      string sql = @"
        UPDATE recipes
        SET
            title = @title,
            instructions = @instructions,
            img = @img,
            category = @category
        WHERE id = @id
      ;";
      var rowsaffected = _db.Execute(sql, updatedRecipe);
      if (rowsaffected == 0)
      {
        throw new Exception("unable to update recipe");
      }
    }

    internal List<Recipe> GetAllRecipes()
    {
      string sql = @"
      SELECT
      r.*,
      a.*
      FROM recipes r
      JOIN accounts a ON a.id = r.creatorId
      ;";
      return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
      {
        recipe.Creator = account;
        return recipe;
      }).ToList();
    }

    internal void DeleteRecipe(int id)
    {
      string sql = @"DELETE FROM recipes WHERE id = @id;";
      var rowsAffected = _db.Execute(sql, new { id });
      if (rowsAffected == 0)
      {
        throw new Exception("Unable to Delete");
      }
    }
  }
}