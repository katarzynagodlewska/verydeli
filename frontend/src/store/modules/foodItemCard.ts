import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";
import { HomeFood } from "@/models/interfaces/Food.ts";

@Module({ namespaced: true })
class FoodItemCardModule extends VuexModule {
  public show: boolean = true;
  public foodItemCard: HomeFood = {
    description: "Pancakes with chocolate souce and fresh blueberries.",
    title: "Pancakes with chocolate and blueberries",
    price: 22.9,
    id: "testId",
  };
}

export default FoodItemCardModule;
