<template>
 <button v-on:click.prevent="deletePothole()">Delete</button>
</template>

<script>
import PotholeService from '../services/PotholeService.js';

export default {
 methods: {
        deletePothole(){
            let confirmed = confirm('Are you sure you want to delete this pothole? This cannot be undone.');

            if(confirmed) {
                PotholeService.deletePothole(this.pothole.id)
                    .then(() => {
                        this.$store.commit('DELETE_POTHOLE', this.pothole.id);
                        this.$router.push({name: 'home'});
                    })
            }
        }
    },
    created() {
        let potholeId = parseInt(this.$route.params.id);

        PotholeService.getPothole(potholeId)
        .then(response => {
            this.pothole = response.data;

            if (!this.pothole) {
                this.$router.push({name: 'NotFound'});
            }
        })
        .catch( response => {
            console.error(response);
        })
    }
}
</script>

<style>

</style>