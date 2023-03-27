
import React from "react";
import "./Signin.css";
import { FaUser } from "react-icons/fa";
import { RiLockPasswordLine } from "react-icons/ri";
import InputField from "../common/InputField/InputField";
import axios from "axios";

const Signin = () => {
  console.log(process.env.REACT_APP_API_URL + "/Auth/Login");

  axios.post(process.env.REACT_APP_API_URL + "/Auth/Login",{
    email:"asd@asd.com",
    password:"123456"
  }).then(res => console.log(res)).catch(err => console.log(err))
  
  return (
    <div className="div">
      {/* <div class="background">
        <div class="shape"></div>
        <div class="shape"></div>
    </div> */}
      <form className="signin-form">
        <h3>Giriş Yap</h3>
        <div className="signin-form-input-div">
          <FaUser className="signin-fa-user" />
          <InputField
            className="signin-form-input"
            type="text"
            placeholder="Kullanıcı adı"
            id="username"

          />
        </div>

        <div className="signin-form-input-div">
          <RiLockPasswordLine className="signin-input-passwordicon" />
          <InputField
            className="signin-form-input"
            type="password"
            placeholder="Parola"
            id="password"
          />
        </div>
        <div className="signin-button-div mt-4 button">
          <button className="signin-button button">Giriş Yap</button>
        </div>
        {/* <div class="social">
          <div class="go"><i class="fab fa-google"></i>  Google</div>
          <div class="fb"><i class="fab fa-facebook"></i>  Facebook</div>
        </div> */}
      </form>
    </div>
  );
};

export default Signin;
