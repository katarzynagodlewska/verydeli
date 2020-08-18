<template>
  <section class="login">
    <h2 class="login_title">LOGIN</h2>
    <form>
      <label class="login__username--label" for="login-username">Email</label>
      <input class="login__username--input" name="login-username>" />
      <label class="login__password--label" for="login-password"
        >Password</label
      >
      <input class="login__passwor--input" name="login-password>" />
    </form>
  </section>
</template>

<script lang="ts">
import Vue from "vue";
export default class Login extends Vue {}
</script>
