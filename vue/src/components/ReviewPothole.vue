<template>

<div class="update-hole">
    <div>
    <label class="input-name" for="date">Inspection Date:</label>
    <input class="field" v-if="!pothole.isReviewed" type="date" name= "date" v-model="pothole.inspectionDate">
    <input class="field" v-else type="date" :disabled="noTypeBro" name= "date" v-model="pothole.inspectionDate">
    </div>
    <button 
    class="btn btn-primary"
        name="review" v-if="$store.state.user.role=='admin'" 
        v-on:click.prevent="reviewPothole()"
        :disabled='(!pothole.inspectionDate && !pothole.isReviewed) || pothole.isInspected'
    >
        {{ 
            (pothole.isReviewed === false) ? "Review & Schedule Inspection" : "Cancel Review" 
        }}
    </button>
    <div>
    <label class="inspect" name="review" v-show="!pothole.inspectionDate">Please provide an Inspection Date.</label>
    </div>
    <div>
    <label class="inspect" name="review" v-if="pothole.isInspected">Unable to cancel already inspected potholes. Click cancel to undo review.</label>
    </div>
</div>

</template>

<script>
import PotholeService from "../services/PotholeService.js";

export default {
  props: ["pothole"],
  data() {
      return {
          noTypeBro: true,
      }
  },

  methods: {
    reviewPothole() {
        console.log("Look here", this.pothole);
      if (this.pothole.isReviewed == false) {
          PotholeService.reviewPothole(this.pothole.id, this.pothole).then(() => {
          this.pothole.isReviewed = true;
          this.pothole.status = "Reported On: " + this.pothole.reportDate.substring(5,7)+ '/' + this.pothole.reportDate.substring(8,10)+'/'+ this.pothole.reportDate.substring(0,4);
          this.updateStore();
        });
      } else if (this.pothole.isReviewed == true) {
          PotholeService.unReviewPothole(this.pothole.id).then(() => {
          this.pothole.isReviewed = false;
          this.pothole.inspectionDate = null;
          this.date = '';
          this.pothole.status = "Awaiting Review";
          this.updateStore();
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
  .field{
    margin-left: 5px;
    margin-top: 5px;
    margin-bottom: 5px;
  }
</style>