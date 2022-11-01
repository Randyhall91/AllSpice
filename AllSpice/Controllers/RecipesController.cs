namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;
  private readonly RecipesService _rs;
  private readonly IngredientsService _is;

  public RecipesController(Auth0Provider auth0provider, RecipesService rs, IngredientsService iss)
  {
    _auth0provider = auth0provider;
    _rs = rs;
    _is = iss;
  }



  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe newRecipe)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newRecipe.creatorId = userInfo.Id;
      Recipe createdRecipe = _rs.CreateRecipe(newRecipe);
      return Ok(createdRecipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet]
  public ActionResult<List<Recipe>> GetAllRecipes()
  {
    try
    {
      List<Recipe> recipes = _rs.GetAllRecipes();
      return Ok(recipes);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{recipeId}")]

  public ActionResult<Recipe> GetRecipeById(int recipeId)
  {
    try
    {
      Recipe recipe = _rs.GetRecipeById(recipeId);
      return Ok(recipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("{recipeId}/ingredients")]
  public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(int recipeId)
  {
    try
    {
      List<Ingredient> ingredients = _is.GetIngredientsByRecipeId(recipeId);
      return Ok(ingredients);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }



  [HttpPut("{recipeId}")]
  [Authorize]
  public async Task<ActionResult<Recipe>> UpdateRecipe([FromBody] Recipe updatedRecipe, int recipeId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      updatedRecipe.id = recipeId;
      Recipe recipe = _rs.UpdateRecipe(updatedRecipe, userInfo.Id);
      return Ok(recipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{recipeId}")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteRecipe(int recipeId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _rs.DeleteRecipe(userInfo, recipeId);
      return Ok("Delete Successful");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


}
