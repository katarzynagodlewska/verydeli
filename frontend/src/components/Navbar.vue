<template>
  <nav class="nav">
    <img class="icon-cart" src="../assets/img/icon-cart.svg" />
    <div class="cart-box">
      <div class="cart-box__item">
        <span class="cart-box__name">Strawberry Pancakes</span>
        <span class="cart-box__price">26</span>
      </div>
      <button class="cart-box__button">See shopping busket</button>
    </div>
    <img class="icon-log" src="../assets/img/icon-log.svg" />
    <div class="box-to-log-and-register">
      <p class="link-box-login">
        <a href="/account" class="link">Log in</a>
      </p>
      <p class="link-box-register">
        <a href="/account" class="link">Sign up</a>
      </p>
    </div>
  </nav>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import { namespace } from "vuex-class";
const navbarModule = namespace("navbar");
@Component({
  components: {},
  name: "Navbar",
})
export default class Navbar extends Vue {
  // @navbarModule.Getter
  // public isLoggedIn!: Boolean;
  // @Prop() isLoggedIn!: boolean;
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/navbar.scss";
</style>
