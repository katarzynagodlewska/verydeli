<template>
  <ul>
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
  //TODO get
})
export default class FoodList extends Vue {}
</script>