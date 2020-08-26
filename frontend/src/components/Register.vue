<template>
  <section class="register">
    <h2 class="register__title">REGISTER</h2>
    <form @submit.prevent="handleSubmit" class="register__form">
      <label class="register__email--label" for="register-email">Email</label>
      <input
        class="register__email--input"
        type="email"
        v-model="userData.email"
        id="register-email"
      />
      <label class="register__name--label" for="register-name">Name</label>
      <input class="register__name--input" type="text" v-model="userData.name" id="register-name" />
      <label class="register__surname--label" for="register-surname">Surname</label>
      <input
        class="register__surname--input"
        type="text"
        v-model="userData.surname"
        id="register-surname"
      />
      <label class="register__password--label" for="register-password">Password</label>
      <input
        class="register__password--input"
        type="password"
        v-model="userData.password"
        id="register-password"
      />
      <button class="button-sign-up" type="submit">Sign up</button>
    </form>
  </section>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { UserRegisterModel } from "../models/interfaces/User";
import { namespace } from "vuex-class";
const user = namespace("user");

@Component({
  components: {},
  name: "Register",
})
export default class Register extends Vue {
  public userData: UserRegisterModel = {
    name: "",
    surname: "",
    email: "",
    password: "",
  };

  @user.Action
  public register!: (userData: UserRegisterModel) => void;

  public handleSubmit() {
    this.register(this.userData);
  }
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/register.scss";
</style>