<template>
  <li class="meal__item" v-on:click="showItem(foodItem)">
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
import { namespace } from "vuex-class";
import { HomeFood } from "../models/interfaces/Food";
const foodItemModule = namespace("foodItem");

@Component({
  components: {},
  name: "FoodItem",
})
export default class FoodItem extends Vue {
  @Prop() public foodItem!: HomeFood;

  @foodItemModule.Action
  public showItem!: (foodItem: HomeFood) => void;
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/home.scss";
</style>