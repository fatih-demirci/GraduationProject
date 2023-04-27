import React, { useState } from "react";
import "./ForumSharingDetail.css";
import InputField from "../common/InputField/InputField";
import TextArea from "../common/InputField/TextArea";
import { FaComments } from "react-icons/fa";
import { AiFillLike } from "react-icons/ai";
import UserServices from "../../Services/UserServices";
const ForumSharingDetail = () => {
  const [file, setFile] = useState();
  const [text, setText] = useState("");
  let userServices = new UserServices();

  const onFileDrop = (e) => {
    setFile(e.target.files[0]);
  };
  console.log(file);

  function submit(e) {
    e.preventDefault();
    userServices.UpdateProfilePhoto(file);
    userServices.UpdateUserName(text);
  }
  return (
    <div className=" forum-sharing-detail-container">
      <div className="container">
        <div className="fsdc-title">
          {" "}
          <h3>
          Tyt matematikte süre sıkıntısı ve kaynak önerisi

          </h3>
        </div>
        <div className="fsdc-creative-info d-flex mt-4">
          <div className="fsdc-img-div">
            <img className="fsdc-img" src="/img/userface.jpg" alt="" />
          </div>
          <div className="fsdc-username-date-div d-flex ms-3">
            <div className="fsdc-username-div">
              <p className="fsdc-username">usernameusername</p>{" "}
            </div>
            <div className="fsdc-date-div ">
              <p className="fsdc-date">11.03.2023</p>
            </div>
          </div>
          <div className="like-icon-png-div">
            {/* <AiFillLike/> */}
            <img className="like-icon-png" src="/img/likebutton.png" alt="" />
            <span className="like-icon-span">99</span>
          </div>
        </div>
        <div className="fsdc-text mt-3">
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Cumque
          exercitationem aliquid deleniti alias doloribus hic odit maiores
          doloremque labore officia, enim temporibus provident sunt illo!
          Quibusdam accusamus quod debitis ipsum expedita assumenda explicabo
          minus, in ab, beatae voluptates id sed nemo dicta officiis corporis
          porro saepe fuga voluptate obcaecati quidem? Aut cumque quaerat totam
          voluptate porro id aperiam esse aspernatur ipsum? Similique neque
          optio quam dolores dolor eaque modi tempora aliquam quas
          necessitatibus quos, doloremque autem cupiditate dolorem, labore
          exercitationem totam illo commodi. Cum natus recusandae repudiandae,
          aut, est exercitationem minus consectetur animi eaque, alias quo
          eveniet porro laborum autem.
        </div>
        <div className="fsdc-comments-icon-input-field-div mt-3">
          <div className="fsdc-comments-icon-div ">
            <FaComments className="fsdc-comments-icon" />
            <h4 className="fsdc-comments-h4 ms-3">Yorumlar</h4>
          </div>
          <div className="border-bottom"></div>
          <div className="fsdc-input-field-div">
            <div className="fsdc-input-field mt-4">
              <div>
                <img
                  className="fsdc-input-field-img"
                  src="/img/userface2.jpg"
                  alt=""
                />
              </div>
              <TextArea
                className="fsdc-input-field-textarea"
                type={"text"}
                placeholder={"Bir yanıt yaz..."}
              />
            </div>
            <div className="fsdc-input-field-send-icon-div">
              <button className="fsdc-input-field-send-button">
                <img
                  className="fsdc-input-field-send-icon"
                  src="/img/sendicon.png"
                  alt=""
                />
              </button>
              {/* <button className="fsdc-input-field-send-button btn btn-outline-info">
             Gönder
            </button> */}
            </div>
          </div>
        </div>
        <div className="fsdc-comments mt-5">
          <div className="fsdc-creative-info d-flex">
            <div className="fsdc-img-div">
              <img className="fsdc-img" src="/img/userface2.jpg" alt="" />
            </div>
            <div className="fsdc-username-date-div d-flex ms-3">
              <div className="fsdc-username-div">
                <p className="fsdc-username">usernameusername</p>{" "}
              </div>
              <div className="fsdc-date-div  ">
                <p className="fsdc-date">11.03.2023</p>
              </div>
              <div className="like-icon-png-div">
                {/* <AiFillLike/> */}
                <img
                  className="like-icon-png"
                  src="/img/likebutton.png"
                  alt=""
                />
                <span className="like-icon-span">99</span>
                <p></p>
              </div>
            </div>
          </div>
          <div className="fsdc-comments-text mt-3">
            Lorem ipsum dolor sit amet consectetur adipisicing elit.
            Consequuntur omnis sequi maiores corporis similique placeat soluta
            saepe quo nemo voluptatibus explicabo, illum sed ab minus tempore
            delectus accusantium exercitationem possimus facilis voluptate
            incidunt, numquam dolor dignissimos assumenda? Earum mollitia et
            quae libero ipsum cum, labore dolor aliquam! Nulla, accusamus sit!
          </div>
          <div className="border-bottom mt-4"></div>
        </div>
      </div>
      <form onSubmit={submit}>
        <input type="text" onChange={(e) => setText(e.target.value)} />
        <input type="file" onChange={onFileDrop}></input>
        <button type="submit">YOLLA</button>
      </form>
    </div>
  );
};

export default ForumSharingDetail;
