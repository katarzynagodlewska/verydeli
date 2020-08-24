<template>
  <div class="account">
    <Login />
    <Register />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

import Login from "./Login.vue";
import Register from "./Register.vue";

@Component({
  components: {
    Login,
    Register,
  },
  name: "Account",
})
export default class Account extends Vue {}
</script>

<style lang="scss" scoped>
@import "../styles/modules/account.scss";
</style>