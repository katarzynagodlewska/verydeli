<template>
  <div v-if="show">
    <button></button>
    <img src="../assets/img/pancakes_chocolate_blueberries.jpg" />
    <h4>{{ foodItemCard.title }}</h4>
    <p>{{ foodItemCard.description }}</p>
    <Counter />
    <button>Add to order</button>
    <p>{{ foodItemCard.price }}</p>
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