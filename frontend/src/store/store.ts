import Vue from "vue";
import Vuex from "vuex";
import cart from "@/store/modules/cart";
import user from "@/store/modules/user";
import navbar from "@/store/modules/navbar";
import navbarCart from "@/store/modules/navbarCart";
import foodList from "@/store/modules/foodList";
import foodItemCard from "@/store/modules/foodItemCard";
import counter from "@/store/modules/counter";
import foodItem from "@/store/modules/foodItem";
import searchItemList from "@/store/modules/searchItemList";

Vue.use(Vuex);
const store = new Vuex.Store({
  modules: {
    user,
    navbar,
    navbarCart,
    cart,
    foodList,
    foodItemCard,
    counter,
    foodItem,
    searchItemList,
  },
});
export default store;
