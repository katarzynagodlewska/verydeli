import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "/account",
    name: "account",
    component: () => import("../components/Account.vue"),
  },
  {
    path: "/",
    name: "home",
    component: () => import("../components/Home.vue"),
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
