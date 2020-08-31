<template>
  <li>
    <h5>test</h5>
    <p>50</p>
    <img />
    <span>Testowy description</span>
  </li>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
@Component({
  components: {},
  name: "FoodItem",
})
export default class FoodItem extends Vue {}
</script>