<template>
  <button
    v-if="$store.state.user.role == 'admin'"
    v-on:click.prevent="reviewPothole()"
  >
    {{
      pothole.isReviewed === false ? "Mark as Reviewed" : "Mark as not Reviewed"
    }}
  </button>
</template>

<script>
import PotholeService from "../services/PotholeService.js";

export default {
  props: ["pothole"],

  methods: {
    reviewPothole() {
      if (this.pothole.isReviewed == false) {
        PotholeService.reviewPothole(this.pothole.id).then(() => {
          this.updateStore();
          this.pothole.isReviewed = true;
        });
      } else if (this.pothole.isReviewed == true) {
        PotholeService.unReviewPothole(this.pothole.id).then(() => {
          this.updateStore();
          this.pothole.isReviewed = false;
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