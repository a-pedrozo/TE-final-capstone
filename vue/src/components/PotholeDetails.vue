<template>
  <div>
    <div class="deetzhead">
      <h1 class="location-address">Address: {{ pothole.address }}, {{pothole.city}}</h1>
    </div>
    <div v-if="pothole" class="details">
      <!-- <p class="id">ID: {{ pothole.id }}</p> -->
      <!-- <p class="city">City: {{ pothole.city }}</p> -->
      <div class="reported-reviewed">
      <p class="date-reported">Date Reported: {{ pothole.reportDate.substring(5,7)+ '/'+pothole.reportDate.substring(8,10)+'/'+pothole.reportDate.substring(0,4) }}</p>
      <p class="severity">Severity: {{ pothole.severity }}</p>
      <p class="location-lat-and-long">Latitude: {{ pothole.latitude }}</p>
      <p class="location-lat-and-long">Longitude: {{ pothole.longitude }}</p>
      <!-- <p class="report-date">Report Date: {{pothole.reportDate.substring(0,10)}}</p> -->

      <p class="reviewed">
        Reviewed: {{ pothole.isReviewed == true ? "Yes" : "No" }}
      </p>
      <p class="inspected">
        Inspected: {{ pothole.isInspected == true ? "Yes" : "No" }}
      </p>

      </div>
      <div class="repaired-inspected">
      <p class="inspection-date">
        Inspection Date:
        {{
          pothole.inspectionDate
            ? ( pothole.inspectionDate.substring(5,7)+ '/'+pothole.inspectionDate.substring(8,10)+'/'+pothole.inspectionDate.substring(0,4))
            : "None"
        }}
      </p>

      <p class="repaired">
        Repaired: {{ pothole.isRepaired == true ? "Yes" : "No" }}
      </p>
      <p class="repair-date">
        Repair Date:
        {{ pothole.repairDate ? pothole.repairDate.substring(5,7)+ '/'+pothole.repairDate.substring(8,10)+'/'+pothole.repairDate.substring(0,4) : "None" }}
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