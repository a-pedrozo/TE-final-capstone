<template>
  <div>
    <div class="deetzhead">
      <h1 class="location-address">{{ pothole.address }}, {{pothole.city}}</h1>
    </div>
    <div v-if="pothole" class="details">
      
      <div class="reported-reviewed">
      <p class="location-lat-and-long"><strong>Latitude:</strong> {{ pothole.latitude }}</p>
      <p class="location-lat-and-long"><strong>Longitude:</strong> {{ pothole.longitude }}</p>
     
      <p class="severity" v-if="pothole.severity==0"><strong>Severity:</strong> N/A</p>
      <p class="severity" v-else-if="pothole.severity==1"><strong>Severity:</strong> Low</p>
      <p class="severity" v-else-if="pothole.severity==2"><strong>Severity:</strong> Medium</p>
      <p class="severity" v-else><strong>Severity:</strong> High</p>
      </div>
      <div class="repaired-inspected">
      <p class="report-date"><strong>Report Date:</strong> {{ pothole.reportDate.substring(5,7)+ '/'+pothole.reportDate.substring(8,10)+'/'+pothole.reportDate.substring(0,4) }}</p>

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
            ? ( pothole.inspectionDate.substring(5,7)+ '/'+pothole.inspectionDate.substring(8,10)+'/'+pothole.inspectionDate.substring(0,4))
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
        {{ pothole.repairDate ? pothole.repairDate.substring(5,7)+ '/'+pothole.repairDate.substring(8,10)+'/'+pothole.repairDate.substring(0,4) : "None" }}
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
  },
  method: {
    stringToDate(stringDate){
      let day = stringDate.substring();
      let month = stringDate.substring(5,2);
      let year = stringDate.substring(0,4)
      return month + '/'+day+'/'+year;
    }
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