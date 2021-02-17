import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";

@Module({ namespaced: true })
class NavbarModule extends VuexModule {
  public isLoggedIn: boolean = false;

  @Action
  public checkIfUserWasLogged(): void {
    let isLogged: boolean = localStorage.getItem("token") != null;
    this.context.commit("setIsLoggedIn", isLogged);
  }

  @Mutation
  public setIsLoggedIn(isLogged: boolean) {
    this.isLoggedIn = isLogged;
  }
}

export default NavbarModule;
