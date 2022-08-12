<template>
  <div class="pothole-table">
    <h1>View All Potholes</h1>

    <div v-for="pothole in $store.state.potholes" v-bind:key="pothole.id">
      <div
        v-if="pothole.isReviewed || $store.state.user.role == 'admin'"
        class="cards"
      >
        <router-link
          v-bind:to="{ name: 'PotholeDetails', params: { id: pothole.id } }"
        >
          <p class="id">ID: {{ pothole.id }}</p>
        </router-link>
        <p class="date-reported">
          Date Reported: {{ pothole.reportDate.substring(0, 10) }}
        </p>
        <p class="reviewed" v-if="$store.state.user.role == 'admin'">
          Reviewed: {{ pothole.isReviewed == true ? "Yes" : "No" }}
        </p>
        <p class="location-lat-and-long">
          Location (latitude and longitude): {{ pothole.latitude }},
          {{ pothole.longitude }}
        </p>
        <p class="location-address">
          Location (address): {{ pothole.address }}
        </p>
        <p class="city">City: {{ pothole.city }}</p>
        <p class="status">Status: {{ pothole.status }}</p>
      </div>
    </div>
  </div>
</template>

<script>
import PotholeService from "../services/PotholeService.js";

export default {
    methods: {
        updateStore(){
            PotholeService.getPotholes()
                .then(response => {
                    this.$store.commit('LIST_POTHOLES',response.data);
                    console.log(response.data);
                })
        }
    },
    created() {
        this.updateStore();
    }
}

</script>

<style>
.cards {
  border: 2px solid black;
  margin: 1rem;
  padding: 2rem;
  /* background-color: #ede3d9; */
}
.status{
  font-weight: bold;
}
</style>