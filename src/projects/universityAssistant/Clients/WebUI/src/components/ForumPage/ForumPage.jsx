import React from "react";
import "./ForumPage.css";
import { HiOutlineChatBubbleLeftRight } from "react-icons/hi2";
import { IoChatbubblesSharp } from "react-icons/io5";
import ForumTextModal from "./ForumTextModal";
import { Link, useParams } from "react-router-dom";
import { useState } from "react";
import { useEffect } from "react";
import ChatServices from "../../Services/ChatServices";
const ForumPage = () => {
  const [title, setTitle] = useState("");
  const [selectedValue, setSelectedValue] = useState("");
  const [chatGroup, setChatGroup] = useState([]);
  const [categoriList, setCategoriList] = useState([]);
  let chatServices = new ChatServices();
  let params = useParams()
  useEffect(() => {
    chatServices
      .GetAllChatGroup(params.id)
      .then((res) => setChatGroup(res.data.items))
      .catch((err) => console.log(err));
    chatServices.GetAllCountryCategories().then((res) => {
      console.log(res.data.items);
      setCategoriList(res.data.items);
    });
  }, [chatGroup]);

  console.log(chatGroup);
  return (
    <div className="container">
      <div className="forum-page-main-div">
        <div class="row">
          <div class="col-xxl-2 col-xl-3 col-lg-3 ">
            <div className="forum-tag-button-group">
              <ForumTextModal
                title={title}
                setTitle={setTitle}
                selectedValue={selectedValue}
                setSelectedValue={setSelectedValue}
              />

              <button className="mt-3 mb-3 forum-tag-button">
                <HiOutlineChatBubbleLeftRight /> Tüm tartışmalar
              </button>
              <div className="border-bottom mb-2"></div>
              <div className="text-center">
              {categoriList.map((data) => (
                <Link to={`/chat/${data.id}`}><button className="forum-tag-button " style={{ color: data.colorCode,width:"100%" }}>
                  {data.name}
                </button>
                </Link>
              ))}
              </div>
              {/* 
              <button className="forum-tag-button" style={{ color: "#ff930f" }}>
                YKS Kaynak Tavsiyeleri
              </button>
              <button className="forum-tag-button" style={{ color: "#ff3d3d" }}>Tanışma - Kaynaşma</button>
              <button className="forum-tag-button" style={{ color: "#42047e" }}>
                Üniversite Tercihleri
              </button>
              <button className="forum-tag-button" style={{ color: "#0fbbff" }}>Sayısal</button>
              <button className="forum-tag-button" style={{ color: "#89a7fa" }}>Eşit Ağırlık</button>
              <button className="forum-tag-button"  style={{ color: "#ffc720" }}>Sözel</button>
              <button className="forum-tag-button" style={{ color: "#ee8bdc" }}>Dil</button> */}
            </div>
          </div>
          <div className="col-xxl-10 col-xl-9 col-lg-9">
            <div className="forum-question-component-group">
                {chatGroup.length !=0 ? chatGroup.map((res) => (
              <Link to={`chat-detail/${res.id}`}>

                  <div className="forum-question-component mt-3">
                    <img
                      className="forum-question-component-user-img"
                      src={res.profilePhotoUrl}
                      alt=""
                    />
                    <div className="forum-question-component-text ms-3 mt-1">
                      {res.name}
                    </div>
                    <div
                      className="forum-question-component-tag text-center  "
                      style={{ backgroundColor: res.colorCode }}
                    >
                      {res.chatCategoryName}
                    </div>
                    <div className="forum-question-component-comment-count d-flex">
                      <IoChatbubblesSharp
                        style={{ marginTop: "4px", marginRight: "2px" }}
                      />{" "}
                      102
                    </div>
                  </div>
              </Link>

                ))
                
                :<div style={{marginTop:"80px",fontSize:"35px",textAlign:"center", fontWeight:"bold"}}>Henüz hiç sohbet odası oluşturulmamış.</div>}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ForumPage;
