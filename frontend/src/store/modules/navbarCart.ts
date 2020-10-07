import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";
import { Food } from "@/models/interfaces/Food";

@Module({ namespaced: true })
class NavbarCartModule extends VuexModule {
  public foods: Array<Food> = [
    { title: "Pancakes with strawberries", price: 26, id: "111" },
    { title: "Pancakes with strawberries", price: 29, id: "112" },
    { title: "Pancakes with strawberries", price: 17, id: "113" },
  ];
}

export default NavbarCartModule;