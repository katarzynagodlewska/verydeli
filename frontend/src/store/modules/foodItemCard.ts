import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";
import { HomeFood } from "@/models/interfaces/Food.ts";

@Module({ namespaced: true })
class FoodItemCardModule extends VuexModule {}

export default FoodItemCardModule;
