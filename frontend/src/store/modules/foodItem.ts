import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";
import store from "../store";
import { HomeFood } from "@/models/interfaces/Food.ts";

@Module({ namespaced: true })
class FoodItemModule extends VuexModule {
  @Action
  public showItem(foodItem: HomeFood): void {
    store.dispatch("foodItemCard/showItem", foodItem);
  }
}

export default FoodItemModule;
