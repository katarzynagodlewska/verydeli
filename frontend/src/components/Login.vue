<template>
  <section class="login">
    <h2 class="login__title">LOGIN</h2>
    <form class="login__form" @submit.prevent="submitForm" :model="userData">
      <label class="login__email--label" for="login-username">Email</label>
      <input class="login__email--input" id="login-username" v-model="userData.email" type="email" />
      <label class="login__password--label" for="login-password">Password</label>
      <input
        class="login__password--input"
        id="login-password"
        type="password"
        v-model="userData.password"
      />
      <button class="button-log-in">Log in</button>
    </form>
    <div class="username">User: {{ email }}</div>
  </section>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { namespace } from "vuex-class";
import { UserLoginModel } from "../models/interfaces/User";
const user = namespace("user");

@Component
export default class Login extends Vue {
  public userData: UserLoginModel = {
    email: "",
    password: "",
  };

  @user.State
  public email!: string;

  @user.Action
  public login!: (userData: UserLoginModel) => void;

  public submitForm(): void {
    this.login(this.userData);
  }
}
</script>

<style lang="scss" scoped>
@import "../styles/modules/login.scss";
</style>
