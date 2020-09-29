import Vue from "vue";
import Vuex from "vuex";
import cart from "@/store/modules/cart";
import user from "@/store/modules/user";
import navbar from "@/store/modules/navbar";
import navbarCart from "@/store/modules/navbarCart";
Vue.use(Vuex);
const store = new Vuex.Store({
  modules: {
    user,
    navbar,
    navbarCart,
    cart,
  },
});
export default store;
