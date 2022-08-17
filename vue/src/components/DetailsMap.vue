<template>
    <l-map
      ref="myMap"
      class="map"
      style="
      height:300px;
      width: 600px;
      border: black solid 2px;
    "
      :zoom="zoom"
      :center="center"
      @ready="doSomethingOnReady()"
    >
      <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
      <l-circle-marker
        :lat-lng="pothole.arrayLatLong"
        :color="markerColor(pothole)"
      >
      </l-circle-marker>
    </l-map>
</template>

<script>
import { LMap, LCircleMarker, LTileLayer, } from "vue2-leaflet";
// import { LMarker,} from "vue2-leaflet";
// import { Icon } from 'leaflet';

export default {
  name: "DetailsMap",
  props: ["pothole"],
  components: {
    // Icon,
    LMap,
    LTileLayer,
    // LMarker,
    LCircleMarker,
  },
  data() {
    return {
      map: null,
      url: "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
      attribution:
        '&copy; <a target="_blank" href="http://osm.org/copyright">OpenStreetMap</a> contributors',
      zoom: 15,
      center: [],
      circle: {
        radius: 50,
      },
    };
  },
  computed: {
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
    doSomethingOnReady() {
      this.map = this.$refs.myMap.mapObject;
    },
    makeArrayLatLng(pothole) {
      let array = [];
      array.push(pothole.latitude);
      array.push(pothole.longitude);
      pothole.arrayLatLong = array;
    },
  },
  created() {
    this.makeArrayLatLng(this.pothole);
    this.center = this.pothole.arrayLatLong;
    console.log("look here plz", this.pothole.arrayLatLong);
        console.log("look here as well plz", this.pothole);
  }
};
</script>

<style>
</style>