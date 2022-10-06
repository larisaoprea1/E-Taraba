<template>
  <div class="container form_container">
    <Form @submit="handleLogin" :validation-schema="schema">
      <p class="title_class">Welcome to E-Taraba</p>
      <hr class="line__" />
      <div class="form-group">
        <label for="email" class="lable_class">Email:</label>
        <Field name="email" type="text" placeholder="Email" class="form-control field_class" />
        <ErrorMessage name="email" class="error-feedback color" />
      </div>
      <div class="form-group mt-2">
        <label for="password" class="lable_class">Password:</label>
        <Field name="password" type="password" placeholder="Password" class="form-control field_class" />
        <ErrorMessage name="password" class="error-feedback color" />
      </div>

      <div class="form-group">
        <button class="btn btn-dark rounded-pill btn-block mt-2 p-2" :disabled="loading">
          <span
            v-show="loading"
            class="spinner-border spinner-border-sm"
          ></span>
          <span>Login</span>
        </button>
      </div>

      <div class="form-group">
        <div v-if="message" class="alert alert-danger" role="alert">
          {{ message }}
        </div>
      </div>
    </Form>
  </div>
</template>

<script>
import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";

export default {
  name: "LoginPage",
  components: {
    Form,
    Field,
    ErrorMessage,
  },
  data() {
    const schema = yup.object().shape({
      email: yup
        .string()
        .required("Email is required!")
        .email("Email is invalid!")
        .max(50, "Must be maximum 50 characters!"),
      password: yup.string().required("Password is required!"),
    });

    return {
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
  created() {
    if (this.loggedIn) {
      this.$router.push("/");
    }
  },
  methods: {
    handleLogin(user) {
      this.loading = true;

      this.$store.dispatch("auth/login", user).then(
        () => {
          this.$router.push("/");
        },
        (error) => {
          this.loading = false;
          this.message =
            (error.response &&
              error.response.data &&
              error.response.data.message) ||
            error.message ||
            error.toString();
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
  margin-top: 100px;
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
@media (max-width: 850px){
    .form_container{
        margin-top: 150px;
    }
}
@media (max-width: 550px) {
  .form_container {
    width: 300px;
    padding: 10px;
    margin-top: 200px;
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
  margin-top: 100px;
  }
}
</style>
