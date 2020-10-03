import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";

@Module({ namespaced: true })
class CounterModule extends VuexModule {
  public counter: number = 0;

  @Mutation
  public decrement(counter: number) {}
}

export default CounterModule;
