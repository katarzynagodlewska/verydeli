<template>
  <div class="cart">
    <h2 class="cart__title">Shopping basket</h2>
    <ul class="cart-list">
      <li class="cart-item">
        <img class="cart-item__img" src="../assets/img/pancakes_chocolate_blueberries.jpg" />
        <div class="cart-item__description">
          <h5 class="cart-item__name">Oatmeal Pancakes with Toffi and Blueberries</h5>
          <p class="cart-item__price">26</p>
        </div>
      </li>
      <li class="cart-item">
        <img class="cart-item__img" src="../assets/img/breakfast_example.jpg" />
        <div class="cart-item__description">
          <h5 class="cart-item__name">Oatmeal Pancakes with Toffi and Blueberries</h5>
          <span class="cart-item__price">26</span>
          <img class="cart-item__delete" src="../assets/img/icon-delete.svg" />
        </div>
      </li>
      <li class="cart-item">
        <img class="cart-item__img" src="../assets/img/breakfast_example.jpg" />
        <div class="cart-item__description">
          <h5 class="cart-item__name">Oatmeal Pancakes with Toffi and Blueberries</h5>
          <p class="cart-item__price">26</p>
        </div>
      </li>
      <li class="cart-item">
        <img class="cart-item__img" src="../assets/img/breakfast_example.jpg" />
        <div class="cart-item__description">
          <h5 class="cart-item__name">Oatmeal Pancakes with Toffi and Blueberries</h5>
          <p class="cart-item__price">26</p>
        </div>
      </li>
    </ul>
    <p class="cart__total">Total</p>
    <p class="cart__sum">65,90 PLN</p>
    <router-link to="/order">Continue</router-link>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
@Component({
  components: {},
  name: "UserCart",
})
export default class UserCart extends Vue {}
</script>

<style lang="scss">
@import "../styles/modules/cart.scss";
</style>