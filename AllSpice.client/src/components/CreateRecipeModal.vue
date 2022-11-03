<template>
  <div class="modal fade" id="createRecipe" tabindex="-1" aria-labelledby="createRecipeLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="createRecipeLabel">Add Your Recipe</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <form @submit.prevent="handleSubmit()">
          <div class="modal-body">
            <div class="input-group mb-3">
              <span class="input-group-text" id="title">Title</span>
              <input type="text" v-model="editable.title" required class="form-control" aria-label="title"
                aria-describedby="title">
            </div>
            <div class="input-group mb-3">
              <span class="input-group-text" id="instructions">Instructions</span>
              <textarea type="text" v-model="editable.instructions" required class="form-control"
                aria-label="instructions" aria-describedby="instructions">
              </textarea>
            </div>
            <div class="input-group mb-3">
              <span class="input-group-text" id="url">ImgUrl</span>
              <input type="url" v-model="editable.img" required class="form-control" aria-label="url"
                aria-describedby="url">
            </div>
            <div class="input-group mb-3">

              <label class="input-group-text" required for="type">Select a Category</label>
              <select class="form-select" v-model="editable.category" id="type">
                <option value="Specialty Coffee">Specialty Coffee</option>
                <option value="Soup">Soup</option>
                <option value="Mexican">Mexican</option>
                <option value="Cheese">Cheese</option>
              </select>

            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="submit" class="btn btn-primary" data-bs-dismiss="modal">Save changes</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

 
<script>
import { ref } from 'vue';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async handleSubmit() {
        try {
          await recipesService.createRecipe(editable.value)
          editable.value = {}
        }
        catch (error) {
          Pop.error('[handleSubmit]', error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>