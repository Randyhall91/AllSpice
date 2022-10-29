namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FavoritesController : ControllerBase
  {
    private readonly Auth0Provider _auth0provider;
    private readonly FavoritesService _fs;

    public FavoritesController(Auth0Provider auth0provider, FavoritesService fs)
    {
      _auth0provider = auth0provider;
      _fs = fs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite newFav)
    {
      try
      {
        Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
        newFav.accountId = userInfo.Id;
        Favorite favorite = _fs.CreateFavorite(newFav);
        return Ok(newFav);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{favoriteId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteFavorite(int favoriteId)
    {
      try
      {
        Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
        _fs.DeleteFavorite(userInfo, favoriteId);
        return Ok("Delete Successful");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}