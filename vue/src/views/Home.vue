<template>
  <div class="home">

    <header>
      <h1>Home</h1>
    </header>
    <body>
      <h1>Hello from home</h1>
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