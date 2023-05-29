import axios from "axios";

export default class UserServices {
  GetUser() {
    return axios
      .get(
        process.env.REACT_APP_API_URL + "/Users/GetUser",
        {
          headers: {
            Authorization: `bearer ${localStorage.getItem("token")}`,
          },
        }
      )
     
  }
  
  UpdateUserName(userName) {
    return axios
      .post(
        process.env.REACT_APP_API_URL + "/Users/Update",
        {
          userName: userName,
        },
        {
          headers: {
            Authorization: `bearer ${localStorage.getItem("token")}`,
          },
        }
      )
      .then((res) => console.log(res))
      .catch((err) => console.log(err));
  }

  UpdateProfilePhoto(formData) {
    return axios
      .post(
        process.env.REACT_APP_API_URL + "/Users/UpdateProfilePhoto",
        formData,
        {
          headers: {
            "Content-Type": "multipart/form-data",
            Authorization: `bearer ${localStorage.getItem("token")}`,
          },
        }
      )
      .then((res) => console.log(res))
      .catch((err) => console.log(err));
  }
}
