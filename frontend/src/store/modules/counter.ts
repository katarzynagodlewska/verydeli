import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";

@Module({ namespaced: true })
class CounterModule extends VuexModule {
  public counter: number = 0;
  // //   get(){
  // //     return this.counter;
  // //   },

  // //   public set value(v : string) {
  // //     this. = v;
  // //   }

  // // }
  // // public
  // public get counter(): number {
  //   return this.counter;
  // }

  // public set counter(v: number) {
  //   this.counter = v;
  // }

  @Mutation
  public decrementCounter() {
    if (this.counter != 0) {
      this.counter--;
    }
  }

  @Mutation
  public incrementCounter() {
    this.counter++;
  }

  @Action
  public decrement() {
    this.context.commit("decrementCounter");
  }

  @Action
  public increment() {
    this.context.commit("incrementCounter");
  }
}

export default CounterModule;
