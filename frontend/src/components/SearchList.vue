<template>
  <ul>
    <SearchItem v-for="item in SearchItems" :key="item.id" :searchItem="item" />
  </ul>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import SearchItem from "./SearchItem.vue";
import { namespace } from "vuex-class";
import { Food } from "../models/interfaces/Food";

const searchItemListModule = namespace("searchItemList");

@Component({
  components: { SearchItem },
  name: "SearchList",
})
export default class SearchList extends Vue {
  @searchItemListModule.State
  public SearchItems!: Array<Food>;

  created() {
    console.log(this.SearchItems);
  }
}
</script>

<style lang="scss" scoped>
@import "../sty;es/modules/search.scss";
</style>