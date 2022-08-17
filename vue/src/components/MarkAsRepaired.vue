<template>
  <div v-show="pothole.isInspected" class="update-hole">
    <button
    type="button"
    class="btn btn-primary"
      v-if="$store.state.user.role == 'admin'"
      v-on:click.prevent="markAsRepaired()"
      :disabled="!pothole.isInspected"
    >
      {{
        pothole.isRepaired === false ? "Mark as Repaired" : "Cancel Repair"
      }}
    </button>
  </div>
</template>

<script>
import PotholeService from "../services/PotholeService.js";

export default {
  props: ["pothole"],
  data() {
    return {
      isRepaired: "",
    };
  },

  methods: {
    updateStore() {
      PotholeService.getPotholes().then((response) => {
        this.$store.commit("LIST_POTHOLES", response.data);
      });
    },
    markAsRepaired() {
      console.log("Look here", this.pothole);
      if (this.pothole.isRepaired == false) {
        PotholeService.markAsRepaired(this.pothole.id, this.pothole).then(
          () => {
            this.updateStore();
            this.pothole.isRepaired = true;
          }
        );
      }
        else if (this.pothole.isRepaired == true) {
            PotholeService.markAsUnrepaired(this.pothole.id).then(() => {
                this.updateStore();
            this.pothole.isRepaired = false;
          });
        }
    }
  }
};
</script>

<style>
</style>