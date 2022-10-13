import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import ElementPlus from "element-plus";
import "element-plus/dist/index.css";
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import VueAnimateOnScroll from "vue-animate-onscroll";
import Toast, { POSITION } from "vue-toastification";
import "vue-toastification/dist/index.css";

import {
  faHome,
  faUser,
  faUserPlus,
  faSignInAlt,
  faSignOutAlt,
  faShoppingBag,
  faCartShopping,
  faCreditCard,
  faTruck,
  faCalendar,
  faTrashCan,
} from "@fortawesome/free-solid-svg-icons";

library.add(
  faHome,
  faUser,
  faUserPlus,
  faSignInAlt,
  faSignOutAlt,
  faShoppingBag,
  faCartShopping,
  faCreditCard,
  faTruck,
  faCalendar,
  faTrashCan
);
createApp(App)
  .use(store)
  .use(router)
  .use(ElementPlus)
  .use(VueAnimateOnScroll)
  .use(Toast, {
    position: POSITION.TOP_RIGHT,
  })
  .component("font-awesome-icon", FontAwesomeIcon)
  .mount("#app");
