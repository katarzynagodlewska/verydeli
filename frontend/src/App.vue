<template>
  <div id="app" class="app">
    <Navbar />
    <router-view />
    <Footer />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

import Footer from "./components/Footer.vue";
import Navbar from "./components/Navbar.vue";

@Component({
  components: {
    Footer,
    Navbar,
  },
  name: "App",
})
export default class App extends Vue {}
</script>

<style lang="scss">
@import "styles/main.scss";
</style>
