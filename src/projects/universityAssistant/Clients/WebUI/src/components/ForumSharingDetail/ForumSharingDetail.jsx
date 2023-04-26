import React from "react";
import "./ForumSharingDetail.css";
import InputField from "../common/InputField/InputField";
import TextArea from "../common/InputField/TextArea";
import { FaComments } from "react-icons/fa";
import {AiFillLike} from "react-icons/ai"
const ForumSharingDetail = () => {
  return (
    <div className="container forum-sharing-detail-container">
      <div className="fsdc-creative-info d-flex">
        <div className="fsdc-img-div">
          <img className="fsdc-img" src="/img/userface.jpg" alt="" />
        </div>
        <div className="fsdc-username-date-div d-flex ms-3">
          <div className="fsdc-username-div">
            <p className="fsdc-username">usernameusername</p>{" "}
          </div>
          <div className="fsdc-date-div ms-3">
            <p className="fsdc-date">11.03.2023</p>
          </div>
        </div>
        <div>
          <AiFillLike/>
        </div>
      </div>
      <div className="fsdc-text mt-3">
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Cumque
        exercitationem aliquid deleniti alias doloribus hic odit maiores
        doloremque labore officia, enim temporibus provident sunt illo!
        Quibusdam accusamus quod debitis ipsum expedita assumenda explicabo
        minus, in ab, beatae voluptates id sed nemo dicta officiis corporis
        porro saepe fuga voluptate obcaecati quidem? Aut cumque quaerat totam
        voluptate porro id aperiam esse aspernatur ipsum? Similique neque optio
        quam dolores dolor eaque modi tempora aliquam quas necessitatibus quos,
        doloremque autem cupiditate dolorem, labore exercitationem totam illo
        commodi. Cum natus recusandae repudiandae, aut, est exercitationem minus
        consectetur animi eaque, alias quo eveniet porro laborum autem.
      </div>
      <div className="fsdc-comments-icon-div mt-3 ">
        <FaComments className="fsdc-comments-icon" />
        <h3 className="fsdc-comments-h3 ms-3">Yorumlar</h3>
      </div>
      <div className="border-bottom"></div>
      <div className="fsdc-input-field mt-4">
        <TextArea type={"text"} placeholder={"Bir yanıt yaz..."} />
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
            <div className="fsdc-date-div ms-3">
              <p className="fsdc-date">11.03.2023</p>
            </div>
          </div>
        </div>
        <div className="fsdc-comments-text mt-3">
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Consequuntur
          omnis sequi maiores corporis similique placeat soluta saepe quo nemo
          voluptatibus explicabo, illum sed ab minus tempore delectus
          accusantium exercitationem possimus facilis voluptate incidunt,
          numquam dolor dignissimos assumenda? Earum mollitia et quae libero
          ipsum cum, labore dolor aliquam! Nulla, accusamus sit!
        </div>
        <div className="border-bottom mt-4"></div>
      </div>
      
    </div>
  );
};

export default ForumSharingDetail;
