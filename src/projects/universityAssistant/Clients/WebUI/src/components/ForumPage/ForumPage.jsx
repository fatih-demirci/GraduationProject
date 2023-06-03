import React from "react";
import "./ForumPage.css";
import { HiOutlineChatBubbleLeftRight } from "react-icons/hi2";
import { IoChatbubblesSharp } from "react-icons/io5";
import ForumTextModal from "./ForumTextModal";
import { Link } from "react-router-dom";
import { useState } from "react";
const ForumPage = () => {
  const [title, setTitle] = useState("")
  const [selectedValue, setSelectedValue] = useState("")
  console.log(selectedValue);
  console.log(title);
  return (
    <div className="container">
      <div className="forum-page-main-div">
        <div class="row">
          <div class="col-xxl-2 col-xl-3 col-lg-3 ">
            <div className="forum-tag-button-group">
              <ForumTextModal title={title} setTitle={setTitle} selectedValue={selectedValue} setSelectedValue={setSelectedValue}/>

              <button className="mt-3 mb-3 forum-tag-button">
                <HiOutlineChatBubbleLeftRight /> Tüm tartışmalar
              </button>
              <div className="border-bottom mb-2"></div>
              <button className="forum-tag-button" style={{ color: "black" }}>Genel</button>

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
              <button className="forum-tag-button" style={{ color: "#ee8bdc" }}>Dil</button>
            </div>
          </div>
          <div className="col-xxl-10 col-xl-9 col-lg-9">
            <div className="forum-question-component-group">
              <Link to="chat-detail/id">
                <div className="forum-question-component">
                  <img
                    className="forum-question-component-user-img"
                    src="img/userface.jpg"
                    alt=""
                  />
                  <div className="forum-question-component-text ms-3 mt-1">
                    Tyt matematikte süre sıkıntısı ve kaynak önerisi
                  </div>
                  <div
                    className="forum-question-component-tag text-center  "
                    style={{ backgroundColor: "black" }}
                  >
                    Genel
                  </div>
                  <div className="forum-question-component-comment-count d-flex">
                    <IoChatbubblesSharp
                      style={{ marginTop: "4px", marginRight: "2px" }}
                    />{" "}
                    102
                  </div>
                </div>
              </Link>
              <div className="forum-question-component">
                <img
                  className="forum-question-component-user-img"
                  src="img/userface.jpg"
                  alt=""
                />
                <div className="forum-question-component-text ms-3 mt-1">
                  Tyt matematikte süre sıkıntısı ve kaynak önerisi
                </div>
                <div
                  className="forum-question-component-tag "
                  style={{ backgroundColor: "#ff930f" }}
                >
                  YKS Kaynak Tavsiyeleri
                </div>
                <div className="forum-question-component-comment-count d-flex">
                  <IoChatbubblesSharp
                    style={{ marginTop: "4px", marginRight: "2px" }}
                  />{" "}
                  102
                </div>
              </div>
              <div className="forum-question-component">
                <img
                  className="forum-question-component-user-img"
                  src="img/userface.jpg"
                  alt=""
                />
                <div className="forum-question-component-text ms-3 mt-1">
                  Tyt matematikte süre sıkıntısı ve kaynak önerisi
                </div>
                <div
                  className="forum-question-component-tag "
                  style={{ backgroundColor: "#f84b3f" }}
                >
                  Tanışma Kaynaşma
                </div>
                <div className="forum-question-component-comment-count d-flex">
                  <IoChatbubblesSharp
                    style={{ marginTop: "4px", marginRight: "2px" }}
                  />{" "}
                  102
                </div>
              </div>
              <div className="forum-question-component">
                <img
                  className="forum-question-component-user-img"
                  src="img/userface.jpg"
                  alt=""
                />
                <div className="forum-question-component-text ms-3 mt-1">
                  Tyt matematikte süre sıkıntısı ve kaynak önerisi
                </div>
                <div
                  className="forum-question-component-tag "
                  style={{ backgroundColor: "#42047e" }}
                >
                  Üniversite Tercihleri
                </div>
                <div className="forum-question-component-comment-count d-flex">
                  <IoChatbubblesSharp
                    style={{ marginTop: "4px", marginRight: "2px" }}
                  />{" "}
                  102
                </div>
              </div>
              <div className="forum-question-component">
                <img
                  className="forum-question-component-user-img"
                  src="img/userface.jpg"
                  alt=""
                />
                <div className="forum-question-component-text ms-3 mt-1">
                  Tyt matematikte süre sıkıntısı ve kaynak önerisi
                </div>
                <div
                  className="forum-question-component-tag "
                  style={{ backgroundColor: "#0fbbff" }}
                >
                  Sayısal
                </div>
                <div className="forum-question-component-comment-count d-flex">
                  <IoChatbubblesSharp
                    style={{ marginTop: "4px", marginRight: "2px" }}
                  />{" "}
                  102
                </div>
              </div>
              <div className="forum-question-component">
                <img
                  className="forum-question-component-user-img"
                  src="img/userface.jpg"
                  alt=""
                />
                <div className="forum-question-component-text ms-3 mt-1">
                  Tyt matematikte süre sıkıntısı ve kaynak önerisi
                </div>
                <div
                  className="forum-question-component-tag "
                  style={{ backgroundColor: "#89a7fa" }}
                >
                  Eşit Ağırlık
                </div>
                <div className="forum-question-component-comment-count d-flex">
                  <IoChatbubblesSharp
                    style={{ marginTop: "4px", marginRight: "2px" }}
                  />{" "}
                  102
                </div>
              </div>
              <div className="forum-question-component">
                <img
                  className="forum-question-component-user-img"
                  src="img/userface.jpg"
                  alt=""
                />
                <div className="forum-question-component-text ms-3 mt-1">
                  Tyt matematikte süre sıkıntısı ve kaynak önerisi
                </div>
                <div
                  className="forum-question-component-tag "
                  style={{ backgroundColor: "#ffc720" }}
                >
                  Sözel
                </div>
                <div className="forum-question-component-comment-count d-flex">
                  <IoChatbubblesSharp
                    style={{ marginTop: "4px", marginRight: "2px" }}
                  />{" "}
                  102
                </div>
              </div>
              {/* <div className="forum-question-component">
              asdasda
              </div>
              <div className="forum-question-component">
              asdasda
              </div>
              <div className="forum-question-component">
              asdasda
              </div> */}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ForumPage;
