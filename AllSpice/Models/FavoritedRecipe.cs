namespace AllSpice.Models;

public class FavoritedRecipe : Recipe
{
  public int favoriteId { get; set; }
  public int recipeId { get; set; }
}