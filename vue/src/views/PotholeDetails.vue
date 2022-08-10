<template>
   <div>
   <pothole-details />
   <delete-pothole />
   <review-pothole />
   </div>
</template>

<script>
import PotholeDetails from "@/components/PotholeDetails.vue";
import DeletePothole from "@/components/DeletePothole.vue";
import ReviewPothole from "@/components/ReviewPothole.vue";

export default {
    name: "PotHoleDetails",
    components: {
        PotholeDetails,
        DeletePothole,
        ReviewPothole,
    }
}
</script>

<style>

</style>