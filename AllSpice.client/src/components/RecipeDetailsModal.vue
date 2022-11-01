<template>
  <div class="modal fade" id="RecipeDetailsModal" tabindex="-1" aria-labelledby="RecipeDetailsModalLabel"
    aria-hidden="true">
    <div class="modal-dialog modal-xl modal-dialog-centered">
      <div class="modal-content">
        <div v-if="activeRecipe" class="modal-body p-0 container">
          <div class="row">
            <div class="col-4 img">
              <img :src="activeRecipe.img" class="img-fluid" alt="">
              <div class="text-light">

                <div v-if="favorite" class="favorite px-2 selectable" @click="removeFavorite">
                  <i class="mdi mdi-heart text-danger fs-1"></i>
                </div>
                <div v-else class="favorite px-2 rounded-bottom selectable" @click="makeFavorite">
                  <i class="mdi mdi-heart-outline fs-1"></i>
                </div>
              </div>
            </div>
            <div class="col-8">
              <div class="close">
                <i class="mdi mdi-close selectable fs-3 text-danger" data-bs-dismiss="modal"></i>
              </div>

              {{ activeRecipe.instructions }}
            </div>
          </div>
        </div>
        <!-- <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary">Save changes</button>
        </div> -->
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    return {
      activeRecipe: computed(() => AppState.activeRecipe),
      favorite: computed(() => AppState.favorites.find(f => f.id == AppState.activeRecipe.id)),
      async makeFavorite() {
        try {
          await recipesService.makeFavorite(this.activeRecipe.id);
        }
        catch (error) {
          Pop.error('[makeFavorite]', error)
        }
      },
      async removeFavorite() {
        try {
          await recipesService.removeFavorite(this.favorite.favoriteId);
        }
        catch (error) {
          Pop.error('[removeFavorite]', error)
        }
      }

    }
  }
}
</script>


<style lang="scss" scoped>
.img {
  position: relative;
}

.favorite {
  // opacity: .25;
  background-color: rgba(126, 126, 126, 0.8);
  position: absolute;
  right: 2rem;
  top: 0;

}

.close {
  position: absolute;
  right: 5px;
  top: 0;
}
</style>