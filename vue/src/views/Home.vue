<template>
  <div>
    <header class="home">
      <h1>Home</h1>
    </header>
    <body class="content">
      <div class="sweatyholes">
        <h3>Hot sweaty holes in your area</h3>
        <div
          id="potholelist"
          v-for="pothole in $store.state.potholes"
          v-bind:key="pothole.id"
        >
          <ul>
            <li v-if="pothole.isReviewed && !pothole.isRepaired || $store.state.user.role == 'admin'">
              table of potholes {{ pothole.id }} {{ pothole.status }}
            </li>
          </ul>
        </div>
      </div>
      <div class="elmap">
        <map-test />
      </div>
    </body>
  </div>
</template>


<script>
import PotholeService from "../services/PotholeService.js";

import MapTest from "../components/MapTest.vue";

export default {
  components: { MapTest },
  created() {
    PotholeService.getPotholes().then((response) => {
      this.$store.commit("LIST_POTHOLES", response.data);
    });
  },
};
</script>
<style>
body {
  max-width: 100vw;
}

.elmap {
  
}

#potholelist {
  display: flex;
  flex-direction: column;
  justify-content: left;
}

.content {
  display: flex;
  flex-direction: row;
}

.sweatyholes {
  display: flex;
  flex-direction: column;
}
</style>