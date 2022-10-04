<template>
    
  Register
  </template>

  <script>
    import User from "@/models/user";
    export default{
      name:'RegisterPage',
      data(){
        return{
          user: new User('','','','','','https://nationaltoday.com/wp-content/uploads/2020/08/international-cat-day.jpg',''),
          submitted: false,
          successful: false,
          message: ''
        };
      },
      computed: {
        loggedIn(){
          return this.$store.state.auth.status.loggedIn;
        }
      },
      mounted(){
        if(this.loggedIn){
          this.$router.push('/');
        }
      },
      methods:{
        handleRegister(){
          this.message = '';
          this.submitted = true;
          this.$validator.validate().then(isValid =>{
            if(isValid){
              this.$store.dispatch('auth/register', this.user)
              .then(data =>{
                this.message= data.message;
                this.successful =true;
              })
              .catch(err =>{
                this.message = (err.res && err.res.data) || err.message || err.toString();
                this.successful = false;
              });
            }
          });
        }
      }
    }
  </script>