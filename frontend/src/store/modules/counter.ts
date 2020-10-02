import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";

@Module({ namespaced: true })
class CounterModule extends VuexModule {
  public counter: number = 0;
}

export default CounterModule;
