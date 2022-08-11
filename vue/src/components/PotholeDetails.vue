<template>
    <div>
        <div v-if="pothole">
            <p class="id">ID: {{pothole.id}} </p>
            <p class="date-reported">Date Reported: {{pothole.reportDate.substring(0,10)}}</p>
            <p class="severity">Severity: {{pothole.severity}}</p>
            <p class="location-lat-and-long">Location (latitude and longitude): {{pothole.latitude}}, {{pothole.longitude}}</p>
            <p class="location-address">Location (address): {{pothole.address}}</p>
            <p class="city">City: {{pothole.city}}</p>
            <p class="report-date">Report Date: {{pothole.reportDate.substring(0,10)}}</p>
            <p class="reviewed">Reviewed: {{pothole.isReviewed == true ? 'Yes' : 'No'}}</p>
            <p class="inspected">Inspected: {{pothole.isInspected == true ? 'Yes' : 'No'}}</p>
            <p class="inspection-date">Inspection Date: {{pothole.inspectionDate ? pothole.inspectionDate.substring(0,10): 'None'}}
            <p class="repaired">Repaired: {{pothole.isRepaired == true ? 'Yes' : 'No'}}</p>
            <p class="repair-date">Repair Date: {{pothole.repairDate ? pothole.repairDate.substring(0,10): 'None'}}</p>
        </div>
    </div>
</template>

<script>
export default {
    name: "PotholeDetails",
  props: ["pothole"],
};

    // created() {
    //     let potholeId = parseInt(this.$route.params.id);
    
    //     PotholeService.getPothole(potholeId)
    //     .then(response => {
    //         //console.log(response)
    //         this.pothole = response.data;
    //         //console.log(response.data);
    //         if (!this.pothole) {
    //             this.$router.push({name: 'NotFound'});
    //         }
    //     })
    //     .catch( response => {
    //         console.error(response);
    //     })
    //     },
    // data() {
    //     return {
    //         pothole: undefined
    //     }
    // }
    // }
</script>

<style>
.reviewed {
    font-weight: bolder;
}
</style>