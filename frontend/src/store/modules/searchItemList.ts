import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";
import store from "../store";
import { Food } from "@/models/interfaces/Food.ts";
import { searchService } from "@/services/searchService";

@Module({ namespaced: true })
class SearchItemListModule extends VuexModule {
  public SearchItems?: Array<Food>;

  @Action
  public async getSearchItems(searchText: string): Promise<void> {
    if (searchText == "") {
      store.dispatch("search/changeShowListVisible", false);
      this.context.commit("setSearchItems", []);
      return;
    }

    let searchItems = await searchService.getItemsForSearch(searchText);
    this.context.commit("setSearchItems", searchItems);
    store.dispatch("search/changeShowListVisible", true)
  }

  @Mutation
  public setSearchItems(foods: Array<Food>) {
    this.SearchItems = foods;
  }
}

export default SearchItemListModule;
