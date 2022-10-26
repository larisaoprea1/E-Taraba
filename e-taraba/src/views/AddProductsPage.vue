<template>
  <div class="_container">
    
      <Form
        @submit="handleAddProduct"
        :validation-schema="schema"
        class="_form"
      >
        <div v-if="!successful">
          <h3>Add Product</h3>
          <div class="form-group">
            <label for="name" class="lable_class">Name:</label>
            <Field
              name="name"
              type="text"
              class="form-control field_class"
              placeholder="Name"
            />
            <ErrorMessage name="name" class="error-feedback color" />
          </div>
          <div class="form-group mt-2">
            <label for="description" class="lable_class">Description:</label>
            <Field
              name="description"
              type="text"
              class="form-control field_class"
              placeholder="Description"
            />
            <ErrorMessage name="description" class="error-feedback color" />
          </div>
          <div class="form-group mt-2">
            <label for="productPhoto" class="lable_class">Product Photo:</label>
            <Field
              name="productPhoto"
              type="text"
              class="form-control field_class"
              placeholder="Src"
            />
            <ErrorMessage name="productPhoto" class="error-feedback color" />
          </div>
          <div class="form-group mt-2">
            <label for="quantity" class="lable_class">Quantity</label>
            <Field
              name="quantity"
              type="number"
              class="form-control field_class"
              placeholder="Quantity"
            />
            <ErrorMessage name="quantity" class="error-feedback color" />
          </div>
          <div class="form-group mt-2 ">
            <label for="price" class="lable_class">Price:</label>
            <Field
              name="price"
              type="number"
              class="form-control field_class"
              placeholder="Price"
            />
            <ErrorMessage name="price" class="error-feedback color" />
          </div>
          <hr/>
          <div class="form-group mt-2">
            <button class="btn btn-dark rounded-pill btn-block p-2">
              Add Product
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
</template>
<script>
import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";
export default {
  components: {
    Form,
    Field,
    ErrorMessage,
  },
  data() {
    const schema = yup.object().shape({
      name: yup
        .string()
        .required("Name is required")
        .min(3, "Must be at least 3 characters!")
        .max(50, "Must be maximum 50 characters!"),
      description: yup
        .string()
        .required("Description is required")
        .min(3, "Must be at least 3 characters!")
        .max(100, "Must be maximum 100 characters!"),
      productPhoto: yup.string().required("Product photo is required"),
      quantity: yup.number().required("Quantity is required!"),
      price: yup.number().required("Price is required"),
    });
    return {
      successful: false,
      message: "",
      schema,
    };
  },

  methods: {
    handleAddProduct(product) {
      this.message = "";
      this.successful = false;
      this.loading = true;
      this.$store
        .dispatch("product/addProductEvent", product)
        .then(() => {
          this.successful = true;
          this.$router.push("/");
        })
        .catch((error) => {
          this.message =
            (error.response &&
              error.response.data &&
              error.response.data.message) ||
            error.message ||
            error.toString();
          this.successful = false;
        });
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
}
</style>