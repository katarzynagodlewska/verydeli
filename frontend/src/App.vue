<template>
  <div id="app">
    <Navbar />
    <div>
      <span class="text-repetateble-vertically">verydeli</span>
    </div>
    <Footer />
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Footer from "./components/Footer.vue";
import Navbar from "./components/Navbar.vue";
export default Vue.extend({
  name: "App",
  components: {
    Footer,
    Navbar,
  },
});
</script>

<style lang="scss" scoped>
@import "styles/main.scss";
</style>