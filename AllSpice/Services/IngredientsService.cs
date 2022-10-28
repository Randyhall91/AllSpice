namespace AllSpice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _repo;
    private readonly RecipesService _rs;

    public IngredientsService(IngredientsRepository repo, RecipesService rs)
    {
      _repo = repo;
      _rs = rs;
    }

    internal Ingredient CreateIngredient(Ingredient newIngredient)
    {
      return _repo.CreateIngredient(newIngredient);
    }

    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
      return _repo.GetIngredientsByRecipeId(recipeId);
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
      Ingredient ingredient = _repo.GetIngredientById(ingredientId);
      if (ingredient == null)
      {
        throw new Exception("Ingredient does not exist or bad ID");
      }
      return ingredient;
    }

    internal void DeleteIngredient(int ingredientId, Account userInfo)
    {
      Ingredient ingredient = GetIngredientById(ingredientId);
      Recipe recipe = _rs.GetRecipeById(ingredient.recipeId);
      if (recipe.creatorId != userInfo.Id)
      {
        throw new Exception("Your not allowed to do this..");
      }

      _repo.DeleteIngredient(ingredientId);
    }
  }
}