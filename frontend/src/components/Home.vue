<template>
  <section class="home">
    <HomeFoodContainer :type="breakfastType" />
    <HomeFoodContainer :type="lunchType" />
    <HomeFoodContainer :type="dinnerType" />
  </section>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { FoodType } from "../models/enums/FoodType";
import HomeFoodContainer from "./HomeFoodContainer.vue";
// import HomeFoodContainer from "./components/HomeFoodContainer.vue";

@Component({
  components: { HomeFoodContainer },
  name: "Home",
})
export default class Home extends Vue {
  breakfastType: FoodType = FoodType.Breakfast;
  lunchType: FoodType = FoodType.Lunch;
  dinnerType: FoodType = FoodType.Dinner;
  breakfastSrc: string = "../assets/img/breakfast.png";
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/home.scss";
</style>
