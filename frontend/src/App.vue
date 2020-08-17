<template>
  <div id="app">
    <Navbar />
    <router-view>
      <div>
        <span class="text-repetateble-vertically">verydeli</span>
      </div>
    </router-view>
    <Footer />
  </div>
</template>

<script lang="ts">
import Footer from "./components/Footer.vue";
import Navbar from "./components/Navbar.vue";

export default {
  name: "App",
  components: { Footer, Navbar },
};
</script>

<style lang="scss">
@import "../styles/scss/main.scss";
</style>
