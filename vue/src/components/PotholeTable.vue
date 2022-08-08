<template>
  <div>
    <div v-for='pothole in this.$store.state.potholes' v-bind:key='pothole.id'>
        {{pothole.id}}, {{pothole.dateReported.substring(0,10)}}, {{pothole.severity}}, {{pothole.latitude}}, {{pothole.longitude}}, {{pothole.address}},{{pothole.city}}
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

</style>