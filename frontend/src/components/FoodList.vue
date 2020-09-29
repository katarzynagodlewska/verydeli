<template>
  <div>
    <ul class="meal" v-for="item in fooditems" :key="item.id">
      <FoodItem />
    </ul>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import { namespace } from "vuex-class";
import FoodItem from "./FoodItem.vue";
import { HomeFood } from "../models/interfaces/Food";
const navbarCart = namespace("foodList");

@Component({
  components: { FoodItem },
  name: "FoodList",
})
export default class FoodList extends Vue {
  @Prop() public HomeFoodItems!: Array<HomeFood>;
  //public foodItems: any = [];
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/home.scss";
</style>