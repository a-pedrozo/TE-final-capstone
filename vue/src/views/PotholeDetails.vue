<template>
  <div v-if="pothole">
    <!-- After create hook, when pothole object is populated, Bind the pothole object to each child component so it's available And reactive -->
    <pothole-details :pothole="pothole" />
    <delete-pothole :pothole="pothole" />
    <review-pothole :pothole="pothole" />
    <schedule-repair :pothole="pothole" />
  </div>
</template>

<script>
import PotholeDetails from "@/components/PotholeDetails.vue";
import DeletePothole from "@/components/DeletePothole.vue";
import ReviewPothole from "@/components/ReviewPothole.vue";
import PotholeService from "@/services/PotholeService.js";
import ScheduleRepair from "@/components/ScheduleRepair.vue";


export default {
  name: "PotHoleDetails",
  components: {
    PotholeDetails,
    DeletePothole,
    ReviewPothole,
    ScheduleRepair,
  },
  created() {
    let potholeId = parseInt(this.$route.params.id);

    PotholeService.getPothole(potholeId)
      .then((response) => {
        console.log(response);
        this.pothole = response.data;
        console.log(response.data);
        if (!this.pothole) {
          this.$router.push({ name: "NotFound" });
        }
      })
      .catch((response) => {
        console.error(response);
      });
  },
  data() {
    return {
      pothole: null,
    };
  },
};
</script>

<style>
</style>