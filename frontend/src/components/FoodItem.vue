<template>
  <li class="meal__item">
    <img class="meal__img" src="../assets/img/breakfast_example.jpg" />
    <h5 class="meal__title">Lorem ipsum dolor sit amet</h5>
    <p class="meal__description">
      Lorem ipsum dolor sit amet, consectetur adipiscing elit
    </p>
    <span class="meal__price">30</span>
  </li>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
@Component({
  components: {},
  name: "FoodItem",
})
export default class FoodItem extends Vue {
  //PROP HOMefooditem
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/home.scss";
</style>