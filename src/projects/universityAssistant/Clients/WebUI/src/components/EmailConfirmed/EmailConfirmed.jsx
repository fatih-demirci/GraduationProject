import axios from "axios";
import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import "./EmailConfirmed.css";
import EmailServices from "../../Services/EmailServices";
import { toast } from "react-toastify";

const EmailConfirmed = () => {
  const [otp, setOtp] = useState(new Array(6).fill(""));
  let emailServices = new EmailServices()
  let navigate = useNavigate()

  useEffect(() => {
    emailServices.SendEmailConfirmation()
  
  }, [])
  
  function disabledButtonConfirm() {
    document.getElementById("inputButtonConfirm").disabled = true;
    setTimeout(() => {
      document.getElementById("inputButtonConfirm").disabled = false;
    }, 3000);
  }
  function disabledButtonSend() {
    document.getElementById("inputButtonSend").disabled = true;
    setTimeout(() => {
      document.getElementById("inputButtonSend").disabled = false;
    }, 15000);
  }
  const handleChange = (element, index) => {
    if (isNaN(element.value)) return false;

    setOtp([...otp.map((d, idx) => (idx === index ? element.value : d))]);

    //Focus next input
    if (element.nextSibling) {
      element.nextSibling.focus();
    }
  };
  function sendMail() {
    emailServices.SendEmailConfirmation()
    
  }

  function confirmEmail() {
    emailServices.ConfirmEmail(otp.join("")).then((res) => {
      console.log(res);
     
      toast.success(res.data.message + " yönlendiriliyorsunuz.",{
        autoClose:1500
      });
      localStorage.removeItem("token")
      localStorage.removeItem("refreshToken")
      setTimeout(() => {
        navigate("/signin")
      }, 1500);
      
    })
    .catch((err) => {
      toast.error(err.response.data.Detail);
      console.log(err);
    });
    
  }
  return (
    <div className="container emailconfirmed-container">
      <div className=" row mt-5">
        <div className="col text-center mt-5">
          <h2>E-Posta Doğrulama</h2>
          <p>Lütfen e-posta gelen doğrulama kodunu aşağıdaki alana girin.</p>
          {otp.map((data, index) => {
            return (
              <input
                className="otp-field"
                type="text"
                name="otp"
                maxLength="1"
                key={index}
                value={data}
                onChange={(e) => handleChange(e.target, index)}
                onFocus={(e) => e.target.select()}
              />
            );
          })}

          <p className="mt-4">
            <button
              type="button"
              className="btn btn-outline-danger me-2"
              onClick={(e) => setOtp([...otp.map((v) => "")])}
            >
              TEMİZLE
            </button>

            <button
              id="inputButtonConfirm"
              type="button"
              className="btn btn-outline-success me-2"
              onClick={() => {disabledButtonConfirm();
                confirmEmail()
              }}
            >
              DOĞRULA
            </button>

            <button
              id="inputButtonSend"
              type="button"
              className={`btn btn-outline-warning send-mail-button `}
              onClick={() => {
                disabledButtonSend();
                sendMail()
              
              }}
            >
              TEKRAR YOLLA
            </button>
          </p>
        </div>
      </div>
    </div>
  );
};

export default EmailConfirmed;
