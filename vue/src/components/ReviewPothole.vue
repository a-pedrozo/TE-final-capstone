<template>
 <button v-if="$store.state.user.role=='admin'" v-on:click.prevent="reviewPothole()">{{ (pothole.isReviewed === false) ? "Mark as Reviewed" : "Mark as not Reviewed" }}</button>
</template>

<script>
import PotholeService from '../services/PotholeService.js';

export default {
created() {
        let potholeId = parseInt(this.$route.params.id);
        console.log(potholeId);
        PotholeService.getPothole(potholeId)
        .then(response => {
            console.log(response.data);
            this.pothole = response.data;
            this.pothole.isReviewed = response.data.isReviewed;
            console.log(this.isReviewed);
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
        pothole: {
            isReviewed: ''
        }
    }
},
 methods: {
        reviewPothole(){
            if(this.pothole.isReviewed == false) {
                PotholeService.reviewPothole(this.pothole.id)
                .then(() => {   
                    this.updateStore();
                    this.pothole.isReviewed = true;
                })
            } else if (this.pothole.isReviewed == true) {
                PotholeService.unReviewPothole(this.pothole.id) 
                .then(() => {
                    this.updateStore();
                    this.pothole.isReviewed = false;
                })
                }
        },
        updateStore(){
            PotholeService.getPotholes()
                .then(response => {
                    this.$store.commit('LIST_POTHOLES',response.data);
                })
        }
},

}
</script>

<style>

</style>