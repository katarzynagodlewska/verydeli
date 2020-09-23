<template>
  <ul class="meal">
    <FoodItem />
    <FoodItem />
    <FoodItem />
    <FoodItem />
    <FoodItem />
    <FoodItem />
    <FoodItem />
  </ul>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import FoodItem from "./FoodItem.vue";

@Component({
  components: { FoodItem },
  name: "FoodList",
})
export default class FoodList extends Vue {
  //TODO get
  public foodItems: any = [];
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/home.scss";
</style>