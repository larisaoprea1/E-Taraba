<template>
  <div>
    <p>Order Page</p>
    <div class="_container">
      <Form
        @submit="saveOrderFormHandler"
        :validation-schema="schema"
        class="_form"
      >
        <div v-if="!successful">
          <div class="form-group">
            <label for="firstName" class="lable_class">First Name:</label>
            <Field
              name="firstName"
              type="text"
              class="form-control field_class"
              placeholder="First Name"
            />
            <ErrorMessage name="firstName" class="error-feedback color" />
          </div>
          <div class="form-group mt-2">
            <label for="lastName" class="lable_class">Last Name:</label>
            <Field
              name="lastName"
              type="text"
              class="form-control field_class"
              placeholder="Last Name"
            />
            <ErrorMessage name="lastName" class="error-feedback color" />
          </div>
          <div class="form-group mt-2">
            <label for="phoneNumber" class="lable_class">Phone Number</label>
            <Field
              name="phoneNumber"
              type="tel"
              class="form-control field_class"
              placeholder="Phone Number"
            />
            <ErrorMessage name="phoneNumber" class="error-feedback color" />
          </div>
          <div class="form-group mt-2">
            <label for="email" class="lable_class">Email:</label>
            <Field
              name="email"
              type="email"
              class="form-control field_class"
              placeholder="example@try.com"
            />
            <ErrorMessage name="email" class="error-feedback color" />
          </div>
          <div class="form-group mt-2">
            <label for="address" class="lable_class">Address</label>
            <Field
              name="address"
              type="tel"
              class="form-control field_class"
              placeholder="Address"
            />
            <ErrorMessage name="address" class="error-feedback color" />
          </div>
          <div class="form-group mt-2">
            <label for="city" class="lable_class">City:</label>
            <Field
              name="city"
              type="text"
              class="form-control field_class"
              placeholder="City"
            />
            <ErrorMessage name="city" class="error-feedback color" />
          </div>
          <div class="form-group mt-2">
            <label for="country" class="lable_class">Country:</label>
            <Field
              name="country"
              type="text"
              class="form-control field_class"
              placeholder="Country"
            />
            <ErrorMessage name="country" class="error-feedback color" />
          </div>
          Your order:

          <div class="form-group mt-2">
            <button class="btn btn-dark rounded-pill btn-block p-2">
              Order
            </button>
          </div>
          <div
            v-if="message"
            class="alert"
            :class="successful ? 'alert-success' : 'alert-danger'"
          >
            {{ message }}
          </div>
        </div>
      </Form>
    </div>
  </div>
</template>

<script>
import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";

export default {
  name: "RegisterPage",
  components: {
    Form,
    Field,
    ErrorMessage,
  },
  data() {
    const schema = yup.object().shape({
      firstName: yup
        .string()
        .required("First Name is required")
        .min(3, "Must be at least 3 characters!")
        .max(20, "Must be maximum 20 characters!"),
      lastName: yup
        .string()
        .required("Last Name is required")
        .min(3, "Must be at least 3 characters!")
        .max(20, "Must be maximum 20 characters!"),
      phoneNumber: yup.string().required("Phone number is required").nullable(),
      email: yup
        .string()
        .required("Email is required!")
        .email("Email is invalid!")
        .max(50, "Must be maximum 50 characters!"),
      address: yup
        .string()
        .required("Address is required")
        .max(70, "Must be 70 characters"),
      city: yup.string().required("City is required"),
      country: yup.string().required("Country is required"),
    });
    return {
      successful: false,
      loading: false,
      message: "",
      schema,
    };
  },
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    },
  },
  methods: {
    saveOrderFormHandler(order) {
      this.message = "";
      this.successful = false;
      this.loading = true;
      console.log("ORDER");
      this.$store
        .dispatch("order/saveOrderEvent", {
          userid: this.currentUser.user.Id,
          order: order,
        })
        .then(
          () => {
            // this.message = data.message;
            this.successful = true;
            this.loading = false;
            this.$router.push("/");
          },
          (error) => {
            this.message =
              (error.response &&
                error.response.data &&
                error.response.data.message) ||
              error.message ||
              error.toString();
            this.successful = false;
            this.loading = false;
          }
        );
    },
  },
};
</script>

<style scoped>
._container {
  display: flex;
  justify-content: center;
}
._form {
  width: 400px;
  padding: 10px;
  margin: 10px;
}
</style>
