<template>
  <div v-if="show">
    <button></button>
    <img src="../assets/img/pancakes_chocolate_blueberries.jpg" />
    <h4></h4>
    <p></p>
    <button>-</button>
    <span></span>
    <button>+</button>
    <button>Add to order</button>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { namespace } from "vuex-class";
const foodItemCard = namespace("foodItemCard");

@Component({
  components: {},
  name: "FoodItemCard",
})
export default class FoodItemCard extends Vue {
  @foodItemCard.State
  public show: Boolean = false;
}
</script>


<style lang="scss" scoped>
@import "../styles/modules/foodItemCard.scss";
</style>