import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";
import { FoodType } from "@/models/enums/FoodType";
import router from "@/router/";

@Module({ namespaced: true })
class FoodItemsModule extends VuexModule {
  @Action
  public async getFoodItemsByType(foodType: FoodType) {}
}
