namespace AllSpice.Models;

public class Recipe
{
  public int id { get; set; }
  public Account Creator { get; set; }
  public string title { get; set; }
  public string instructions { get; set; }
  public string img { get; set; }
  public string category { get; set; }
  public string creatorId { get; set; }

}