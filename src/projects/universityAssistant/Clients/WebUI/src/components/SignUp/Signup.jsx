import React, { useState } from "react";
import InputField from "../common/InputField/InputField";
import "../SignIn/Signin.css";
import { FaUser } from "react-icons/fa";
import { RiLockPasswordLine } from "react-icons/ri";
import { AiOutlineMail } from "react-icons/ai";
import AuthServices from "../../Services/AuthServices";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";
const Signup = () => {
  let navigate = useNavigate()
  let authServices = new AuthServices();
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  
  function register(e) {
    e.preventDefault();
    authServices
      .Register(username, email, password)
      .then((res) => {
        console.log(res);
        localStorage.setItem("token", res.data.accessToken.token);
        toast.success("Üyelik başarılı,yönlendiriliyorsunuz...",{
          autoClose:1500
        });
        setTimeout(() => {
          navigate("/email-confirmed")
        }, 1000);
      })
      .catch((err) => {
        toast.error(err.response.data.Detail);
        err.response.data.Errors.map((res) => toast.error(res.ErrorMessage));
      });
  }
  return (
    <div className="div">
      <form onSubmit={register} className="signin-form">
        <h3>Üye Ol</h3>
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

export default Signup;
