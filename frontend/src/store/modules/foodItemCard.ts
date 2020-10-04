import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";
import { HomeFood } from "@/models/interfaces/Food.ts";

@Module({ namespaced: true })
class FoodItemCardModule extends VuexModule {
  public show: boolean = true;
  public foodItemCard: HomeFood = {
    description: "test",
    title: "testTitle",
    price: 10,
    id: "testId",
  };
}

export default FoodItemCardModule;
