<template>
  <section class="search">
    <input
      type="search"
      class="search__input"
      placeholder="search"
      v-model="searchText"
      v-on:input="searchInputHandler(searchText)"
    />
    <SearchList v-if="showList" />
  </section>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { namespace } from "vuex-class";
import SearchList from "./SearchList.vue";
const searchModule = namespace("search");

@Component({
  components: { SearchList },
  name: "Search",
})
export default class Search extends Vue {
  @searchModule.State
  public showList!: Boolean;

  public searchText: string = "";

  @searchModule.Action
  public searchInputHandler!: (searchText: string) => void;
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/search.scss";
</style>