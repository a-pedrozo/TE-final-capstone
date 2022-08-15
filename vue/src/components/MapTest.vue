<template>
  <div class="all">
    <l-map
      ref="myMap"
      class="map"
      style="
      min-height: 550px;
      height:80vh
      width: 100vw;
      min-width: 600px;
      border: black solid 2px;
    "
      :zoom="zoom"
      :center="center"
      @ready="doSomethingOnReady()"
      v-on:click="testing"
    >
      <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
      <!-- TODO: evaluate visible condition -->
      <l-circle-marker
        v-for="pothole in validPotholes"
        :lat-lng="pothole.arrayLatLong"
        :key="pothole.id"
        :visible="pothole.isReviewed || $store.state.user.role == 'admin'"
        :color="markerColor(pothole)"
      >
        <l-popup>
          <router-link
            v-bind:to="{ name: 'PotholeDetails', params: { id: pothole.id } }"
          >
            <p class="id">ID: {{ pothole.id }}</p>
          </router-link>
          <p>{{ pothole.address }}</p>
          <p>{{ pothole.status }}</p>
        </l-popup>
      </l-circle-marker>
    </l-map>
    <img class="legend" src="../images/mapLegend.png" />
  </div>
</template>

<script>
import PotholeService from "../services/PotholeService.js";
import { LMap, LCircleMarker, LTileLayer, LPopup } from "vue2-leaflet";
// import { LMarker,} from "vue2-leaflet";
// import { Icon } from 'leaflet';

export default {
  components: {
    // Icon,
    LMap,
    LTileLayer,
    // LMarker,
    LPopup,
    LCircleMarker,
  },
  data() {
    return {
      potholes: [],
      map: null,
      url: "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
      attribution:
        '&copy; <a target="_blank" href="http://osm.org/copyright">OpenStreetMap</a> contributors',
      zoom: 11,
      center: [39.962851, -82.998311],
      circle: {
        radius: 50,
      },
    };
  },
  computed: {
    validPotholes() {
      // TODO: Evaluate this condition
      return this.$store.state.potholes.filter((pothole) => {
        const arrayLatLong = pothole.arrayLatLong;
        const lat = arrayLatLong[0];
        const lng = arrayLatLong[1];
        return !isNaN(lat) && !isNaN(lng);
      });
    },
  },
  methods: {
    markerColor(pothole) {
      if (pothole.isRepaired) {
        return "green";
      } else if (pothole.isInspected) {
        return "yellow";
      } else if (pothole.isReviewed) {
        return "red";
      } else return "black";
    },
    testing(event) {
      console.log(event);
    },
    doSomethingOnReady() {
      this.map = this.$refs.myMap.mapObject;
    },
    makeArrayLatLng(pothole) {
      let array = [];
      array.push(pothole.latitude);
      array.push(pothole.longitude);
      pothole.arrayLatLong = array;
    },
    updateStore() {
      PotholeService.getPotholes().then((response) => {
        this.$store.commit("LIST_POTHOLES", response.data);
        console.log(response.data);
      });
    },
  },
  created() {
    this.updateStore();
    this.potholes = this.$store.state.potholes;
  },
};
</script>

<style>
.all {
  display: flex;
}
.legend {
  position: absolute;
  bottom: 3%;
  right: 0;
  z-index: 1;
  scale: 60%;
}

.map {
  z-index: 0;
}
</style>