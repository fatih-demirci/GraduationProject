import React from "react";
import PopupComponent from "../popupBox/PopupComponent";
import "./Navbar.css";
import { toast } from "react-toastify";
import { Navigate, useNavigate } from "react-router-dom";

const Navbar = () => {
  let navigate = useNavigate();
  function close() {
    localStorage.removeItem("token");
    localStorage.removeItem("refreshToken")
    toast.success("Çıkış yapılıyor.", {
      autoClose: 1500,
    });
    setTimeout(() => {
      navigate("/signin");
    }, 1500);
  }
  return (
    <>
      <nav class="navbar navbar-expand-lg fixed-top  navbar-custom container">
        <div class="container-fluid d-flex justify-content-between">
          <a class="navbar-brand" href="/">
            Üniversite Asistanı
          </a>
          <button
            class="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span class="navbar-toggler-icon"></span>
          </button>

          <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav m-auto">
              <li class="nav-item">
                <a class="nav-link" href="/">
                  Ana Sayfa
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/chat">
                  Sohbet Odaları
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/university-guide">
                  Üniversite Rehber
                </a>
              </li>
            </ul>
            {localStorage.getItem("token") ? (
              <ul class="navbar-nav">
                <li class="nav-item">
                  <a class="nav-link" href="/profile">
                    Profil
                  </a>
                </li>
                <li class="nav-item">
                  <button onClick={close} href="/signup" class="nav-link ">
                    Çıkış Yap
                  </button>
                </li>
                {/* <li class="nav-item">
                <a href="/profile" class="nav-link d-flex ">
                  <img className="navbar-user-png" src="img/userpng.png" alt="" />
                  <div className="ms-2">
                  username123
                  </div>
                </a>
            </li> */}
              </ul>
            ) : (
              <ul class="navbar-nav">
                <li class="nav-item">
                  <a class="nav-link" href="/signin">
                    Giriş Yap
                  </a>
                </li>
                <li class="nav-item">
                  <a href="/signup" class="nav-link ">
                    Üye Ol
                  </a>
                </li>
                {/* <li class="nav-item">
                    <a href="/profile" class="nav-link d-flex ">
                      <img className="navbar-user-png" src="img/userpng.png" alt="" />
                      <div className="ms-2">
                      username123
                      </div>
                    </a>
                </li> */}
              </ul>
            )}
          </div>
        </div>
      </nav>
    </>
  );
};

export default Navbar;
