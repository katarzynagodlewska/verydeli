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
const counterModule = namespace("counterModule");

export default class Counter extends Vue {
  @counterModule.State
  public counter!: number;
}
</script>
