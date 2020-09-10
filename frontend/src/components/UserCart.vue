<template>
  <div>
    <h2>Shopping basket</h2>
    <ul>
      <li>
        <img src="../assets/img/pancakes_chocolate_blueberries.jpg" />
        <h5>Oatmeal Pancakes with Toffi and Blueberries</h5>
        <span>26</span>
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
@Component({
  components: {},
  name: "UserCart",
})
export default class UserCart extends Vue {}
</script>

<style lang="scss">
@import "../styles/modules/cart.scss";
</style>