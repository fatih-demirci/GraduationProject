
import React, { useState } from "react";
import "./Signin.css";
import { FaUser } from "react-icons/fa";
import { RiLockPasswordLine } from "react-icons/ri";
import InputField from "../common/InputField/InputField";
import axios from "axios";
import AuthServices from "../../Services/AuthServices";

const Signin = () => {
  const [username, setUsername] = useState("")
  const [password, setPassword] = useState("")

  let authServices = new AuthServices();
  
  function login(e) {
    e.preventDefault()
    authServices.Login(username,password)
    
  } 
  console.log(username);
  console.log(password);
  return (
    <div className="div">
      {/* <div class="background">
        <div class="shape"></div>
        <div class="shape"></div>
    </div> */}
      <form onSubmit={login} className="signin-form">
        <h3>Giriş Yap</h3>
        <div className="signin-form-input-div">
          <FaUser className="signin-fa-user" />
          <InputField
            className="signin-form-input"
            type="text"
            placeholder="Kullanıcı adı"
            id="username"
            value={username}
            setState={setUsername}

          />
        </div>

        <div className="signin-form-input-div">
          <RiLockPasswordLine className="signin-input-passwordicon" />
          <InputField
            className="signin-form-input"
            type="password"
            placeholder="Parola"
            id="password"
            value={password}
            setState={setPassword}
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
