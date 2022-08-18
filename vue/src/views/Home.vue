<template>
  <div>
    <body class="contents">
      <div class="sweatyholes">
        <div class="header">
          <h3>Known Potholes in Columbus</h3>
        </div>

        <div
          id="potholelist"
          v-for="pothole in filteredPotholes"
          v-bind:key="pothole.id"
        >
            <router-link 
            class="pholeaddress"
            v-bind:to="{ name: 'PotholeDetails', params: {id: pothole.id} }">
            &#8226; {{ pothole.address }}:
            </router-link>
          
          <p
            class="pholestatus"
            v-if="pothole.isReviewed || $store.state.user.role == 'admin'"
          >
            {{ pothole.status }}
          </p>
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
    filteredPotholes() {
      return this.$store.state.potholes.filter((p) => (p.isReviewed || this.$store.state.user.role == "admin"));
  }
},
}


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
  padding-left: 8rem;
  font-size: 20px;
  padding-bottom: 1rem;
  padding-top: 1rem;
}

.contents {
  margin: 2rem;
  display: grid;
  grid-template-columns: 50% 50%;
  height: 100%;
  background-color: #d3fca6;
  background-image: url("https://www.transparenttextures.com/patterns/cartographer.png");
/* This is mostly intended for prototyping; please download the pattern and re-host for production environments. Thank you! */

}

.sweatyholes {
  display: flex;
  flex-direction: column;
  /* margin-left: 5rem; */
  height: 80vh;
  border-radius: 8px;
  backdrop-filter: blur(1px);
  background-color: rgba(255, 255, 255, 0.5);
  box-shadow: 0 1px 18px rgba(0, 0, 0, 0.25);
  border: 1px solid rgba(255, 255, 255, 0.3);
  max-width: 80%;
  overflow-y: scroll;
  overflow-x: hidden;
  margin-top: 1rem;
/* This is mostly intended for prototyping; please download the pattern and re-host for production environments. Thank you! */
  margin-top: 1rem;
}


.header {
  padding-left: 3rem;
  position: sticky;
  top: 0;
  background-color: #1c2915;
  color: white;
  padding: 10px;
  border: 2px solid #1c2915;
}
.pholestatus {
  margin-left: 50px;
}
.pholeaddress {
  font-weight: bold;
}
</style>