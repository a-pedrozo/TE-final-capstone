<template>
  <div>
    <label for="severity">Severity:</label>
    <select name="severity" v-model.number="severity">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        </select>
    <label for="date">Repair Date:</label>
    <input type="date" name="date" v-model="date" />
    <button
      v-if="$store.state.user.role == 'admin'"
      v-on:click.prevent="scheduleRepair()"
      :disabled="!pothole.isReviewed || ((!date || severity < 1) && !pothole.isInspected)"
    >
      {{
        pothole.isInspected === false ? "Schedule Repair" : "Unschedule Repair"
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
      date: "",
      severity: "",
    };
  },

  methods: {
    updateStore() {
      PotholeService.getPotholes().then((response) => {
        this.$store.commit("LIST_POTHOLES", response.data);
      });
    },
    scheduleRepair() {
      this.pothole.repairDate = this.date;
      this.pothole.severity = this.severity;
      console.log("Look here", this.pothole);
      if (this.pothole.isInspected == false) {
        PotholeService.scheduleRepair(this.pothole.id, this.pothole).then(
          () => {
            this.updateStore();
            this.pothole.isInspected = true;
          }
        );
      }
        else if (this.pothole.isReviewed == true) {
            PotholeService.unScheduleRepair(this.pothole.id).then(() => {
                this.updateStore();
            this.pothole.isInspected = false;
            this.pothole.repairDate = null;
            this.pothole.severity = 0;
            this.date = '';
            this.severity = 0;
          });
        }
    }
  }
};
</script>

<style>
</style>