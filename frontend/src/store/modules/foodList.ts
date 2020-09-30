import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";
import { HomeFood } from "@/models/interfaces/Food.ts";

@Module({ namespaced: true })
class FoodList extends VuexModule {
  public HomeFoodItems: Array<HomeFood> = [
    {
      title: "Pancakes with strawberries",
      price: 26,
      id: "111",
      description: "Pancakes with fresh strawberries and cream souce",
    },
    {
      title: "Pancakes with strawberries",
      price: 29,
      id: "112",
      description: "Pancakes with fresh strawberries and cream souce",
    },
    {
      title: "Pancakes with strawberries",
      price: 17,
      id: "113",
      description: "Pancakes with fresh strawberries and cream souce",
    },
  ];
}

export default FoodList;
