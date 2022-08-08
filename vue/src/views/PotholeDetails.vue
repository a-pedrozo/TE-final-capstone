<template>
   <div>
   <pothole-details />
   <delete-pothole />
   </div>
</template>

<script>
import PotholeDetails from "@/components/PotholeDetails.vue";
import DeletePothole from "@/components/DeletePothole.vue";

export default {
    name: "PotHoleDetails",
    components: {
        PotholeDetails,
        DeletePothole,
    }
}
</script>

<style>

</style>