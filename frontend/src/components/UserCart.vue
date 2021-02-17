<template>
  <div class="cart">
    <h2 class="cart__title">Shopping basket</h2>
    <ul class="cart-list" v-for="item in foods" :key="item.id">
      <li class="cart-item">
        <img
          class="cart-item__img"
          src="../assets/img/pancakes_chocolate_blueberries.jpg"
        />
        <div class="cart-item__description">
          <h5 class="cart-item__name">
            {{ item.title }}
          </h5>
          <p class="cart-item__price">{{ item.price }}</p>
          <button class="cart-item__button-delete">
            <svg
              class="cart-item__delete-svg"
              width="24"
              height="24"
              viewBox="0 0 24 24"
              fill="none"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                d="M16 9V19H8V9H16ZM14.5 3H9.5L8.5 4H5V6H19V4H15.5L14.5 3ZM18 7H6V19C6 20.1 6.9 21 8 21H16C17.1 21 18 20.1 18 19V7Z"
                fill="black"
              />
            </svg>
          </button>
        </div>
      </li>
    </ul>
    <p class="cart__total">Total:</p>
    <p class="cart__sum">65,90 PLN</p>
    <router-link to="/order" class="cart__continue">CONTINUE</router-link>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { namespace } from "vuex-class";
import { CartFood } from "../models/interfaces/Food";
const cartModule = namespace("cart");

@Component({
  components: {},
  name: "UserCart",
})
export default class UserCart extends Vue {
  @cartModule.State
  public foods!: Array<CartFood>;
}
</script>

<style lang="scss">
@import "../styles/modules/cart.scss";
</style>