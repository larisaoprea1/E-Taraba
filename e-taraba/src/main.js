import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import ElementPlus from "element-plus";
import "element-plus/dist/index.css";
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import "primevue/resources/primevue.min.css";
import "primeicons/primeicons.css";
import "primevue/resources/themes/lara-light-blue/theme.css";
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import VueAnimateOnScroll from "vue-animate-onscroll";
import Toast, { POSITION } from "vue-toastification";
import PrimeVue from 'primevue/config';
import Image from 'primevue/image';
import Badge from 'primevue/badge';
import BadgeDirective from "primevue/badgedirective";
import DialogService from 'primevue/dialogservice'
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
  .use(PrimeVue)
  .use(DialogService)
  .directive('badge', BadgeDirective)
  .component('Image', Image)
  .component('Badge', Badge)
  .use('vue-moment')
  .component("font-awesome-icon", FontAwesomeIcon)
  .mount("#app");
