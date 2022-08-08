<template>
  <div>
      <h1> Report a Pothole </h1>
    <form v-on:submit.prevent="reportPothole()" class="form"> 
        <label for="latitude">Latitude</label>
        <input type="text" name="latitude" v-model="newPothole.latitude">
        <label for="longitude">Longitude</label>
        <input type="text" name="longitude" v-model="newPothole.longitude">
        <label for="address">Address</label>
        <input type="text" name="address" v-model="newPothole.address">
        <label for="city">City</label>
        <input type="text" name="city" v-model="newPothole.city">
        <label for="date">Date Reported</label>
        <input type="date" name="date" v-model="newPothole.dateReported">
        <input type="submit" id="submitButton">
    </form>

  </div>
</template>

<script>
import PotholeService from '../services/PotholeService.js';

export default {
data(){
    return{
        newPothole: {
            latitude: '',
            longitude: '',
            city: '',
            address: '',
            dateReported: '',
            severity: 0,
        }
    }
},
computed: {
    dateToday(){
        let month = Date.getMonth();
        let day = Date.getDate();
        let year = Date.getFullYear();

        return year + month + day;
    }
},
methods:{
    reportPothole(){
        // this.newPothole.dateReported = this.dateToday();
        // console.log(this.dateToday());
        PotholeService.reportPothole(this.newPothole)
        .then((response) => {
            this.$store.commit('REPORT_POTHOLE', response.data);
            this.$router.push({name: 'home'})
            })
        }
    }
}
</script>

<style>
.form{
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    height: 75%;
    
}
#submitButton{
    margin: 2rem;
    width: 100px;
}
</style>