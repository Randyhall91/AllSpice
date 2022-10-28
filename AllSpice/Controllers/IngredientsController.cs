namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class IngredientsController : ControllerBase
  {
    private readonly Auth0Provider _auth0provider;
    private readonly IngredientsService _is;

    public IngredientsController(Auth0Provider auth0provider, IngredientsService @is)
    {
      _auth0provider = auth0provider;
      _is = @is;
    }
    [HttpPost]
    [Authorize]
    public ActionResult<Ingredient> CreateIngredient([FromBody] Ingredient newIngredient)
    {
      try
      {
        Ingredient ingredient = _is.CreateIngredient(newIngredient);
        return Ok(ingredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{ingredientId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteIngredient(int ingredientId)
    {
      try
      {
        Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
        _is.DeleteIngredient(ingredientId, userInfo);
        return Ok("Delete Successful");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}