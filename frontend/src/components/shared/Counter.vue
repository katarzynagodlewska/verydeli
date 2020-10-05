<template>
  <div class="counter">
    <button class="button-decrement" @click="decrement()">-</button>
    <input
      class="counter__input"
      v-model="counter"
      disabled="disabled"
      type="number"
    />
    <button class="button-increment" @click="increment()">+</button>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { namespace } from "vuex-class";
const counterModule = namespace("counter");

@Component({
  components: {},
  name: "Counter",
})
export default class Counter extends Vue {
  @counterModule.State
  public counter!: number;

  @counterModule.Action
  public increment!: () => void;

  @counterModule.Action
  public decrement!: () => void;

  created() {
    console.log(this.counter);
  }
}
</script>

<style lang="scss" scoped>
@import "@/styles/modules/foodItemCard.scss";
</style>