<template>
  <div>
    <div class="deetzhead">
      <h1 class="location-address">{{ pothole.address }}, {{pothole.city}}</h1>
    </div>
    <div v-if="pothole" class="details">
      
      <div class="reported-reviewed">
      <p class="location-lat-and-long">Latitude: {{ pothole.latitude }}</p>
      <p class="location-lat-and-long">Longitude: {{ pothole.longitude }}</p>
      <p class="date-reported">Date Reported: {{ pothole.reportDate.substring(0, 10) }}</p>
      <p class="severity" v-if="pothole.severity==0">Severity: N/A</p>
      <p class="severity" v-else-if="pothole.severity==1">Severity: Low</p>
      <p class="severity" v-else-if="pothole.severity==2">Severity: Medium</p>
      <p class="severity" v-else>Severity: High</p>
      <p class="report-date">Report Date: {{pothole.reportDate.substring(0,10)}}</p>

      <!-- <p class="reviewed">
        Reviewed: {{ pothole.isReviewed == true ? "Yes" : "No" }}
      </p> 
      <p class="inspected">
        Inspected: {{ pothole.isInspected == true ? "Yes" : "No" }}
      </p> -->

      </div>
      <div class="repaired-inspected">
      <p class="inspection-date">
        Inspection Date:
        {{
          pothole.inspectionDate
            ? pothole.inspectionDate.substring(0, 10)
            : "None"
        }}
      </p>

      <!-- <p class="repaired">
        Repaired 
        <i v-if="!pothole.isRepaired && !pothole.repairDate == null" class="fas fa-times-circle"></i>
        <i v-if="pothole.isRepaired && pothole.repairDate == null" class="fas fa-check-circle"></i>
        {{pothole.repairDate.substring(0, 10)}}
      </p>  -->
      <p class="repair-date">
        Repair Date:
        {{ pothole.repairDate ? pothole.repairDate.substring(0, 10) : "None" }}
      </p>

      <p class="reviewed">Status: {{ pothole.status }}</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "PotholeDetails",
  props: ["pothole"],
  methods: {
    
  },
  created () {
  }
}
</script>

<style>

.reviewed {
  font-weight: bolder;
}
.location-address{
  text-decoration: none;
  padding-left: 1rem;
  
}
.details{
  display: flex;
  flex-direction: row;
  justify-content: space-around;
}
.reported-reviewed{
  display: flex;
  flex-direction: column;
  justify-content: left;
}
.repaired-inspected{
  display: flex;
  flex-direction: column;
  justify-content: right;
}
</style>