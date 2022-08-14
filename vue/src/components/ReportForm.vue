<template>
  <div>
    <div class="content">
      <div class="left">
        <h1>Report a Pothole</h1>

        <form v-on:submit.prevent="reportPothole()" class="form">
          <h4>Please tell us where the hole is!</h4>
          <div class="form-info">
            <label for="latitude">Latitude</label>
            <input
              type="text"
              name="latitude"
              v-model="newPothole.latitude"
              v-bind:class="{ test: !newPothole.latitude }"
              placeholder="click on the map to autofill!"
            />
          </div>
          <div class="form-info">
            <label for="longitude">Longitude</label>
            <input
              type="text"
              name="longitude"
              v-model="newPothole.longitude"
              v-bind:class="{ test: !newPothole.longitude }"
              placeholder="click on the map to autofill!"
            />
          </div>
          <div class="form-info">
            <label for="address">Address</label>
            <input type="text" name="address" v-model="newPothole.address" v-bind:class="{ test: !newPothole.address }"
              placeholder="click on the map to autofill!"/>
          </div>
          <div class="form-info">
            <label for="city">City</label>
            <input type="text" name="city" v-model="newPothole.city" v-bind:class="{ test: !newPothole.city }"
              placeholder="click on the map to autofill!" />
          </div>
          <!--<label for="date">Date Reported</label>
        <input type="date" name="date" v-model="newPothole.dateReported">-->
          <input type="submit" id="submitButton" />
        </form>
          <p>
            Your hole will need to be reviewed by an employee before displaying
            on the map
          </p>
      </div>
      <div class="map">
        <l-map
          ref="myMap"
          style="
            
            min-height: 550px;
            height:80vh;
            width: 55vw;
            border: black solid 2px;
            border-radius: 10px;
          "
          :zoom="zoom"
          :center="center"
          @ready="doSomethingOnReady()"
          v-on:click="testing"
        >
          <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
          <l-circle-marker
            v-if="showMarker == true"
            :lat-lng="this.newPothole.arrayLatLong"
          >
          </l-circle-marker>
        </l-map>
      </div>
    </div>
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
      this.newPothole.latitude = event.latlng.lat;
      this.newPothole.longitude = event.latlng.lng;
      array.push(this.newPothole.latitude);
      array.push(this.newPothole.longitude);
      this.newPothole.arrayLatLong = array;
      this.showMarker = true;
      let lat = parseFloat(this.newPothole.latitude);
      let long = parseFloat(this.newPothole.longitude) 
      PotholeService.reverseGeoCode(lat, long).then((response) => {
        console.log(response.data);
        this.newPothole.address = response.data.features[0].properties.address_line1;
        this.newPothole.city = response.data.features[0].properties.city;
      })
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
h1 {
  text-decoration-line: underline;
}
.content {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  column-gap: 1rem;
}
.left {
  width: 100%;
  /* text-align: center; */
  padding: 1rem;
}
.form h4 {
  text-align: center;
  margin: 2rem 0 1rem 0;
}
.left > p {
  font-style: italic;
  margin: 0 0 1rem 0;
  text-align: center;
  font-size: 1.4vmin;
}

.form {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  height: 30rem;
  width: 100%;
}

.left, .map {
  border-radius: 8px;
  border: 1px solid rgba(255, 255, 255, 0.3);
  box-shadow: 0 1px 12px rgba(0, 0, 0, 0.25);
  background-color: rgba(255, 255, 255, 0.5);
  backdrop-filter: blur(20px);
}

.map {
  align-content: right;
}
#submitButton {
  margin: 1rem;
  width: auto;
  font-weight: bold;
  text-align: center;
  padding: 0 0 0 0;
}

.form-info {
  display: flex;
  width: auto;
  margin: 1rem 1rem 1rem 1rem;
  display: flex;
  background-color: rgb(202, 202, 202);
  justify-content: space-between;
  font-size: 1.7vmin;
  border-radius: 5px;

  /* border: red 3px solid; */
}

.form-info label {
  display: flex;
  width: 25%;
  height: 5vh;
  justify-content: flex-end;
  text-align: right;
  align-items: center;
  padding: 0.5rem;
  margin: 0;
  font-weight: bold;
}
.form-info input {
  height: auto;
  width: 75%;
  border-radius: 5px;
  padding: 0 0 0 1rem;
}

.test {
  font-style: italic;
}
</style>