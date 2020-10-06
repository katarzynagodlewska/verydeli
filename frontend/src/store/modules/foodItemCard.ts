import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";
import { HomeFood } from "@/models/interfaces/Food.ts";

@Module({ namespaced: true })
class FoodItemCardModule extends VuexModule {
  public show: boolean = false;
  public foodItemCard: HomeFood = {
    description: "",
    title: "",
    price: 0,
    id: "",
  };

  @Mutation
  public closeItemCard() {
    this.show = false;
  }

  @Mutation
  public showItemCard(foodItem: HomeFood) {
    this.show = true;
    this.foodItemCard = foodItem;
  }

  @Action
  public showItem(foodItem: HomeFood) {
    this.context.commit("showItemCard", foodItem);
  }

  @Action
  public closeItem() {
    this.context.commit("closeItemCard");
  }
}

export default FoodItemCardModule;
