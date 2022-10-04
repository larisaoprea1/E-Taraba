export default class User {
    constructor(userName, email,firstName, lastName, phoneNumber, profileImageSrc, password) {
      this.userName = userName;
      this.email = email;
      this.firstName = firstName;
      this.lastName = lastName;
      this.phoneNumber = phoneNumber;
      this.profileImageSrc = profileImageSrc;
      this.password = password;
    }
  }