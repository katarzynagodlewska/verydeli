<template>
  <div class="navbarcart-container">
    <img
      class="icon-cart"
      src="../assets/img/icon-cart.svg"
      v-if="isLoggedIn"
    />
    <div class="cart-box">
      <div class="cart-box__item">
        <span class="cart-box__name">Strawberry Pancakes</span>
        <span class="cart-box__price">26</span>
      </div>
      <button class="cart-box__button">See shopping busket</button>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";

@Component({
  components: {},
  name: "NavbarCart",
})
export default class NavbarCart extends Vue {
  @Prop() public isLoggedIn!: Boolean;
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/navbar.scss";
</style>