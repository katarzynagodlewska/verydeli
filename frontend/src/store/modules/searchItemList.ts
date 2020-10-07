import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";
import { Food } from "@/models/interfaces/Food.ts";

@Module({ namespaced: true })
class SearchItemListModule extends VuexModule {
  public SearchItems: Array<Food> = [
    { title: "Pancakes with strawberries", price: 26, id: "111" },
    { title: "Pancakes with strawberries", price: 29, id: "112" },
    { title: "Pancakes with strawberries", price: 17, id: "113" },
    { title: "English breakfast", price: 25, id: "114" },
    { title: "Pizza pepperoni", price: 19, id: "115" },
  ];
}

export default SearchItemListModule;
