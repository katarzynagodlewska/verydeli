import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";
import store from "../store";

@Module({ namespaced: true })
class SearchModule extends VuexModule {
  public showList: Boolean = false;

  @Action
  public searchInputHandler(searchText: string): void {
    store.dispatch("searchItemList/getSearchItems", searchText);
  }

  @Action
  public changeShowListVisible(isVisible: Boolean): void {
    this.context.commit("setListVisibility", isVisible);
  }

  @Mutation
  public setListVisibility(isVisible: Boolean): void {
    this.showList = isVisible;
  }
}

export default SearchModule;
