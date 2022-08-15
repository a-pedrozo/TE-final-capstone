<template>
  <div>
    <body class="content">
      <div class="sweatyholes">
        <h3>Hot sweaty holes in your area</h3>
        <div
          id="potholelist"
          v-for="pothole in potholes"
          v-bind:key="pothole.id"
        >
          <ul>
            <li>
              <!--&& !pothole.isRepaired-->
              {{ pothole.address }}: {{ pothole.status }}
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
  computed: {
    potholes() {
      if (this.$store.state.user.role == "admin") {
        return this.$store.state.potholes;
      }
      return this.$store.state.potholes.filter(
        (pothole) => pothole.isReviewed || pothole.isInspected
      );
    },
  },
};
</script>
<style>
body {
  max-width: 100vw;
}

#potholelist {
  display: flex;
  flex-direction: column;
  align-content: center;
}

.content {
  display: grid;
  grid-template-columns: 50% 50%;
}

.sweatyholes {
  display: flex;
  flex-direction: column;
  margin-left: 5rem;
  border-radius: 8px;
  backdrop-filter: blur(20px);
  background-color: rgba(255, 255, 255, 0.5);
  box-shadow: 0 1px 12px rgba(0, 0, 0, 0.25);
  border: 1px solid rgba(255, 255, 255, 0.3);
  max-width: fit-content;
}
</style>