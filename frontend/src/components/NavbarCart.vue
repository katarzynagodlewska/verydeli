<template>
  <div class="navbarcart-container">
    <img
      class="icon-cart"
      src="../assets/img/icon-cart.svg"
      v-if="isLoggedIn"
    />
    <div class="cart-box">
      <div v-for="item in foods" :key="item.id">
        <div class="cart-box__item">
          <span class="cart-box__name">{{ item.title }}</span>
          <span class="cart-box__price">{{ item.price }}</span>
        </div>
      </div>
      <button class="cart-box__button">See shopping busket</button>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import { namespace } from "vuex-class";
import { Food } from "@/models/interfaces/Food";
const navbarCart = namespace("navbarCart");

@Component({
  components: {},
  name: "NavbarCart",
})
export default class NavbarCart extends Vue {
  @Prop() public isLoggedIn!: Boolean;

  @navbarCart.State
  public foods!: Array<Food>;
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/navbar.scss";
</style>