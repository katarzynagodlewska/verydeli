<template>
  <section class="register">
    <h2 class="register_title">REGISTER</h2>
    <form @submit.prevent="handleSubmit">
      <label class="register__email--label" for="register-email">Email</label>
      <input
        class="register__email--input"
        type="email"
        v-model="user.email"
        name="register-email>"
      />
      <label class="register__name--label" for="register-name">Name</label>
      <input class="register__name--input" type="text" v-model="user.name" name="register-name>" />
      <label class="register__surname--label" for="register-surname">Surname</label>
      <input
        class="register__surname--input"
        type="text"
        v-model="user.surname"
        name="register-surname>"
      />
      <label class="register__password--label" for="register-password">Password</label>
      <input
        class="register__password--input"
        type="password"
        v-model="user.password"
        name="register-password>"
      />
      <button type="submit">SUBMIT</button>
    </form>
  </section>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
//import { User } from "../models/interfaces/User";

@Component({
  components: {},
  name: "Register",
})
export default class Register extends Vue {
  mounted() {
    console.log("test");
    console.log(this.user);
    this.user.name = "tes2name";
  }

  public user: any = {
    name: "",
    surname: "",
    email: "",
    password: "",
  };
  // @Prop({ type: Object as () => User }) public user!: User;
  // @Prop() readonly msg!: string;
  //  private user: User = {
  //     email: "";
  //     name: "";
  //     surname: "";
  //     password: "";
  //   };,
  public handleSubmit() {
    console.log("submmit");
    console.log(this.user);
  }
}
</script>
