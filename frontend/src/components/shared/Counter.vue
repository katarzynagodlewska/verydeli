<template>
  <div>
    <button>-</button>
    <p>{{ counter }}</p>
    <button>+</button>
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
  created() {
    console.log(this.counter);
  }
}
</script>
