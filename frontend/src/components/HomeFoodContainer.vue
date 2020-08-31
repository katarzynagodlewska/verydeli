<template>
  <div>
    <img v-on:click="showDiv" class="home__brekfast-img" src="../assets/img/breakfast.png" id="img" />
    <FoodList v-if="show" />
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import FoodList from "./FoodList.vue";
import { FoodType } from "../models/enums/FoodType";

@Component({
  components: { FoodList },
  name: "HomeFoodContainer",
})
export default class HomeFoodContainer extends Vue {
  @Prop() public type!: FoodType;
  public show: Boolean = false;
  public showDiv(): void {
    this.show = !this.show;
  }

  mounted() {
    let imgElement = this.$el.getElementsByClassName(
      "home__brekfast-img"
    )[0] as HTMLImageElement;
    switch (this.type) {
      case FoodType.Breakfast: {
        let img = require("../assets/img/breakfast.png");
        imgElement.src = img;
        break;
      }
      case FoodType.Lunch: {
        let img = require("../assets/img/lunch.png");
        imgElement.src = img;
        break;
      }
      case FoodType.Dinner: {
        let img = require("../assets/img/dinner.png");
        imgElement.src = img;
        break;
      }
      default: {
        //TODO Default img?
        break;
      }
    }
  }
}
</script>


<style lang="scss" scoped>
@import "../styles/modules/home.scss";
</style>