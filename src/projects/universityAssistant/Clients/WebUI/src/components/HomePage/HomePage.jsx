import axios from "axios";
import React, { useState } from "react";
import Decor from "../common/Decor/Decor";
import Navbar from "../common/Navbar/Navbar";
import PopupComponent from "../common/popupBox/PopupComponent";
import Signin from "../SignIn/Signin";
import "./HomePage.css";
const HomePage = () => {
  const [first, setfirst] = useState("")
  axios.get("").then(res => console.log(res)).catch(err => console.log(err))
  return (
    <div className="home-page">
      {/* <div className="home-page-h1-div">
        <h1 className="home-page-h1">üniversite asistanı</h1>
      </div> */}

      {/* <div class="container container2 text-center">
        <div class="row bubble-main-div ">
          <div class="col-xl-4">
            <div className="home-page-bubble-1">
              <img className="communitypng" src="img/communitypng.png" alt="" />
              <p className="home-page-bubble-1-text">Tartışma başlat.</p>
            </div>
          </div>
          <div class="col-xl-4">
            <div className="home-page-bubble-2">
              <img
                className="universitypng"
                src="img/universitypng.png"
                alt=""
              />
              <p className="home-page-bubble-1-text">Üniversiteleri incele.</p>
            </div>
          </div>
          <div class="col-xl-4">
            <div className="home-page-bubble-3">
              <img className="communitypng" src="img/communitypng.png" alt="" />
              <p className="home-page-bubble-1-text">Sohbet odalarına git.</p>
            </div>
          </div>
        </div>
      </div> */}
      <section class="about_section layout_padding">
        <div class="container">
          <h2>Üniversite Asistanına hoşgeldin.</h2>
          {/* <p>
           Sadece birkaç tanesi.
          </p> */}
        </div>

        <div class="container">
          <div class="about_card-container">
            <div className="row">
              <div className="col-xl-4 col-lg-2 col-md-6">
                <div class="about_card">
                  <div class="about-detail">
                    <div class="about_img-box">
                      <img src="img/forum.png" alt="" />
                    </div>
                    <div class="card_detail-ox">
                      <h4>Forum'a Geç</h4>
                      <p>
                        Aklındaki soruları cevapsız bırakma.
                      </p>
                      <div>
                    <a href="" class="about_btn">
                      Git
                    </a>
                  </div>
                    </div>
                  </div>
                  
                </div>
              </div>
              <div className="col">
                <div class="about_card">
                  <div class="about-detail">
                    <div class="about_img-box">
                      <img src="img/universitypng.png" alt="" />
                    </div>
                    <div class="card_detail-ox">
                      <h4>Üniversiteleri Tanı</h4>
                      <p>
                        Hedeflediğin üniversiteyle ilgili tüm bilgileri gör, üniversitedeki öğrencilerin görüşlerini incele.
                      </p>
                      <div>
                    <a href="" class="about_btn">
                    Git
                    </a>
                  </div>
                    </div>
                    
                  </div>
                  
                </div>
              </div>
              <div className="col">
                <div class="about_card">
                  <div class="about-detail">
                    <div class="about_img-box">
                      <img src="img/communitypng.png" alt="" />
                    </div>
                    <div class="card_detail-ox">
                      <h4>Sohbet Odaları  </h4>
                      <p>
                       Toplulukla tanış, canlı olarak insanlarla sohbet et çalışma arkadaşları edin.
                      </p>
                      <div>
                    <a href="" class="about_btn">
                    Git
                    </a>
                  </div>
                    </div>
                  </div>
                
                </div>
              </div>
              
            </div>
          </div>
        </div>
      </section>
    </div>
  );
};

export default HomePage;
