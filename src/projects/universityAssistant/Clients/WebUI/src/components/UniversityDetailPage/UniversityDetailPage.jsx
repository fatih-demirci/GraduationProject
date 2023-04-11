import React from "react";
import "./UniversityDetailPage.css";
import TextModal from "../common/TextModal/TextModal";
import { Link } from "react-router-dom";
const UniversityDetailPage = () => {
  return (
    <div className="container">
      <div className="university-detail-page-info">
        <div className="university-detail-page-info-img-div">
          <img
            className="university-detail-page-info-img"
            src="/img/firatunilogo.png"
            alt=""
          />
        </div>
        <div className="university-detail-page-info-p-div">
          <div style={{ textAlign: "center", fontWeight: "bold" }}>
            FIRAT ÜNİVERSİTESİ
          </div>

          <p>
            <span>Üniversite Türü</span> : Devlet
          </p>
          <p>
            <span>Şehir</span> : Elazığ
          </p>
          <p>
            <span>Web Sitesi</span>:{" "}
            <a
              href="http://www.antalya.edu.tr/"
              target="_blank"
              style={{ color: "blue" }}
            >
              http://www.antalya.edu.tr/
            </a>
          </p>
          <p>
            <span>Adres</span> : Çıplaklı Mah. Akdeniz Bulvarı No:290/A
            Döşemealtı / ANTALYA
          </p>
        </div>
      </div>
      <div className="shares-modal-button-and-text mt-3">
        <span className="mt-2" style={{ fontWeight: "bold" }}>
          Paylaşımlar
        </span>
        <TextModal />
      </div>
      <hr />

      {/* <div className="university-detail-page-shares">
      <img className="university-detail-page-shares-background" src="/img/firatunilogo.png" alt="" />

        <div className="university-detail-page-shares-text">
          <h6 className="university-detail-page-shares-text-title">Başlık başlık başlık başlık</h6>
        </div>
      </div> */}
      <div className="row ">
        <div className="col-xxl-3 col-xl-3 col-lg-4 col-md-4 col-sm-12 col-xs-12 university-detail-page-shares-card-flex">
          <Link to="sharing/id">
            <div class="university-detail-page-shares-card mt-4 ">
              <img
                class="university-detail-page-shares-card-background"
                src="/img/firatunilogo.png"
                alt="Photo of Cartagena's cathedral at the background and some colonial style houses"
                width="1920"
                height="2193"
              />
              <div class="university-detail-page-shares-card-content | flow">
                <div class="university-detail-page-shares-card-content--container | flow">
                  <div class="university-detail-page-shares-card-content-title">
                    <p>Title titletitle title</p>
                    <p className="university-detail-page-shares-card-content-date">
                      11.03.2023
                    </p>
                  </div>

                  <p class="university-detail-page-shares-card-content-description">
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit.
                    Rerum in labore laudantium deserunt fugiat numquam.
                  </p>
                </div>
                <button class="university-detail-page-shares-card-content-button">
                  Daha fazla
                </button>
              </div>
            </div>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default UniversityDetailPage;
