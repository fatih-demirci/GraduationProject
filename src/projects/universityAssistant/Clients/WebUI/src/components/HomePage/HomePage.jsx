import axios from "axios";
import React, { useState } from "react";
import Decor from "../common/Decor/Decor";
import Navbar from "../common/Navbar/Navbar";
import PopupComponent from "../common/popupBox/PopupComponent";
import Signin from "../SignIn/Signin";
import "./HomePage.css";
import jwtDecode from "jwt-decode";
import { Link } from "react-router-dom";
const HomePage = () => {
  return (
    <div className="container">
      {/* <h2>Üniversite Asistanına hoşgeldin.</h2> */}
      <div class="about_card-container">
        <Link to={"/forum"}>
        <div class="about_card about_card_left">
          <div class="about-detail">
            {/* <div class="about_img-box">
              <img class="about_img about_img_left" src="img/forum.png" alt="" />
            </div> */}
            <div class="card_detail-ox ">
              <div className="card_detail-oxx">
                <h4>Sohbet odaların'a Geç</h4>
                <p>Aklındaki soruları cevapsız bırakma.</p>
                {/* <div>
                  <a href="" class="about_btn">
                    Git
                  </a>
                </div> */}
              </div>
            </div>
          </div>
        </div>
        </Link>
        <div className="border-bottom mt-3"></div>
        <Link to={"/university-guide"}>
        <div class="about_card about_card_right mt-2 ">
          <div class="about-detail">
            <div class="card_detail-ox">
              <div className="card_detail-oxx ">
                <h4>Üniversiteleri Tanı</h4>
                <p>
                  Hedeflediğin üniversiteyle ilgili tüm bilgileri gör,
                  üniversitedeki öğrencilerin görüşlerini incele.
                </p>
                {/* <div>
                  <a href="" class="about_btn">
                    Git
                  </a>
                </div> */}
              </div>
              
            </div>
          </div>
        </div>
        </Link>
      </div>
    </div>
    // <div className="home-page">

    //   <section class="about_section layout_padding">
    //     <div class="container">
    //       <h2>Üniversite Asistanına hoşgeldin.</h2>

    //     </div>

    // <div class="container">
    //   <div class="about_card-container">
    //     <div className="row">
    //       <div className="col-xl-4 col-lg-2 col-md-6">
    //         <div class="about_card">
    //           <div class="about-detail">
    //             <div class="about_img-box">
    //               <img src="img/forum.png" alt="" />
    //             </div>
    //             <div class="card_detail-ox">
    //               <h4>Forum'a Geç</h4>
    //               <p>
    //                 Aklındaki soruları cevapsız bırakma.
    //               </p>
    //               <div>
    //             <a href="" class="about_btn">
    //               Git
    //             </a>
    //           </div>
    //             </div>
    //           </div>

    //         </div>
    //       </div>
    //       <div className="col">
    //         <div class="about_card">
    //           <div class="about-detail">
    //             <div class="about_img-box">
    //               <img src="img/universitypng.png" alt="" />
    //             </div>
    //             <div class="card_detail-ox">
    //               <h4>Üniversiteleri Tanı</h4>
    //               <p>
    //                 Hedeflediğin üniversiteyle ilgili tüm bilgileri gör, üniversitedeki öğrencilerin görüşlerini incele.
    //               </p>
    //               <div>
    //             <a href="" class="about_btn">
    //             Git
    //             </a>
    //           </div>
    //             </div>

    //           </div>

    //         </div>
    //       </div>
    //       <div className="col">
    //         <div class="about_card">
    //           <div class="about-detail">
    //             <div class="about_img-box">
    //               <img src="img/communitypng.png" alt="" />
    //             </div>
    //             <div class="card_detail-ox">
    //               <h4>Sohbet Odaları  </h4>
    //               <p>
    //                Toplulukla tanış, canlı olarak insanlarla sohbet et çalışma arkadaşları edin.
    //               </p>
    //               <div>
    //             <a href="" class="about_btn">
    //             Git
    //             </a>
    //           </div>
    //             </div>
    //           </div>

    //         </div>
    //       </div>

    //     </div>
    //   </div>
    // </div>
    //   </section>
    // </div>
  );
};

export default HomePage;
