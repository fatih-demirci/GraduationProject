import React from "react";
import "./ForumPage.css";
import { HiOutlineChatBubbleLeftRight } from "react-icons/hi2";
import { IoChatbubblesSharp } from "react-icons/io5";
import ForumTextModal from "./ForumTextModal";
const ForumPage = () => {
  return (
    <div className="container">
      <div className="forum-page-main-div">
        <div class="row">
          <div class="col-xxl-2 col-xl-3 col-lg-3 ">
              <div className="forum-tag-button-group">
              <ForumTextModal/>

                <button className="mt-3 mb-3">
                  <HiOutlineChatBubbleLeftRight /> Tüm tartışmalar
                </button>
                <button className="forum-tag-button">Genel</button>

                <button className="forum-tag-button">
                  YKS Kaynak Tavsiyeleri
                </button>
                <button className="forum-tag-button">Tanışma - Kaynaşma</button>
                <button className="forum-tag-button">
                  Üniversite Tercihleri
                </button>
                <button className="forum-tag-button">Sayısal</button>
                <button className="forum-tag-button">Eşit Ağırlık</button>
                <button className="forum-tag-button">Sözel</button>
                <button className="forum-tag-button">Dil</button>
              </div>
            </div>
            <div className="col-xxl-10 col-xl-9 col-lg-9">
            <div className="forum-question-component-group">
              <div className="forum-question-component">
                <img className="forum-question-component-user-img" src="img/userface.jpg" alt="" />
                <div className="forum-question-component-text ms-3 mt-1">
                Tyt matematikte süre sıkıntısı ve kaynak önerisiasd
              </div>
              <div className="forum-question-component-tag text-center  ">Genel</div>
              <div className="forum-question-component-comment-count d-flex">
                <IoChatbubblesSharp style={{marginTop:"4px",marginRight:"2px"}}/> 102
              </div>
              </div>
              <div className="forum-question-component">
                <img className="forum-question-component-user-img" src="img/userface.jpg" alt="" />
                <div className="forum-question-component-text ms-3 mt-1">
                Tyt matematikte süre sıkıntısı ve kaynak önerisiasd
              </div>
              <div className="forum-question-component-tag ">YKS Kaynak Tavsiyeleri</div>
              <div className="forum-question-component-comment-count d-flex">
                <IoChatbubblesSharp style={{marginTop:"4px",marginRight:"2px"}}/> 102
              </div>
              </div>
              <div className="forum-question-component">
                <img className="forum-question-component-user-img" src="img/userface.jpg" alt="" />
                <div className="forum-question-component-text ms-3 mt-1">
                Tyt matematikte süre sıkıntısı ve kaynak önerisiasd
              </div>
              <div className="forum-question-component-tag ">YKS Kaynak Önerileri</div>
              <div className="forum-question-component-comment-count d-flex">
                <IoChatbubblesSharp style={{marginTop:"4px",marginRight:"2px"}}/> 102
              </div>
              </div>
              <div className="forum-question-component">
                <img className="forum-question-component-user-img" src="img/userface.jpg" alt="" />
                <div className="forum-question-component-text ms-3 mt-1">
                Tyt matematikte süre sıkıntısı ve kaynak önerisiasd
              </div>
              <div className="forum-question-component-tag ">YKS Kaynak Önerileri</div>
              <div className="forum-question-component-comment-count d-flex">
                <IoChatbubblesSharp style={{marginTop:"4px",marginRight:"2px"}}/> 102
              </div>
              </div>
              <div className="forum-question-component">
                <img className="forum-question-component-user-img" src="img/userface.jpg" alt="" />
                <div className="forum-question-component-text ms-3 mt-1">
                Tyt matematikte süre sıkıntısı ve kaynak önerisiasd
              </div>
              <div className="forum-question-component-tag ">YKS Kaynak Önerileri</div>
              <div className="forum-question-component-comment-count d-flex">
                <IoChatbubblesSharp style={{marginTop:"4px",marginRight:"2px"}}/> 102
              </div>
              </div>
              <div className="forum-question-component">
                <img className="forum-question-component-user-img" src="img/userface.jpg" alt="" />
                <div className="forum-question-component-text ms-3 mt-1">
                Tyt matematikte süre sıkıntısı ve kaynak önerisiasd
              </div>
              <div className="forum-question-component-tag ">YKS Kaynak Önerileri</div>
              <div className="forum-question-component-comment-count d-flex">
                <IoChatbubblesSharp style={{marginTop:"4px",marginRight:"2px"}}/> 102
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
