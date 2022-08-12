<template>

<div>
    <label for="date">Inspection Date:</label>
    <input type="date" name= "date" v-model="date">
    <button 
        name="review" v-if="$store.state.user.role=='admin'" 
        v-on:click.prevent="reviewPothole()"
        :disabled='(!date && !pothole.isReviewed) || pothole.isInspected'
    >
        {{ 
            (pothole.isReviewed === false) ? "Review & Schedule Inspection" : "Unreview & Unschedule Inspection" 
        }}
    </button>
    <label name="review" v-if="pothole.isInspected">Unable to Unreview Inspected potholes. Uninspect to Unreview.</label>
    <label name="review" v-if="!date">Provide an Inspection Date.</label>
</div>

</template>

<script>
import PotholeService from "../services/PotholeService.js";

export default {
  props: ["pothole"],
  data() {
      return {
          date:'',
      }
  },

  methods: {
    reviewPothole() {
        this.pothole.inspectionDate=this.date;
        console.log("Look here", this.pothole);
      if (this.pothole.isReviewed == false) {
          PotholeService.reviewPothole(this.pothole.id, this.pothole).then(() => {
              this.updateStore();
          this.pothole.isReviewed = true;
        });
      } else if (this.pothole.isReviewed == true) {
          PotholeService.unReviewPothole(this.pothole.id).then(() => {
              this.updateStore();
          this.pothole.isReviewed = false;
          this.pothole.inspectionDate = null;
          this.date = '';
        });
      }
    },
    updateStore() {
      PotholeService.getPotholes().then((response) => {
        this.$store.commit("LIST_POTHOLES", response.data);
      });
    },
  },
};

</script>

<style>

</style>