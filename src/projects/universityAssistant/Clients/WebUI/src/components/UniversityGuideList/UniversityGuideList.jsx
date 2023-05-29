import React, { useState } from "react";
import "./UniversityGuideList.css";
import { Link, useParams } from "react-router-dom";
import UniversityServices from "../../Services/UniversityServices";
import { useEffect } from "react";

const UniversityGuideList = () => {
  const [universityList, setUniversityList] = useState([])
  let universityServices = new UniversityServices()
  let params = useParams()
  console.log(params);
  useEffect(() => {
    universityServices.UniversityListFilterProvienceId(params.id).then(res => setUniversityList(res.data.value)).catch(err => console.log(err))
    
  }, [])
  console.log(universityList);
  
  return (
    <div className="university-guide-list-main container">
      <div className="row university-guide-info-div">
      {universityList.map(data => (


        <div className="col-xxl-6 col-md-6 ">

          <Link to={`${(data.Name).toLowerCase().replace(" ","-")}/${data.Id}`}>
          <div className="university-guide-info">
            <div className="university-guide-logo-div">
              <img
                className="university-guide-logo"
                src={data.LogoUrl}
                alt=""
              />
            </div>
            <div className="university-guide-text-div">
              <div className="university-guide-text ms-2 ">
                {data.Name}
                
              </div>
            </div>
          </div>
          </Link>

        </div>

        ))}

        
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
