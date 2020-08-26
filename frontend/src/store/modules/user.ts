import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";
import {
  UserLoginModel,
  UserRegisterModel,
  UserLoginResponseModel,
} from "@/models/interfaces/User.ts";
import { userService } from "@/services/userService";
import router from "@/router/";

@Module({ namespaced: true })
class UserModule extends VuexModule {
  @Action
  public async login(userData: UserLoginModel): Promise<void> {
    var response = await userService.login(userData);
    this.processUserLogin(response);
  }

  @Action
  public async register(userData: UserRegisterModel): Promise<void> {
    var response = await userService.register(userData);
    this.processUserLogin(response);
  }

  private processUserLogin(userLoginResponse: UserLoginResponseModel) {
    if (userLoginResponse.statusCode == 200) {
      localStorage.setItem("token", userLoginResponse.token);
      router.push("/");
    } else {
      //TODO show message
    }
  }
}
export default UserModule;
