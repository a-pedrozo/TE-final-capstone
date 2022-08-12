<template>
  <l-map
    ref="myMap"
    style="height: 750px; width: 1000px"
    :zoom="zoom"
    :center="center"
    @ready="doSomethingOnReady()"
    v-on:click="testing"
  >
    <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
    <l-circle-marker
      v-for="pothole in $store.state.potholes"
      :lat-lng="pothole.arrayLatLong"
      :key="pothole.id"
      :visible="pothole.isReviewed || $store.state.user.role == 'admin'"
      :color="markerColor(pothole)"
    >
      <l-popup :content="potholeinfo"
        ><router-link
          v-bind:to="{ name: 'PotholeDetails', params: { id: pothole.id } }"
        >
          <p class="id">ID: {{ pothole.id }}</p>
        </router-link>
        <p>{{ pothole.address }}</p>
      </l-popup>
    </l-circle-marker>
  </l-map>
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
  computed: {},
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
.colormaybe {
  color: red;
  background-color: green;
}
</style>