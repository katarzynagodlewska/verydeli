import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";

@Module({ namespaced: true })
class CartModule extends VuexModule {}

export default CartModule;
