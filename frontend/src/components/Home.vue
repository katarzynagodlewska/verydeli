<template>
  <section class="home">
    <img class="home__brekfast-img" src="../assets/img/breakfast.png" />
    <img class="home__lunch-img" src="../assets/img/lunch.png" />
    <img class="home__dinner-img" src="../assets/img/dinner.png" />
  </section>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
@Component({
  components: {},
  name: "Home",
})
export default class Home extends Vue {}
</script>

<style lang="scss" scoped>
@import "../styles/modules/home.scss";
</style>
