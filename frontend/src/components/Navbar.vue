<template>
  <nav>
    <img class="icon-log" src="../assets/img/icon-log.svg" />
    <div class="box-to-log-and-register">
      <a href="" class="link-log">Log in</a>
      <a href="" class="link-register">Sign up</a>
    </div>
  </nav>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
@Component({
  components: {},
  name: "Navbar",
})
export default class Navbar extends Vue {}
</script>

<style lang="scss" scoped>
@import "../styles/navbar.scss";
</style>
