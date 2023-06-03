import axios from "axios";
import { useNavigate } from "react-router-dom";
import jwt_decode from "jwt-decode";
export default class AuthServices {
  
  Login(username, password) {
    return axios.post(process.env.REACT_APP_API_URL + "/Auth/Login", {
      email: username,
      password: password,
    });
  }

  Register(username, email, password) {
    return axios.post(process.env.REACT_APP_API_URL + "/Auth/Register", {
      userName: username,
      email: email,
      password: password,
    });
  }

  JWTDecode() {
    return jwt_decode(localStorage.getItem("token"));
  }

  LoginRefreshToken(token) {
    return axios.post(
      process.env.REACT_APP_API_URL + "/Auth/LoginWithRefreshToken",
      {
        token: token,
      },
      {
        headers: {
          Authorization: `bearer ${localStorage.getItem("token")}`,
        },
      }
    );
  }
}
