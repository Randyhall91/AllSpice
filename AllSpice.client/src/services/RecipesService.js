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
    AppState.favorites = res.data.map(f => Favorite(f))
  }
  async makeFavorite(id) {
    const res = await api.post('/api/favorite/')
    console.log('favorite', res.data);
    AppState.favorites.push(res.data)
  }


}

export const recipesService = new RecipesService()