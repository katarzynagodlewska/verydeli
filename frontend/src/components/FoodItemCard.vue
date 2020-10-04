<template>
  <div class="item-card" v-if="show">
    <button class="button-close">
      <img class="icon-close" src="../assets/img/icon-close.svg" />
    </button>
    <img
      class="item-card__img"
      src="../assets/img/pancakes_chocolate_blueberries.jpg"
    />
    <h4 class="item-card__title">{{ foodItemCard.title }}</h4>
    <p class="item-card__description">{{ foodItemCard.description }}</p>
    <Counter />
    <button class="item-card__add">Add to order</button>
    <p class="item-card__price">{{ foodItemCard.price }}</p>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import Counter from "./shared/Counter.vue";
import { namespace } from "vuex-class";
import { HomeFood } from "../models/interfaces/Food";
const foodItemCardModule = namespace("foodItemCard");

@Component({
  components: { Counter },
  name: "FoodItemCard",
})
export default class FoodItemCard extends Vue {
  @foodItemCardModule.State
  public show!: Boolean;
  @foodItemCardModule.State
  public foodItemCard!: HomeFood;
}
</script>


<style lang="scss" scoped>
@import "../styles/modules/foodItemCard.scss";
</style>