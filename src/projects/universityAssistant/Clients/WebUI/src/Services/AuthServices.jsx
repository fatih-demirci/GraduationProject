import axios from "axios";

export default class AuthServices {
  Login(username, password) {
    return axios
      .post(process.env.REACT_APP_API_URL + "/Auth/Login", {
        email: username,
        password: password,
      })
      .then((res) => {
        console.log(res);

        console.log(res.data.refreshToken);
      })
      .catch((err) => console.log(err));
  }
  Register(username, email, password) {
    return axios
      .post(process.env.REACT_APP_API_URL + "/Auth/Register", {
        userName: username,
        email: email,
        password: password,
      })
      .then((res) => console.log(res))
      .catch((err) => console.log(err));
  }
}
