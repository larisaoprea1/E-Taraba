<template>
  <div class="col-md-12">
      <Form @submit="handleRegister" :validation-schema="schema">
        <div v-if="!successful">
          <div class="form-group">
            <label for="userName">Username</label>
            <Field name="userName" type="text" class="form-control" />
            <ErrorMessage name="userName" class="error-feedback" />
          </div>
          <div class="form-group">
            <label for="email">Email</label>
            <Field name="email" type="email" class="form-control" />
            <ErrorMessage name="email" class="error-feedback" />
          </div>
          <div class="form-group">
            <label for="firstName">First Name</label>
            <Field name="firstName" type="text" class="form-control" />
            <ErrorMessage name="firstName" class="error-feedback" />
          </div>
          <div class="form-group">
            <label for="lastName">Last Name</label>
            <Field name="lastName" type="text" class="form-control" />
            <ErrorMessage name="lastName" class="error-feedback" />
          </div>
          <div class="form-group">
            <label for="phoneNumber">Phone Number</label>
            <Field name="phoneNumber" type="tel" class="form-control" />
            <ErrorMessage name="phoneNumber" class="error-feedback" />
          </div>
          <div class="form-group">
            <label for="profileImageSrc">Profile Image</label>
            <Field name="profileImageSrc" value='https://nationaltoday.com/wp-content/uploads/2020/08/international-cat-day.jpg' type="url" class="form-control" />
            <ErrorMessage name="profileImageSrc" class="error-feedback" />
          </div>
          <div class="form-group">
            <label for="password">Password</label>
            <Field name="password" type="password" class="form-control" />
            <ErrorMessage name="password" class="error-feedback" />
          </div>
          <div class="form-group">
            <button class="btn btn-primary btn-block" :disabled="loading">
              <span
                v-show="loading"
                class="spinner-border spinner-border-sm"
              ></span>
              Sign Up
            </button>
          </div>
        </div>
      </Form>

      <div
        v-if="message"
        class="alert"
        :class="successful ? 'alert-success' : 'alert-danger'"
      >
        {{ message }}
      </div>
    </div>
</template>

<script>
import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";

export default {
  name: "RegisterName",
  components: {
    Form,
    Field,
    ErrorMessage,
  },
  data() {
    const schema = yup.object().shape({
      userName: yup
        .string()
        .required("Username is required!")
        .min(3, "Must be at least 3 characters!")
        .max(20, "Must be maximum 20 characters!"),
      email: yup
        .string()
        .required("Email is required!")
        .email("Email is invalid!")
        .max(50, "Must be maximum 50 characters!"),
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
      phoneNumber: yup
        .string()
        .required("Phone number is required")
        .nullable(),
      profileImageSrc: yup
        .string()
        .required("Photo is required"),
      password: yup
        .string()
        .required("Password is required!")
        .min(6, "Password is too small!")
        .max(40, "Password is too long!")
        .matches(/^(?=.*[a-z])/, 'Must contain at least one lowercase character')
        .matches(/^(?=.*[A-Z])/, 'Must contain at least one uppercase character')
        .matches(/^(?=.*[0-9])/, 'Must contain at least one number')
        .matches(/^(?=.*[!@#%&])/, 'Must contain at least one special character'),
    });

    return {
      successful: false,
      loading: false,
      message: "",
      schema,
    };
  },
  computed: {
    loggedIn() {
      return this.$store.state.auth.status.loggedIn;
    },
  },
  mounted() {
    if (this.loggedIn) {
      this.$router.push("/");
    }
  },
  methods: {
    handleRegister(user) {
      this.message = "";
      this.successful = false;
      this.loading = true;

      this.$store.dispatch("auth/register", user).then(
        (data) => {
          this.message = data.message;
          this.successful = true;
          this.loading = false;
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

</style>