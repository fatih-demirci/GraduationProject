import React from "react";

import "./Profile.css";
import Carousel from "../common/Carousel/Carousel";
const Profile = () => {
 
  return (
    <div className="">
        <div className="profile-user-info d-flex background-gray">
          <div>
            <img
              src="img/userpng.png"
              alt=""
              className="profile-user-info-img"
            />
          </div>
          <div className="profile-username-div ms-2">
            <div className="profile-username">username123</div>
          </div>
        </div>
        <div className="profile-user-forum-shares background-gray">
          <h6 className="profile-user-forum-shares-text text-center">Forumda paylaştıklarım.</h6>
         <Carousel/>
          </div>
    </div>
  );
};

export default Profile;
