import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";

@Module({ namespaced: true })
class NavbarModule extends VuexModule {
  private _isLoggedIn: boolean = false;
  public get isLoggedIn(): boolean {
    return localStorage.getItem("token") != null;
  }

  @Mutation
  public checkIfUserWasLogged(): void {
    this._isLoggedIn = this.isLoggedIn;
  }
}

export default NavbarModule;
