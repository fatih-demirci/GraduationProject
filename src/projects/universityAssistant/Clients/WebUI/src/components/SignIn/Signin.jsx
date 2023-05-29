
import React, { useEffect, useState } from "react";
import "./Signin.css";
import { FaUser } from "react-icons/fa";
import { RiLockPasswordLine } from "react-icons/ri";
import InputField from "../common/InputField/InputField";
import axios from "axios";
import AuthServices from "../../Services/AuthServices";
import { Link, useNavigate } from "react-router-dom";
import UserServices from "../../Services/UserServices";
import { toast } from "react-toastify";
import { AiOutlineMail } from "react-icons/ai";
import jwt_decode from "jwt-decode";

const Signin = () => {
  const [email, setEmail] = useState("")
  const [password, setPassword] = useState("")
  let authServices = new AuthServices();
  let userServices = new UserServices();
  let navigate = useNavigate()
  let decode;
  
  useEffect(() => {
    userServices.UpdateProfilePhoto();
  }, [])
  
  function login(e) {
    e.preventDefault()
    authServices.Login(email,password).then((res) => {
      console.log(res.data);
      localStorage.setItem("token",res.data.accessToken.token);
      localStorage.setItem("refreshToken",res.data.refreshToken.token)
      authServices.LoginRefreshToken().then(res => console.log(res)).catch(err => console.log(err))
      console.log(authServices.JWTDecode().EmailConfirmed==="True" ? console.log("evet") : console.log("hayır"));
      if (authServices.JWTDecode().EmailConfirmed ==="True") {
        toast.success("Giriş başarılı",{
          autoClose:1500,
        })
         setTimeout(() => {
        navigate("/")
        }, 1500);
      } else {
        toast.warn("Lütfen e-posta hesabınızı onaylayın.Yönlendiriliyorsunuz.",{
          autoClose:1500,
        })
         setTimeout(() => {
        navigate("/email-confirmed")
        }, 1500);
        
      }
    })
    .catch((err) => console.log(err));
    
  } 
  return (
    <div className="div">
      {/* <div class="background">
        <div class="shape"></div>
        <div class="shape"></div>
    </div> */}
      <form onSubmit={login} className="signin-form">
        <h3>Giriş Yap</h3>
        <div className="signin-form-input-div">
        <AiOutlineMail className="signin-fa-user" />
          <InputField
            className="signin-form-input"
            type="text"
            placeholder="E-Posta"
            id="email"
            value={email}
            setState={setEmail}

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
