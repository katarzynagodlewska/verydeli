import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";
import { UserLoginModel, UserRegisterModel } from "@/models/interfaces/User.ts";

@Module({ namespaced: true })
class UserModule extends VuexModule {
  @Action
  public login(userData: UserLoginModel): void {
    console.log(userData.password);
    console.log(userData.email);
  }
  @Action
  public register(userData: UserRegisterModel) {
    console.log(userData);
  }
}
export default UserModule;
