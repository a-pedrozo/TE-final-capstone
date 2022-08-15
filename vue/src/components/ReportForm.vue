<template>
  <div>
    <h1>Report a Pothole</h1>
    <form v-on:submit.prevent="reportPothole()" class="form">
      <label for="latitude">Latitude</label>
      <input type="text" name="latitude" v-model="newPothole.latitude" />
      <label for="longitude">Longitude</label>
      <input type="text" name="longitude" v-model="newPothole.longitude" />
      <label for="address">Address</label>
      <input type="text" name="address" v-model="newPothole.address" />
      <label for="city">City</label>
      <input type="text" name="city" v-model="newPothole.city" />
      <!--<label for="date">Date Reported</label>
        <input type="date" name="date" v-model="newPothole.dateReported">-->
      <input type="submit" id="submitButton" />
    </form>

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
        v-if="showMarker == true"
        :lat-lng="this.newPothole.arrayLatLong"
        :color="red"
      >
      </l-circle-marker>
    </l-map>
  </div>
</template>

<script>
import PotholeService from "../services/PotholeService.js";
import { LMap, LTileLayer, LCircleMarker } from "vue2-leaflet";
export default {
  components: {
    LMap,
    LTileLayer,
    LCircleMarker,
  },
  data() {
    return {
      newPothole: {
        latitude: "",
        longitude: "",
        city: "",
        address: "",
        severity: 0,
        showMarker: "false",
        arrayLatLong: [],
      },
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
    dateToday() {
      let d = new Date();
      let month = d.getMonth() + 1;
      let day = d.getDate();
      let year = d.getFullYear();

      return year + "-" + month + "-" + day;
    },
  },
  methods: {
    reportPothole() {
      //this.newPothole.dateReported = this.dateToday;
      this.newPothole.latitude = this.newPothole.latitude.toString();
      this.newPothole.longitude = this.newPothole.longitude.toString();
      PotholeService.reportPothole(this.newPothole).then((response) => {
        this.$store.commit("REPORT_POTHOLE", response.data);
        this.$router.push({ name: "AllPotholes" });
      });
    },
    testing(event) {
      let array = [];
      // TODO: make sure the lat and long are numbers
      this.newPothole.latitude = event.latlng.lat;
      this.newPothole.longitude = event.latlng.lng;
      array.push(this.newPothole.latitude);
      array.push(this.newPothole.longitude);
      this.newPothole.arrayLatLong = array;
      this.showMarker = true;
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
};
</script>

<style>
.form {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  height: 75%;
}
#submitButton {
  margin: 2rem;
  width: 100px;
}
</style>