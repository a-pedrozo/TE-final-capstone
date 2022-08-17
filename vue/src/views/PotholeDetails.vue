<template>
  <div v-if="pothole" class="details-all">
    <div class="details-page">
      <img
        class="image"
        v-bind:src='imageSrc'
        alt="pothole in the road"
      />
      <pothole-details :pothole="pothole"  />
    </div>
    <div v-if="$store.state.user.role == 'admin'" class="form-buttons">
        <h4 class="font-weight-bold">Update Hole</h4>
        <!-- After create hook, when pothole object is populated, Bind the pothole object to each child component so it's available And reactive -->
        <delete-pothole v-show="!pothole.isReviewed" :pothole="pothole" />
        <review-pothole v-show="!pothole.isInspected" :pothole="pothole" />
        <schedule-repair :pothole="pothole" />
        <mark-as-repaired :pothole="pothole" />
    </div>
    <div class="map">
      <details-map :pothole="pothole" />
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
import { initializeApp } from "firebase/app";
import { getStorage, ref, getDownloadURL } from "firebase/storage";
import DetailsMap from '@/components/DetailsMap.vue';
//import { getStorage } from "firebase/storage";

const firebaseConfig = {
  apiKey: "AIzaSyBQeW0yeRjWlRkshtjTqTFtpAcgo1xhfg0",
  authDomain: "capstone-f5ad4.firebaseapp.com",
  projectId: "capstone-f5ad4",
  storageBucket: "capstone-f5ad4.appspot.com",
  messagingSenderId: "978395809050",
  appId: "1:978395809050:web:c5e77ab85b9bd8c5cb98a3",
};

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
    DetailsMap,
  },
  created() {
    let potholeId = parseInt(this.$route.params.id);
    this.imageURL();
    PotholeService.getPothole(potholeId)
      .then((response) => {
        console.log("pothole service response", response);
        this.pothole = response.data;
        // this.imageURL();
        console.log("pothole response data", response.data);
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
      imageSrc: '',
      
      
    };
  },
  
  methods: {
    imageURL(){
      let potholeId = parseInt(this.$route.params.id);
      const firebase = initializeApp(firebaseConfig);
      console.log("firebase", firebase);
      const storage = getStorage(firebase);
      console.log("storage?", storage);
        let getRef = ref(storage,'images/'+ potholeId +'.jpeg')
        console.log(getRef);
      getDownloadURL(getRef)
        .then( url => {
          console.log("url response data", url);
          this.imageSrc = url;
        })
    }
  },
};
</script>

<style>
.details-all {
  display: grid;
  grid-template-columns: 3fr 1fr;
  grid-template-areas: 
    "content form"
    "content map";
  /* flex-wrap: nowrap;
  flex-direction: row; */
  /* width: 100%; 
  align-items: flex-start; */
  margin-top: 0;
  justify-content: space-evenly;
}

.details-page {
  width: 65%;
  /* display: flex;
  flex-direction: column; */
  grid-area: content;
  overflow-y: scroll;
  overflow-x: hidden;
}

.form-buttons {
  width: 30%;
  grid-area: form;
}

.map {
  grid-area: map;
}

.details-page,
.form-buttons {
  padding: 2rem;
  border-radius: 8px;
  border: 1px solid rgba(255, 255, 255, 0.3);
  box-shadow: 0 1px 12px rgba(0, 0, 0, 0.25);
  background-color: rgba(255, 255, 255, 0.5);
  backdrop-filter: blur(1px);
  margin: 2rem;
}

.details-page {
  width: 46%;
  display: flex;
  flex-direction: column;
  }

.image {
  object-fit: cover;
  width: 50rem;
  height: 20rem;
  margin-bottom:1rem ;
}


h4{
  padding-left: 1rem;
}

</style>