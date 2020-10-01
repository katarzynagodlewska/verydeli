<template>
  <li class="meal__item" v-on:click="showFoodCard">
    <img class="meal__img" src="../assets/img/breakfast_example.jpg" />
    <h5 class="meal__title">{{ foodItem.title }}</h5>
    <p class="meal__description">
      {{ foodItem.description }}
    </p>
    <span class="meal__price">{{ foodItem.price }}</span>
  </li>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import { HomeFood } from "../models/interfaces/Food";
@Component({
  components: {},
  name: "FoodItem",
})
export default class FoodItem extends Vue {
  @Prop() public foodItem!: HomeFood;
  public showFoodCard(): void {}
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/home.scss";
</style>