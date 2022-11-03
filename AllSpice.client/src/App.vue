<template>
  <!-- <header>
    <Navbar />
  </header> -->
  <main>
    <router-view />
    <RecipeDetailsModal />
    <CreateRecipeModal />
  </main>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import CreateRecipeModal from './components/CreateRecipeModal.vue'
import Navbar from './components/Navbar.vue'
import RecipeDetailsModal from './components/RecipeDetailsModal.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, RecipeDetailsModal, CreateRecipeModal }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
