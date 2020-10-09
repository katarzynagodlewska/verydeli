<template>
  <li class="search-item">
    <img
      class="search-item__img"
      src="../assets/img/pancakes_chocolate_blueberries.jpg"
    />
    <h5 class="search-item__title">{{ searchItem.title }}</h5>
    <p class="search-item__price">{{ searchItem.price }} PLN</p>
  </li>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import { Food } from "../models/interfaces/Food";

@Component({
  components: {},
  name: "SearchItem",
})
export default class SearchItem extends Vue {
  @Prop() public searchItem!: Food;
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/search.scss";
</style>