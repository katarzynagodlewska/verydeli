import Vue from "vue";
import Vuex from "vuex";
import user from "@/store/modules/user";
import navbar from "@/store/modules/navbar";
import navbarCart from "@/store/modules/navbarCart";
Vue.use(Vuex);
const store = new Vuex.Store({
  modules: {
    user,
    navbar,
    navbarCart,
  },
});
export default store;
