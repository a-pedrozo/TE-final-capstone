<template>
<div class="update-hole">

  <label class="inspect" name="delete" v-if="pothole.isReviewed">Unable to Delete Reviewed potholes. Unreview to Delete.</label>
<br/>
  <button
    type="button"
    class="btn btn-danger"
    v-if="$store.state.user.role == 'admin'"
    v-on:click.prevent="deletePothole()"
  :disabled="pothole.isReviewed">
    Delete
  </button>
  
  </div>
</template>

<script>
import PotholeService from "../services/PotholeService.js";

export default {
  props: ["pothole"],
  methods: {
    deletePothole() {
      let confirmed = confirm(
        "Are you sure you want to delete this pothole? This cannot be undone."
      );

      if (confirmed) {
        console.log(this.$store.state.user.role);
        PotholeService.deletePothole(this.pothole.id).then(() => {
          this.$store.commit("DELETE_POTHOLE", this.pothole.id);
          this.$router.push({ name: "home" });
        });
      }
    },
  },
};
</script>

<style>

</style>