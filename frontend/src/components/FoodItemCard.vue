<template>
  <div v-if="show">
    <button></button>
    <img src="../assets/img/pancakes_chocolate_blueberries.jpg" />
    <h4>{{ foodItemCard.title }}</h4>
    <p>{{ foodItemCard.description }}</p>
    
    <button>Add to order</button>
    <p>{{ foodItemCard.price }}</p>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import { namespace } from "vuex-class";
import { HomeFood } from "../models/interfaces/Food";
const foodItemCardModule = namespace("foodItemCard");

@Component({
  components: {},
  name: "FoodItemCard",
})
export default class FoodItemCard extends Vue {
  @Prop() public foodItemCard!: HomeFood;
  @foodItemCardModule.State
  public show: Boolean = false;
}
</script>


<style lang="scss" scoped>
@import "../styles/modules/foodItemCard.scss";
</style>