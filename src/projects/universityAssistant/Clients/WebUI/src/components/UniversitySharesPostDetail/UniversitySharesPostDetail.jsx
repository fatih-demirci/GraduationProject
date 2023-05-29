import React from "react";
import "./UniversitySharesPostDetail.css";
import CarouselBootstrap from "../common/CarouselBootstrap/CarouselBootstrap";
import { FcCalendar } from "react-icons/fc";
import { useEffect } from "react";
import UniversityServices from "../../Services/UniversityServices";
import { useParams } from "react-router-dom";
import { useState } from "react";
import parse from 'html-react-parser';
const UniversitySharesPostDetail = () => {
  const [commentDetail, setCommentDetail] = useState("")
  const [commentDetailUserInfo, setCommentDetailUserInfo] = useState("")
  const [commentDetailFiles, setCommentDetailFiles] = useState([])
  let params= useParams()
  let universityServices = new UniversityServices()
  console.log(params.id);
  useEffect(() => {
   universityServices.GetUniversityCommentDetail(params.id).then(res => {setCommentDetail(res.data.value[0])
    setCommentDetailUserInfo(res.data.value[0].User)
    setCommentDetailFiles(res.data.value[0].UniversityCommentFiles);
    
  }).catch(err => console.log(err))
  }, [])
  console.log(commentDetailFiles.map(res => console.log(res.FileType)));
  console.log(commentDetail);
  console.log(commentDetailUserInfo);
  return (
    <div className="container university-shares-post-detail-container">
     <CarouselBootstrap commentDetailFiles={commentDetailFiles} />
      <div className="university-shares-post-detail mt-3">
        <div className="uspd-author">
          <div className="uspd-author-info">
            <img className="uspd-author-img" src={commentDetailUserInfo.ProfilePhotoUrl === null ? "/img/userpng.png" : commentDetailUserInfo.ProfilePhotoUrl} alt="" />
            <div className="uspd-author-name">
              <p className="uspd-author-name-p">{commentDetailUserInfo.UserName}</p>{" "}
            </div>
          </div>
          <div className="uspd-author-date">
            <span className="uspd-author-date-calendar-icon">
              <FcCalendar style={{ marginBottom: "4px", marginRight: "7px" }} />
            </span>
            <p className="uspd-author-date-p">{new Date(commentDetail.CreatedDate).toLocaleDateString(
                    "tr-TR",
                    {
                      year: "numeric",
                      month: "long",
                      day: "numeric",
                      weekday: "long",
                    }
                  )}</p>{" "}
          </div>
        </div>
        <div className="uspd-title-text mt-3">
          <h3 className="uspd-title">
            {commentDetail.Title}
          </h3>
          <div className="uspd-text mt-3">
          {parse(`${commentDetail.Message}`)}
          </div>
          <div style={{}}>
                          {commentDetailFiles.map((res)=> res.FileType === "Document" && (
                           <>
                            <div className="" style={{ marginTop: "20px",textAlign:"center" }}>
                              <a style={{ fontSize: "20px",color:"blue" }} href={res.Url} target="_blank">
                                PDF Görüntüle
                              </a>
                            </div>
                            </>
                          ))}
                        </div>
        </div>
      </div>
    </div>
  );
};

export default UniversitySharesPostDetail;
