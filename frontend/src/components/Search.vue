<template>
  <div>
    <input />
    <button><img src="../assets/img/icon-search.svg" /></button>
    <SearchList v-if="show" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import SearchList from "./SearchList.vue";

@Component({
  components: { SearchList },
  name: "Search",
})
export default class Search extends Vue {
  public show: Boolean = true;
}
</script>