<template>
  <section class="home">
    <HomeFoodContainer :type="breakfastType" />
    <HomeFoodContainer :type="lunchType" />
    <HomeFoodContainer :type="dinnerType" />
    <FoodItemCard />
  </section>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { FoodType } from "../models/enums/FoodType";
import HomeFoodContainer from "./HomeFoodContainer.vue";
import FoodItemCard from "./FoodItemCard.vue";

@Component({
  components: { HomeFoodContainer, FoodItemCard },
  name: "Home",
})
export default class Home extends Vue {
  breakfastType: FoodType = FoodType.Breakfast;
  lunchType: FoodType = FoodType.Lunch;
  dinnerType: FoodType = FoodType.Dinner;
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/home.scss";
</style>
