namespace AllSpice.Repositories
{
  public class IngredientsRepository : BaseRepository
  {
    public IngredientsRepository(IDbConnection db) : base(db)
    {
    }

    internal Ingredient CreateIngredient(Ingredient newIngredient)
    {
      string sql = @"
      INSERT INTO ingredients(name, quantity, recipeId)
      VALUES(@Name, @Quantity, @RecipeId);
      SELECT LAST_INSERT_ID()
      ;";
      int ingredientId = _db.ExecuteScalar<int>(sql, newIngredient);
      newIngredient.id = ingredientId;
      return newIngredient;
    }

    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
      string sql = @"
        SELECT *
        FROM ingredients
        WHERE recipeId = @recipeId
      ;";
      return _db.Query<Ingredient>(sql, new { recipeId }).ToList();
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
      string sql = @"
        SELECT *
        FROM ingredients
        WHERE id = @ingredientId
      ;";
      return _db.Query<Ingredient>(sql, new { ingredientId }).FirstOrDefault();
    }

    internal void DeleteIngredient(int ingredientId)
    {
      string sql = "DELETE FROM ingredients WHERE id = @ingredientId";
      var rowsAffected = _db.Execute(sql, new { ingredientId });
      if (rowsAffected == 0)
      {
        throw new Exception("Unable to Delete");
      }
    }
  }
}