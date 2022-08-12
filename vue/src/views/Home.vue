<template>
  <div class="home">

    <header>
      <h1>HoleHuntr Premium <i class="far fa-kiss-wink-heart"></i></h1>
    </header>
    <body>
      <tiny>your next hole awaits...</tiny>
      <div>
       <map-test />
      </div>
    </body>

  </div>
</template>


<script>
import PotholeService from "../services/PotholeService.js"

import MapTest from '../components/MapTest.vue';

export default {
  components: { MapTest },
  created() {
    
      PotholeService.getPotholes().then((response) => {
        this.$store.commit("LIST_POTHOLES", response.data);
      });
    }
};
</script>
<style>

body {
  max-width: 100vw;
}

</style>