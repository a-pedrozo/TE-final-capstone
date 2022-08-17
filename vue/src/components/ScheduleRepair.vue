<template>
  <div v-show="pothole.isReviewed" class="update-hole">
    
    <label class="input-name" v-if="!pothole.isInspected" for="severity">Severity: </label>

    <br />

    <select v-if="!pothole.isInspected" name="severity" v-model.number="severity">
        <option value="0"></option>
        <option value="1">Low</option>
        <option value="2">Medium</option>
        <option value="3">High</option>
        </select>

        <br />
<br/>
    <label class="input-name" for="date">Repair Date:</label>

    <br />
    <input type="date" v-if="!pothole.isInspected" name="date" v-model="pothole.repairDate" />
    <input type="date" v-else :disabled="noTypeBro" name="date" v-model="pothole.repairDate" />
    <br/>
    <button name="inspect"
      v-if="$store.state.user.role == 'admin'"
      v-on:click.prevent="scheduleRepair()"
      :disabled="!pothole.isReviewed || ((!pothole.repairDate || severity < 1) && !pothole.isInspected) || pothole.isRepaired"
    >
      {{
        pothole.isInspected === false ? "Inspect & Schedule Repair" : "Uninspect & Unschedule Repair"
      }}
    </button>
    <br />
    <div class="inspect">
        <label name="inspect" v-if="pothole.isRepaired">Unable to Uninspect Repaired potholes. Unrepair to Uninspect.</label>
        <br />
        <label name="inspect" v-if="(!pothole.isInspected && (!pothole.repairDate && severity < 1))">Provide a Severity and Repair Date.</label>
        <label name="inspect" v-else-if="(!pothole.isInspected && (severity < 1))">Provide a Severity.</label>
        <label name="inspect" v-else-if="(!pothole.isInspected && (!pothole.repairDate))">Provide a Repair Date.</label>
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
      this.pothole.severity = this.severity;
      console.log("Look here", this.pothole);
      if (this.pothole.isInspected == false) {
        PotholeService.scheduleRepair(this.pothole.id, this.pothole).then(
          () => {
            this.updateStore();
            this.pothole.status = "Inspected On: " + this.pothole.inspectionDate.substring(5,7)+ '/' + this.pothole.inspectionDate.substring(8,10)+'/'+ this.pothole.inspectionDate.substring(0,4);
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
            this.severity = 0;
            this.pothole.status = "Reported On: " + this.pothole.reportDate.substring(5,7)+ '/' + this.pothole.reportDate.substring(8,10)+'/'+ this.pothole.reportDate.substring(0,4);
          });
        }
    }
  }
};
</script>

<style>
  .inspect{
    font-style: italic;
  }
</style>