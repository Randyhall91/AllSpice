<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12 banner-img m-3">
        <Navbar />
        <div class="banner-title justify-content-center align-content-center d-flex">
          <div class="bg-grey opacity-75 p-3 rounded">
            <h1>All-Spice</h1>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from '../components/Navbar.vue';



export default {
  setup() {
    return {};
  },
  components: { Navbar }
}
</script>

<style scoped lang="scss">
.banner-img {
  background-image: url(https://plus.unsplash.com/premium_photo-1661337223133-a92f4f68d001?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80);
  height: 30vh;
  max-width: 98vw;
}

.banner-title {
  height: 80%;
}

.opacity-75 {
  --bs-bg-opacity: .25;
}


.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
