<template>
  <div class="recipe-card mt-3 p-3 text-light selectable elevation-5" :style="{ backgroundImage: `url(${recipe.img})` }"
    @click="getRecipeById()" data-bs-toggle="modal" data-bs-target="#RecipeDetailsModal">
    <!-- <img class="card-img-top img-fluid selectable" @click="getRecipeById()" data-bs-toggle="modal"
        data-bs-target="#RecipeDetailsModal" :src="recipe.img" alt="Title"> -->
    <!-- <section class="category bg-grey d-flex"> -->
    <h5 class="category p-2 rounded">{{ recipe.category }}</h5>
    <!-- </section> -->
    <div v-if="favorites.length" class="favorite px-2 rounded-bottom">
      <i class="mdi mdi-heart text-danger fs-3"></i>
    </div>
    <div v-else class="favorite px-2 rounded-bottom">
      <i class="mdi mdi-heart-outline fs-3"></i>
    </div>
    <div class="info p-2 rounded">
      <h4 class="card-title">{{ recipe.title }}</h4>
      <p class="card-text">{{ recipe.instructions }}</p>
    </div>

  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import { Recipe } from '../models/Recipe.js';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';

export default {
  props: {
    recipe: { type: Recipe, required: true }
  },
  setup(props) {
    return {
      favorites: computed(() => AppState.favorites.filter(f => f.id == props.recipe.id)),


      async getRecipeById() {
        try {
          await recipesService.getRecipeById(props.recipe.id)
        }
        catch (error) {
          Pop.error('[getRecipeById]', error)
        }
      },

    }
  }
}

</script>


<style lang="scss" scoped>
.favorite {
  background-color: rgba(126, 126, 126, 0.8);
  position: absolute;
  right: 1rem;
  top: 0;
}

.category {
  background-color: rgba(126, 126, 126, 0.8);
  position: absolute;
  left: 1rem;
  top: .5rem;
}

.info {
  background-color: rgba(126, 126, 126, 0.8);
  position: absolute;
  left: 1rem;
  bottom: .5rem;
  max-width: 90%;
}

.recipe-card {
  height: 35vh;
  background-position: center;
  background-size: cover;
}
</style>