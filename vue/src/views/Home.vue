<template>
  <div>
    <body class="contents">
      <div class="sweatyholes">
        <h3>Hot sweaty holes in your area</h3>
        <div>
          <div
            id="potholelist"
            v-for="pothole in $store.state.potholes"
            v-bind:key="pothole.id"
          >
            <p v-if="pothole.isReviewed || $store.state.user.role == 'admin'">
              <!--&& !pothole.isRepaired-->
              &#8226; {{ pothole.address }}: {{ pothole.status }}
            </p>
          </div>
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
  height: 100%;
}

#potholelist {
  display: flex;
  flex-direction: column;
  align-content: center;
}

.contents {
  margin: 2rem;
  display: grid;
  grid-template-columns: 50% 50%;
  background-color: #cfddc4;
  height: 100%;
}

.sweatyholes {
  padding: 1rem;
  display: flex;
  flex-direction: column;
  /* margin-left: 5rem; */
  height: 80vh;
  border-radius: 8px;
  backdrop-filter: blur(20px);
  background-color: rgba(255, 255, 255, 0.5);
  box-shadow: 0 1px 18px rgba(0, 0, 0, 0.25);
  border: 1px solid rgba(255, 255, 255, 0.3);
  max-width: 80%;
}
.elmap {
  /* padding-right: 5rem; */
}
</style>