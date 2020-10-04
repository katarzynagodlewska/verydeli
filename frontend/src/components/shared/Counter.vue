<template>
  <div>
    <button @click="decrement()">-</button>
    <p>{{ counter }}</p>
    <button @click="increment()">+</button>
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
