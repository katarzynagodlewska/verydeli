import Vue from "vue";
import Vuex from "vuex";
import user from "@/store/modules/user";
import navbar from "@/store/modules/navbar";
Vue.use(Vuex);
const store = new Vuex.Store({
  modules: {
    user,
    navbar,
  },
});
export default store;
