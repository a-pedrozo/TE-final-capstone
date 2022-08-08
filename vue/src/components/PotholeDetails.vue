<template>
    <div>
        <div v-if="pothole">
            <p class="id">ID: {{pothole.id}} </p>
            <p class="date-reported">Date Reported: {{pothole.dateReported.substring(0,10)}}</p>
            <p class="severity">Severity: {{pothole.severity}}</p>
            <p class="location-lat-and-long">Location (latitude and longitude): {{pothole.latitude}}, {{pothole.longitude}}</p>
            <p class="location-address">Location (address): {{pothole.address}}</p>
            <p class="city">City: {{pothole.city}}</p>
        </div>
    </div>
</template>

<script>
import PotholeService from '../services/PotholeService.js';

export default {
created() {
    let potholeId = parseInt(this.$route.params.id);

    PotholeService.getPothole(potholeId)
    .then(response => {
        console.log(response)
        this.pothole = response.data;

        if (!this.pothole) {
            this.$router.push({name: 'NotFound'});
        }
    })
    .catch( response => {
        console.error(response);
    })
    },
data() {
    return {
        pothole: undefined
    }
}
}

</script>

<style>

</style>