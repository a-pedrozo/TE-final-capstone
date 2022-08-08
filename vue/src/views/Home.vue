<template>
  <div class="home">
    <h1>Home</h1>
    <p>Your content goes here. Make it look nice.</p>
    <pothole-table />
  </div>
</template>


<script>
import PotholeTable from '../components/PotholeTable.vue';

export default {
  components: { PotholeTable },
  name: "home"
  
};
</script>
