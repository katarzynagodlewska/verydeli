<template>
  <section class="search">
    <input type="search" class="search__input" placeholder="search" />
    <SearchList v-if="show" />
  </section>
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


<style lang="scss" scoped>
@import "../styles/modules/search.scss";
</style>