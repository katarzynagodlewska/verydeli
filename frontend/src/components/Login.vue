<template>
  <section class="login">
    <h2 class="login_title">LOGIN</h2>
    <form>
      <label class="login__username--label" for="login-username">Email</label>
      <input class="login__username--input" name="login-username" v-model="user.email" type="email" />
      <label class="login__password--label" for="login-password">Password</label>
      <input
        class="login__passwor--input"
        name="login-password>"
        v-model="user.password"
        type="password"
      />
      <button class="button-log-in" type="submit">Log in</button>
    </form>
  </section>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
//import { User } from "../models/interfaces/User";
@Component({
  components: {},
  name: "Login",
})
export default class Login extends Vue {
  public user: any = {
    name: "",
    surname: "",
    email: "",
    password: "",
  };
}
</script>
