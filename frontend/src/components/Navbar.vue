<template>
  <nav class="nav">
    <img class="icon-log" src="../assets/img/icon-log.svg" />
    <div class="box-to-log-and-register">
      <p class="link-box-login">
        <a href class="link">Log in</a>
      </p>
      <p class="link-box-register">
        <a href class="link">Sign up</a>
      </p>
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
@import "../styles/modules/navbar.scss";
</style>
