<template>
  <div class="pothole-table">
    <div class="cards" v-for='pothole in $store.state.potholes' v-bind:key='pothole.id'>
        <router-link 
        v-bind:to="{ name: 'PotholeDetails', params: { id: pothole.id } }">
        <p class="id">ID: {{pothole.id}} </p> </router-link>
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
    methods: {
        getListOfPotholes(){
            PotholeService.getPotholes()
                .then(response => {
                    this.$store.commit('LIST_POTHOLES',response.data);
                })
        }
    },
    created() {
        this.getListOfPotholes();
    }

}
</script>

<style>
.cards{
    border: 2px solid black;
    margin: 1rem;
    padding: 2rem;

}
</style>