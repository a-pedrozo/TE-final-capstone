<template>
  <div>
    <h1 id="title">View All Potholes</h1>
    <div class="pothole-table">
      <div class="search">
        <h4>Search</h4>
        <div id="search-bar-styling">
          <div class="search-option">
            <label for="address-search">Street Name:</label>
            <input
              type="address"
              name="address-search"
              v-model="search.address"
            />
          </div>
          <div class="search-option">
            <label for="severity">Severity:</label>
            <select name="severity" v-model.number="search.severity">
              <option value="0"></option>
              <option value="1">Low</option>
              <option value="2">Medium</option>
              <option value="3">High</option>
            </select>
          </div>
          <div class="search-option">
            <label for="status-filter">Status: </label>
            <div
              class="checkbox-option"
              v-if="$store.state.user.role == 'admin'"
            >
              <input
                type="checkbox"
                name="isAwaitingReviewCheck"
                v-model="search.isAwaitingReview"
              />
              <label for="isAwaitingReviewCheck">Awaiting Review</label>
            </div>
            <div class="checkbox-option">
              <input
                type="checkbox"
                name="isReviewedCheck"
                v-model="search.isReviewed"
              />
              <label for="isReviewedCheck">Reviewed</label>
            </div>
            <div class="checkbox-option">
              <input
                type="checkbox"
                name="isInspectedCheck"
                v-model="search.isInspected"
              />
              <label for="isInspectedCheck">Inspected</label>
            </div>
            <div class="checkbox-option">
              <input
                type="checkbox"
                name="isRepairedCheck"
                v-model="search.isRepaired"
              />
              <label for="isRepairedCheck">Repaired</label>
            </div>
          </div>
        </div>
      </div>
      <div class="pothole-cards">
        <div
          v-for="pothole in filteredPotholes"
          v-bind:key="pothole.id"
          class="cards"
        >
          <p class="location-address">Address: {{ pothole.address }}</p>
          <p class="date-reported">
            Date Reported: {{ pothole.reportDate.substring(0, 10) }}
          </p>
          <!-- <p class="reviewed" v-if="$store.state.user.role == 'admin'">
            Reviewed: {{ pothole.isReviewed == true ? "Yes" : "No" }}
          </p> -->
          <p class="location-lat-and-long">Latitude: {{ pothole.latitude }}</p>
          <p>Longitude: {{ pothole.longitude }}</p>
          <p class="city">City: {{ pothole.city }}</p>
          <p class="status">Status: {{ pothole.status }}</p>
          <router-link
            v-bind:to="{ name: 'PotholeDetails', params: { id: pothole.id } }"
          >
            See Details
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import PotholeService from "../services/PotholeService.js";

export default {
  data() {
    return {
      search: {
        address: "",
        isReviewed: false,
        isInspected: false,
        isRepaired: false,
        isAwaitingReview: false,
        severity: 0,
      },
      potholes: this.$store.state.potholes,
    };
  },
  computed: {
    filteredPotholes() {
      return this.potholes.filter((p) => {
        if (p.isReviewed || this.$store.state.user.role == "admin") {
          if (this.search.severity > 0 && p.severity != this.search.severity) {
            return false;
          } else if (
            this.search.address && !p.address.toLowerCase().includes(this.search.address.toLowerCase())) {
            return false;
          } else if (this.search.isRepaired && !p.isRepaired) {
            return false;
          } else if (this.search.isInspected && !p.isInspected) {
            return false;
          } else if (this.search.isReviewed && !p.isReviewed) {
            return false;
          } else if (this.search.isAwaitingReview && p.isReviewed) {
            return false;
          }
          return true;
        }
      });
    },
  },
  methods: {
    updateStore() {
      PotholeService.getPotholes().then((response) => {
        this.$store.commit("LIST_POTHOLES", response.data);
        console.log(response.data);
      });
    },
  },
  created() {
    this.updateStore();
  },
};
</script>

<style>
.pothole-table {
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  align-items: center;
}
#title {
  text-align: left;
}
.search {
  padding: 1rem;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: flex-start;
  border-radius: 8px;
  border: 1px solid rgba(255, 255, 255, 0.3);
  box-shadow: 0 1px 12px rgba(0, 0, 0, 0.25);
  background-color: rgba(255, 255, 255, 0.5);
  backdrop-filter: blur(20px);
  width: 80%;
}
#search-bar-styling {
  display: flex;
  flex-direction: row;
  justify-content: space-around;
  width: 100%;
}
.search-option {
  margin: 1rem;
  width: 30%;
}
.checkbox-option {
  margin-left: 1rem;
}
.search-option > label {
  font-weight: bold;
}
.search h4 {
  font-weight: bold;
  text-decoration: underline;
}

.search .search-option input,
.search input,
.search select {
  margin: 0 0.5rem 0 0.5rem;
}

.pothole-cards {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  width: 100%;
  justify-content: space-evenly;
  align-items: left;
}
.cards {
  border: 2px solid black;
  margin: 1rem;
  padding: 2rem;
  width: 30%;

  border-radius: 8px;
  border: 1px solid rgba(255, 255, 255, 0.3);
  box-shadow: 0 1px 12px rgba(0, 0, 0, 0.25);
  background-color: rgba(255, 255, 255, 0.5);
  backdrop-filter: blur(20px);
  /* background-color: #ede3d9; */
}
.status {
  font-weight: bold;
}

.location-address {
  font-weight: bold;
  font-size: 1.5rem;
}
</style>