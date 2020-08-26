import { VuexModule, Module, Mutation, Action } from "vuex-module-decorators";
import { UserLoginModel, UserRegisterModel } from "@/models/interfaces/User.ts";
import { userService } from "@/services/userService";
import router from "@/router/";

@Module({ namespaced: true })
class UserModule extends VuexModule {
  @Action
  public async login(userData: UserLoginModel): Promise<void> {
    var response = await userService.login(userData);

    if (response.statusCode == 200) {
      localStorage.setItem("token", response.token);
      router.push("/");
    } else {
      //TODO show message
    }
  }
  @Action
  public register(userData: UserRegisterModel) {
    console.log(userData);
    console.log(process.env.VUE_APP_VERYDELI_API_URL_BASE);
  }
}
export default UserModule;
