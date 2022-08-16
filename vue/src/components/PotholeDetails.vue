<template>
  <div>
    <div class="deetzhead">
      <h1 class="location-address">Address: {{ pothole.address }}, {{pothole.city}}</h1>
    </div>
    <div v-if="pothole" class="details">
      <!-- <p class="id">ID: {{ pothole.id }}</p> -->
      <!-- <p class="city">City: {{ pothole.city }}</p> -->
      <p class="date-reported">Date Reported: {{ pothole.reportDate.substring(0, 10) }}</p>
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

      <p class="inspection-date">
        Inspection Date:
        {{
          pothole.inspectionDate
            ? pothole.inspectionDate.substring(0, 10)
            : "None"
        }}
      </p>

      <p class="repaired">
        Repaired: {{ pothole.isRepaired == true ? "Yes" : "No" }}
      </p>
      <p class="repair-date">
        Repair Date:
        {{ pothole.repairDate ? pothole.repairDate.substring(0, 10) : "None" }}
      </p>

      <p class="reviewed">Status: {{ pothole.status }}</p>

    </div>
  </div>
</template>

<script>
export default {
  name: "PotholeDetails",
  props: ["pothole"],
};
</script>

<style>

.reviewed {
  font-weight: bolder;
}
.location-address{
  text-decoration: none;
}
.details{
   padding-left: 3rem;
   display: flex;
   flex-direction: row;
   flex-wrap: wrap;
   justify-content: space-evenly;
}

/* .severity{
  padding-left: 5rem;
}
.location-lat-and-long{
  padding-left: 5rem;
}
.repaired{
  padding-left: 5rem;
}
.repair-date{
  padding-left: 5rem;
}
.reviewed{
  padding-left: 5rem;
}
.inspected{
  padding-left: 5rem;
} */
</style>