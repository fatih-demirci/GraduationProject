import React from "react";
import "./UniversityGuideList.css";
import { Link } from "react-router-dom";

const UniversityGuideList = () => {
  return (
    <div className="university-guide-list-main container">
      <div className="row">
        <div className="flex">
        <div className="col-xxl-6">
          <Link to={"adana-alparslan-turkes-uni"}>
          <div className="university-guide-info">
            <div className="university-guide-logo-div">
              <img
                className="university-guide-logo"
                src="/img/firatunilogo.png"
                alt=""
              />
            </div>
            <div className="university-guide-text-div">
              <div className="university-guide-text ms-2 ">
                Fırat Üniversitesi
                
              </div>
            </div>
          </div>
          </Link>
        </div>
        
        
        
        </div>
        
        
        {/* <div className="col-xxl-6">
          <div className="university-guide-info">
            <div className="university-guide-logo-div">
              <img
                className="university-guide-logo"
                src="/img/firatunilogo.png"
                alt=""
              />
            </div>
            <div className="university-guide-text-div">
              <div className="university-guide-text ms-2 ">
                Adana Alparslan Türkeş Bilim ve Teknoloji Üniversitesi
              </div>
            </div>
          </div>
        </div> */}
        {/* <div className="col-xxl-6">
          <div className="university-guide-info">
            <div className="university-guide-logo-div">
              <img
                className="university-guide-logo"
                src="/img/firatunilogo.png"
                alt=""
              />
            </div>
            <div className="university-guide-text-div">
              <div className="university-guide-text ms-2 ">
                Adana Alparslan Türkeş Bilim ve Teknoloji Üniversitesi
              </div>
            </div>
          </div>
        </div> */}
      </div>
    </div>
  );
};

export default UniversityGuideList;
