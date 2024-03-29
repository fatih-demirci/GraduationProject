import React from "react";

import "./Profile.css";
import Carousel from "../common/Carousel/Carousel";
import { useEffect } from "react";
import UserServices from "../../Services/UserServices";
import { useState } from "react";
import { toast } from "react-toastify";
import AuthServices from "../../Services/AuthServices";
const Profile = () => {
  let userServices = new UserServices();
  let authServices = new AuthServices()

  const [file, setFile] = useState(null);
  const [userInfo, setUserInfo] = useState({
    userName: "",
    email: "",
    profilePhotoUrl: "",
  });

  const onFileDrop = (e) => {
    setFile(e.target.files[0]);
  };
  console.log(file);

  const handleFileUpload = (event) => {
    event.preventDefault();
    const formData = new FormData();
    formData.append("file", file);
    console.log(formData);
    userServices
      .UpdateProfilePhoto(formData)
      .then((res) => {
        console.log(res);
        toast.success("Başarıyla değiştirildi.", {
          autoClose: 1500,
        });
        setTimeout(() => {
          
        window.location.reload()
        }, 1500);
      })
      .catch((err) => {
        console.log(err);
        toast.err("Değiştirilemedi.");
      });
  };

  console.log(userInfo);
  console.log(localStorage.getItem("refreshToken"));

  useEffect(() => {
    userServices
      .GetUser()
      .then((res) => setUserInfo(res.data))
      .catch((err) => console.log(err));
    authServices.LoginRefreshToken(localStorage.getItem("refreshToken")).then(res => console.log(res)).catch(err => console.log(err))
    }, []);
// console.log(userInfo.profilePhotoUrl.length);
  return (
    <div className="">
      <div className="profile-user-info d-flex background-gray">
        <div>
          <img
            src={
              userInfo.profilePhotoUrl == null
                ? `/img/userpng.png`
                : userInfo.profilePhotoUrl
            }
            alt=""
            className="profile-user-info-img "
          />
        </div>

        <div className="profile-username-div ms-2">
          <div className="profile-username">{userInfo.userName}</div>
        </div>
        <form onSubmit={handleFileUpload}>
          {/* <input type="text" onChange={(e) => setText(e.target.value)} /> */}
          {/* <input className="custom-file-input" type="file" ></input> */}
          <div>
            {/* <input
              class="profile-photo-change-icon"
              type="file"
              onChange={onFileDrop}
            /> */}
            <label for="file-upload" class="custom-file-upload">
              <img
                className="profile-photo-change-icon"
                src={!file && `img/cameraicon.png`}
                alt=""
              />
            </label>
            <input
              id="file-upload"
              className="file-upload-input-button"
              type="file"
              onChange={onFileDrop}
            />
          </div>
          {file && (
            <div>
              <button
                class="btn btn-outline-success"
                type="submit"
                style={{ marginTop: "-6px", marginLeft: "15px" }}
              >
                Değiştir
              </button>
            </div>
          )}
        </form>
      </div>
      <div className="profile-photo-change"></div>
      <div className="profile-user-forum-shares background-gray">
        <h6 className="profile-user-forum-shares-text text-center">
          Forumda paylaştıklarım.
        </h6>
        <Carousel />
      </div>
    </div>
  );
};

export default Profile;
