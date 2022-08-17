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
        pothole.isRepaired === false ? "Mark as Repaired" : "Unmark as Repaired"
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
            this.pothole.status = "Repaired On: " + this.pothole.repairDate.substring(5,7)+ '/' + this.pothole.repairDate.substring(8,10)+'/'+ this.pothole.repairDate.substring(0,4);
            this.pothole.isRepaired = true;
          }
        );
      }
        else if (this.pothole.isRepaired == true) {
            PotholeService.markAsUnrepaired(this.pothole.id).then(() => {
              this.updateStore();
              this.pothole.status = "Inspected On: " + this.pothole.inspectionDate.substring(5,7)+ '/' + this.pothole.inspectionDate.substring(8,10)+'/'+ this.pothole.inspectionDate.substring(0,4);
              this.pothole.isRepaired = false;
          });
        }
    }
  }
};
</script>

<style>
</style>