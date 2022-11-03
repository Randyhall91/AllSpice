<template>
  <div class="container-fluid">
    <div class="row p-3">
      <div class="col-12 banner-img">
        <Navbar />
        <div class="banner-title justify-content-center align-content-center d-flex text-light">
          <div class="bg-grey bg-opacity-25 p-3 rounded">
            <h1>All-Spice</h1>
            <h5>Cherish Your Family</h5>
            <h5>and Their Cooking</h5>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div v-for="recipe in recipes" class="col-lg-4 p-5">
        <RecipeCard key="recipe.id" :recipe="recipe" />

      </div>
    </div>
    <div class="create">
      <i class="mdi mdi-plus-circle fs-1 text-primary selectable" data-bs-toggle="modal"
        data-bs-target="#createRecipe"></i>
    </div>
  </div>
</template>

<script>
import Navbar from '../components/Navbar.vue';
import Pop from '../utils/Pop.js';
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import { recipesService } from '../services/RecipesService.js'
import { onMounted, watchEffect } from 'vue';
import RecipeCard from '../components/RecipeCard.vue';


export default {
  setup() {
    onMounted(() => {
      getAllRecipes();
    })
    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes();
      } catch (error) {
        Pop.error(error, '[GetallREcipies]')
      }
    }
    watchEffect(() => {
      AppState.favorites
    })
    return {
      recipes: computed(() => AppState.recipes),
    };
  },
  components: { Navbar, RecipeCard }
}
</script>

<style scoped lang="scss">
.banner-img {
  background-image: url(https://plus.unsplash.com/premium_photo-1661337223133-a92f4f68d001?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80);
  height: 30vh;
  max-width: 97vw;
}

.banner-title {
  height: 80%;
}

.opacity-75 {
  --bs-bg-opacity: .25;
}

.create {
  position: fixed;
  bottom: .5rem;
  right: 1rem;
}
</style>
