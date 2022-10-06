<template>
    <div class="container form_container">
      <Form @submit="handleRegister" :validation-schema="schema">
        <p class="title_class">Welcome to E-Taraba</p>
        <hr class="line__" />
        <div v-if="!successful">
          <div class="form-group">
            <label for="userName" class="lable_class">Username:</label>
            <Field
              name="userName"
              type="text"
              class="form-control field_class"
              placeholder="Username"
            />
            <ErrorMessage name="userName" class="error-feedback color" />
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
            <label for="profileImageSrc" class="lable_class"
              >Profile Image:</label
            >
            <Field
              name="profileImageSrc"
              value="https://nationaltoday.com/wp-content/uploads/2020/08/international-cat-day.jpg"
              type="url"
              class="form-control field_class"
            />
            <ErrorMessage name="profileImageSrc" class="error-feedback color" />
          </div>
          <div class="form-group mt-2">
            <label for="password" class="lable_class">Password:</label>
            <Field
              name="password"
              type="password"
              class="form-control field_class"
              placeholder="Password"
            />
            <ErrorMessage name="password" class="error-feedback color" />
          </div>
          <p class="mt-2 loginnow">
            You already have an account?
            <router-link :to="{ name: 'login' }">Login</router-link>
          </p>
          <div class="form-group">
            <button
              class="btn btn-dark rounded-pill btn-block p-2 "
              :disabled="loading"
            >
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
  name: "RegisterPage",
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
      phoneNumber: yup.string().required("Phone number is required").nullable(),
      profileImageSrc: yup.string().required("Photo is required"),
      password: yup
        .string()
        .required("Password is required!")
        .min(6, "Password is too small!")
        .max(40, "Password is too long!")
        .matches(
          /^(?=.*[a-z])/,
          "Must contain at least one lowercase character"
        )
        .matches(
          /^(?=.*[A-Z])/,
          "Must contain at least one uppercase character"
        )
        .matches(/^(?=.*[0-9])/, "Must contain at least one number")
        .matches(
          /^(?=.*[!@#%&])/,
          "Must contain at least one special character"
        ),
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
          this.$router.push("/login");
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
.color {
  color: red;
  font-weight: bold;
}
.input_class {
  max-width: 250px;
}
.lable_class {
  float: left;
  font-size: medium;
  font-weight: 400;
}
.form_container {
  background-color: white;
  width: 500px;
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 20px;
  margin-top: 30px;
  border: 1px solid rgb(238, 238, 238);
  box-shadow: #133627 0px 38px 60px 0px;
}
.field_class:hover,
.field_class:focus {
  box-shadow: 0 0 5pt 2pt #2d694f;
}
.title_class {
  font-size: x-large;
  font-weight: bold;
  background-image: linear-gradient(45deg, #42b983, #000000);
  background-size: 100%;
  background-repeat: repeat;
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  -moz-background-clip: text;
  -moz-text-fill-color: transparent;
}
.line__ {
  border-color: #133627;
}
@media (max-width: 550px) {
  .form_container {
    width: 300px;
    padding: 10px;
    margin-top: 60px;
    align-items: center;
  }
  .lable_class {
    float: left;
    font-size: small;
    font-weight: 400;
  }
  .title_class {
    font-size: large;
  }

  .container .loginnow{
    padding: 0;
    margin: 0;
    font-size: small;
  }
  .container p{
    margin: 0;
  }
  .field_class{
    max-width: 250px;
  }
  
}
@media (max-width: 375px){
  .form_container {
  margin-top: 0;
  }
}

</style>
