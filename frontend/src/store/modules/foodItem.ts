import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";
import store from "../store";

@Module({ namespaced: true })
class FoodItemModule extends VuexModule {
  @Action
  public showItem(): void {
    store.dispatch("foodItemCard/showItem");
  }
}

export default FoodItemModule;
