import React from "react";
import "./UniversityDetailPage.css";
import TextModal from "../common/TextModal/TextModal";
import { Link, useParams } from "react-router-dom";
import axios from "axios";
import { useEffect } from "react";
import { useState } from "react";
import UniversityServices from "../../Services/UniversityServices";
import FileUploadComponent from "../common/FileUploadComponent/FileUploadComponent";
import { useRef } from "react";
import InputField from "../common/InputField/InputField";
import { toast } from "react-toastify";
import parse from 'html-react-parser';
const UniversityDetailPage = () => {
  const [universityDetail, setUniversityDetail] = useState([]);
  let universityServices = new UniversityServices();
  let params = useParams();
  console.log(params.id);
  const [file, setFile] = useState([]);
  const [fileUpload, setFileUplaod] = useState([]);
  const [uploadFile, setUploadFile] = useState([]);
  const [uploaded, setUploaded] = useState("");
  const [message, setMessage] = useState("")
  const [stateTitle, setStateTitle] = useState("")
  const [universityComments, setUniversityComments] = useState([])
console.log(file);
  useEffect(() => {
    universityServices
      .UniversityInfoDetail(params.id)
      .then((res) => res.data.value.map((res) => setUniversityDetail(res)))
      .catch((err) => console.log(err));

      universityServices.GetUniversityComment(params.id).then(res => {setUniversityComments(res.data.value)
      console.log(res.data.value);
      }).catch(err => console.log(err))
  }, []);
  console.log(universityDetail.type);
  function submit(e) {
    e.preventDefault()
    console.log("qweqwe");
    universityServices.AddUniversityComment(params.id,stateTitle,message,file).then((res) => {
      console.log(res);
      toast.success("Gönderi paylaşıldı.")
    })
    .catch((err) => {console.log(err)
    toast.error("Gönderi paylaşılamadı.")
    });
    
  }
  return (
    <div className="container">
      <div className="university-detail-page-info">
        <div className="university-detail-page-info-img-div">
          <img
            className="university-detail-page-info-img"
            src={universityDetail.LogoUrl}
            alt=""
          />
        </div>
        <div className="university-detail-page-info-p-div">
          <div style={{ textAlign: "center", fontWeight: "bold" }}>
            {universityDetail.Name}
          </div>

          <p>
            <span>Üniversite Türü</span> :{" "}
            {universityDetail.Type == 0 ? <>Devlet</> : <>Özel</>}
          </p>
          <p>
            <span>Şehir</span> : {universityDetail.ProvienceName}
          </p>
          <p>
            <span>Web Sitesi</span>:{" "}
            <a
              href={universityDetail.Website}
              target="_blank"
              style={{ color: "blue" }}
            >
              {universityDetail.Website}{" "}
            </a>
          </p>
          <p>
            <span>Adres</span> : {universityDetail.Address}
          </p>
        </div>
      </div>
      <div className="shares-modal-button-and-text mt-3">
        <span className="mt-2" style={{ fontWeight: "bold" }}>
          Paylaşımlar
        </span>
        <TextModal stateTitle={stateTitle} setStateTitle={setStateTitle} initialValue={message} getValue={setMessage}  file={file} setFile={setFile} uploaded={uploaded} submit={submit}/>
      </div>
      <div className="col-md-auto">
          {uploadFile.map((data) => (
            <>
              {data.urlCategoryId === 1 && (
                <div
                  id={data.id}
                  style={{ display: "inline-block" }}
                  className="mt-4 mb-3 "
                >
                  <div className="">
                    <img
                      style={{ maxWidth: "90%", height: "250px" }}
                      src={data.url}
                      alt="img"
                    ></img>
                  </div>
                  {data.url}

                  <div className="">
                    <label>
                      <button
                        type="button"
                        className="update-delete-btn btn btn-danger mt-2"
                        onClick={() => {
                          // deleteAnnouncements(data.id, data.fileNameForStorage);
                          document.getElementById(data.id).style.display =
                            "none";
                        }}
                      >
                        SİL
                      </button>
                    </label>
                  </div>
                </div>
              )}
              {data.urlCategoryId === 2 && (
                <div
                  id={data.id}
                  style={{ display: "inline-block" }}
                  className="mt-4 mb-3 "
                >
                  <div className="">
                    <video width="360" height="320" controls="controls">
                      <source src={data.url} type="video/mp4" />
                      <source src={data.url} type="video/ogg" />
                      Tarayıcınız video etiketini desteklemiyor.
                    </video>
                  </div>
                  {data.url}

                  <div className="">
                    <label>
                      <button
                        type="button"
                        className="btn btn-danger"
                        onClick={() => {
                          // deleteAnnouncements(data.id, data.fileNameForStorage);
                          document.getElementById(data.id).style.display =
                            "none";
                        }}
                      >
                        SİL
                      </button>
                    </label>
                  </div>
                </div>
              )}
              {data.urlCategoryId === 3 && (
                <div
                  id={data.id}
                  style={{ display: "inline-block" }}
                  className="ms-4 mt-4 mb-3 "
                >
                  <div className="">
                    <a style={{ fontSize: "20px" }} href={data.url}>
                      PDF GÖRÜNTÜLE
                    </a>
                  </div>
                  {data.url}
                  <div className="">
                    <label>
                      <button
                        type="button"
                        className="btn btn-danger mt-2"
                        onClick={() => {
                          // deleteAnnouncements(data.id, data.fileNameForStorage);
                          document.getElementById(data.id).style.display =
                            "none";
                        }}
                      >
                        SİL
                      </button>
                    </label>
                  </div>
                </div>
              )}
            </>
          ))}
        </div>
      <hr />

      {/* <div className="university-detail-page-shares">
      <img className="university-detail-page-shares-background" src="/img/firatunilogo.png" alt="" />

        <div className="university-detail-page-shares-text">
          <h6 className="university-detail-page-shares-text-title">Başlık başlık başlık başlık</h6>
        </div>
      </div> */}
      <div className="row ">
        {universityComments.map(res => (<div className="col-xxl-3 col-xl-3 col-lg-4 col-md-4 col-sm-12 col-xs-12 mt-2 university-detail-page-shares-card-flex">
          <Link to={`sharing/${res.Id}`}>
            <div class="university-detail-page-shares-card mt-4 ">
              <img
                class="university-detail-page-shares-card-background"
                src={universityDetail.LogoUrl}
                alt="Photo of Cartagena's cathedral at the background and some colonial style houses"
                width="1920"
                height="2193"
              />
              <div class="university-detail-page-shares-card-content | flow">
                <div class="university-detail-page-shares-card-content--container | flow">
                  <div class="university-detail-page-shares-card-content-title">
                    <p>{res.Title.length < 12
                      ? res.Title
                      : res.Title.slice(0, 12) + "..."}</p>
                    <p className="university-detail-page-shares-card-content-date">
                    {new Date(res.CreatedDate).toLocaleDateString(
                    "tr-TR",
                    {
                      year: "numeric",
                      month: "long",
                      day: "numeric",
                      weekday: "long",
                    }
                  )}
                    </p>
                  </div>

                  <p class="university-detail-page-shares-card-content-description">
                  {res.Message.length < 60
                      ? parse(res.Message)
                      : parse(res.Message.slice(0, 80) + "...")}
                  </p>
                </div>
                <button class="university-detail-page-shares-card-content-button">
                  Daha fazla
                </button>
              </div>
            </div>
          </Link>
        </div>)) }
      </div>
    </div>
  );
};

export default UniversityDetailPage;
