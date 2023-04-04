import React from "react";
import PopupComponent from "../popupBox/PopupComponent";
import "./Navbar.css";

const Navbar = () => {
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
                    <a class="nav-link" href="/">Ana Sayfa</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="/forum">Forum</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="/university-guide">Üniversite Rehber</a>
                </li>
               
            </ul>
           
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href="/signin">Giriş Yap</a>
                </li>
                <li class="nav-item">
                    <a href="/signup" class="nav-link ">Üye Ol</a>
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
        </div>
         
        </div>
      </nav>
   
    </>
  );
};

export default Navbar;
