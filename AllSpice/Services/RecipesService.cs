namespace AllSpice.Services
{
  public class RecipesService
  {
    private readonly RecipeRepository _repo;

    public RecipesService(RecipeRepository repo)
    {
      _repo = repo;
    }

    internal Recipe CreateRecipe(Recipe newRecipe)
    {
      return _repo.CreateRecipe(newRecipe);
    }

    internal List<Recipe> GetAllRecipes()
    {
      return _repo.GetAllRecipes();
    }

    internal Recipe GetRecipeById(int recipeId)
    {
      Recipe recipe = _repo.getRecipeById(recipeId);
      if (recipe == null)
      {
        throw new Exception("Recipe does not exist");
      }
      return recipe;
    }

    internal Recipe UpdateRecipe(Recipe updatedRecipe, String userInfoId)
    {
      Recipe recipe = GetRecipeById(updatedRecipe.id);
      if (recipe == null)
      {
        throw new Exception("Invalid recipe ID");
      }
      if (recipe.creatorId != userInfoId)
      {
        throw new Exception("You can't update this its not yours");
      }
      recipe.title = updatedRecipe.title == null ? recipe.title : updatedRecipe.title;
      recipe.instructions = updatedRecipe.instructions == null ? recipe.instructions : updatedRecipe.instructions;
      recipe.img = updatedRecipe.img == null ? recipe.img : updatedRecipe.img;
      recipe.category = updatedRecipe.category == null ? recipe.category : updatedRecipe.category;

      _repo.updateRecipe(recipe);
      return recipe;
    }

    internal void DeleteRecipe(Account userInfo, int recipeId)
    {
      Recipe recipe = GetRecipeById(recipeId);
      if (recipe == null)
      {
        throw new Exception("Invalid recipe ID");
      }
      if (recipe.creatorId != userInfo.Id)
      {
        throw new Exception("You can't update this its not yours");
      }



      _repo.DeleteRecipe(recipeId);
    }
  }
}