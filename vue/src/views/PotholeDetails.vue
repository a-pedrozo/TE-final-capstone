<template>
  <div>
    <div v-if="pothole" class="details-all">
      <div class="left-side">
        <pothole-details :pothole="pothole" class="details-page" />
        <div class="form-buttons">
          <h5>Update Hole</h5>
          <!-- After create hook, when pothole object is populated, Bind the pothole object to each child component so it's available And reactive -->
          <delete-pothole :pothole="pothole" />
          <review-pothole :pothole="pothole" />
          <schedule-repair :pothole="pothole" />
          <mark-as-repaired :pothole="pothole" />
        </div>
      </div>
      <div class="right-side">
        <img
          class="image"
          src="https://media.istockphoto.com/photos/pot-hole-picture-id174662203?k=20&m=174662203&s=612x612&w=0&h=pcvejYWQ1S43k-VG4J5x36ikro37hRzQS-Ms7Lmgwkw="
          alt="pothole in the road"
        />
      </div>
      <!-- <pothole-images-carousel class="pics"/> -->
    </div>
  </div>
</template>

<script>
import PotholeDetails from "@/components/PotholeDetails.vue";
import DeletePothole from "@/components/DeletePothole.vue";
import ReviewPothole from "@/components/ReviewPothole.vue";
import PotholeService from "@/services/PotholeService.js";
import ScheduleRepair from "@/components/ScheduleRepair.vue";
import MarkAsRepaired from "@/components/MarkAsRepaired.vue";

//import { LMap, LTileLayer } from "vue2-leaflet";
// import PotholeImagesCarousel from '@/components/PotholeImagesCarousel.vue';

export default {
  name: "PotHoleDetails",
  components: {
    PotholeDetails,
    DeletePothole,
    ReviewPothole,
    ScheduleRepair,
    MarkAsRepaired,

    // PotholeImagesCarousel,
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
  methods: {},
};
</script>

<style>
.details-all {
  display: flex;
  flex-wrap: nowrap;
  width: 100%;
}
.left-side {
  width: auto;
}

.details-page,
.form-buttons {
  padding: 1rem;
  border-radius: 8px;
  border: 1px solid rgba(255, 255, 255, 0.3);
  box-shadow: 0 1px 12px rgba(0, 0, 0, 0.25);
  background-color: rgba(255, 255, 255, 0.5);
  backdrop-filter: blur(20px);
  margin: 1rem;
}
.image {
  border-radius: 8px;
  border: 1px solid rgba(255, 255, 255, 0.3);
  box-shadow: 0 1px 12px rgba(0, 0, 0, 0.25);
  background-color: rgba(255, 255, 255, 0.5);
  backdrop-filter: blur(20px);
  margin: 1rem;
  height: min-content;
}

/* .details-page {
  width: auto;
} */
/* .pics {
  width: 100%;
  height: min-content;
  border-radius: 8px;
  border: 1px solid rgba(255, 255, 255, 0.3);
  box-shadow: 0 1px 12px rgba(0, 0, 0, 0.25);
  background-color: rgba(255, 255, 255, 0.5);
  backdrop-filter: blur(20px);
  margin: 1rem;
} */
</style>