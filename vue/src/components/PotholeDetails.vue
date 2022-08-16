<template>
  <div>
    <div class="deetzhead">
      <h1 class="location-address">{{ pothole.address }}, {{pothole.city}}</h1>
    </div>
    <div v-if="pothole" class="details">
      
      <div class="reported-reviewed">
      <p class="location-lat-and-long"><strong>Latitude:</strong> {{ pothole.latitude }}</p>
      <p class="location-lat-and-long"><strong>Longitude:</strong> {{ pothole.longitude }}</p>
      <p class="date-reported"><strong> Reported:</strong> {{ pothole.reportDate.substring(0, 10) }}</p>
      <p class="severity" v-if="pothole.severity==0"><strong>Severity:</strong> N/A</p>
      <p class="severity" v-else-if="pothole.severity==1"><strong>Severity:</strong> Low</p>
      <p class="severity" v-else-if="pothole.severity==2"><strong>Severity:</strong> Medium</p>
      <p class="severity" v-else><strong>Severity:</strong> High</p>
      </div>
      <div class="repaired-inspected">
      <p class="report-date"><strong>Report Date:</strong> {{pothole.reportDate.substring(0,10)}}</p>

      <!-- <p class="reviewed">
        Reviewed: {{ pothole.isReviewed == true ? "Yes" : "No" }}
      </p> 
      <p class="inspected">
        Inspected: {{ pothole.isInspected == true ? "Yes" : "No" }}
      </p> -->

      <p class="inspection-date">
        <strong>Inspection Date:</strong>
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
        <strong>Repair Date:</strong>
        {{ pothole.repairDate ? pothole.repairDate.substring(0, 10) : "None" }}
      </p>

      <p class="reviewed"><strong>Status:</strong> {{ pothole.status }}</p>
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


.location-address{
  text-decoration: none;
  padding-left: 1rem;
  
}
.details{
  display: flex;
  flex-direction: row;
  justify-content: space-evenly;
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
.deetzhead{
  padding-bottom: 2rem;
}
</style>