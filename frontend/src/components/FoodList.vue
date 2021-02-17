<template>
  <ul class="meal">
    <FoodItem v-for="item in HomeFoodItems" :key="item.id" :foodItem="item" />
  </ul>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import { namespace } from "vuex-class";
import FoodItem from "./FoodItem.vue";
import { HomeFood } from "../models/interfaces/Food";
const foodListModule = namespace("foodList");

@Component({
  components: { FoodItem },
  name: "FoodList",
})
export default class FoodList extends Vue {
  @foodListModule.State
  public HomeFoodItems!: Array<HomeFood>;
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/home.scss";
</style>