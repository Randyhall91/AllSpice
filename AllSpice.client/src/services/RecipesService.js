import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorite.js";
import { Recipe } from "../models/Recipe.js"
import { api } from "./AxiosService.js"





class RecipesService {


  async getAllRecipes() {
    const res = await api.get('api/recipes')
    console.log('recipes', res.data);
    AppState.recipes = res.data.map(r => new Recipe(r))
  }

  async getRecipeById(id) {
    const res = await api.get('api/recipes/' + id)
    console.log('recipe', res.data);
    AppState.activeRecipe = new Recipe(res.data)
  }
  async getFavorites() {
    const res = await api.get('/account/favorites/')
    console.log('favorites', res.data);
    AppState.favorites = res.data
  }
  async makeFavorite(recipeId) {
    const res = await api.post('/api/favorites/', { recipeId })
    console.log('favorite', res.data);
    AppState.favorites.push(res.data)
  }
  async removeFavorite(favoriteId) {
    const res = await api.delete('/api/favorites/' + favoriteId)
    AppState.favorites = AppState.favorites.filter(f => f.id != favoriteId)
  }

}

export const recipesService = new RecipesService()