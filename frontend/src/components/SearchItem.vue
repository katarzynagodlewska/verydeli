<template>
  <li>
    <img src="../assets/img/pancakes_chocolate_blueberries.jpg" />
    <h5>{{ searchItem.title }}</h5>
    <p>{{ searchItem.price }} PLN</p>
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