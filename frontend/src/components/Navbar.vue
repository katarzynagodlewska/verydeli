<template>
  <nav class="nav">
    <NavbarCart :isLoggedIn="isLoggedIn" />
    <img class="icon-log" src="../assets/img/icon-log.svg" />
    <div class="box-to-log-and-register">
      <p class="link-box-login">
        <router-link to="/account" class="link">Log in</router-link>
      </p>
      <p class="link-box-register">
        <router-link to="/account" class="link">Sign up</router-link>
      </p>
    </div>
  </nav>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import { namespace } from "vuex-class";
import NavbarCart from "./NavbarCart.vue";
const navbarModule = namespace("navbar");
@Component({
  components: { NavbarCart },
  name: "Navbar",
})
export default class Navbar extends Vue {
  @navbarModule.State
  public isLoggedIn!: Boolean;
  @navbarModule.Action
  public checkIfUserWasLogged!: () => Promise<void>;
  created() {
    this.checkIfUserWasLogged();
  }
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/navbar.scss";
</style>
