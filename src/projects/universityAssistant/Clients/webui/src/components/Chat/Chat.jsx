import React from "react";
import "./Chat.css";
import { FcCalendar } from "react-icons/fc";
import ChatServices from "../../Services/ChatServices";
import { useState } from "react";
import { useParams } from "react-router-dom";
import { useEffect } from "react";
import AuthServices from "../../Services/AuthServices";
import jwt_decode from "jwt-decode";
import {AiFillFileAdd} from "react-icons/ai"
const Chat = () => {
  let chatServices = new ChatServices();
  let authServices = new AuthServices();
  const [message, setMessage] = useState("");
  const [messageList, setMessageList] = useState([]);
  const [chatDetail, setChatDetail] = useState("");
  const [file, setFile] = useState([]);
  let params = useParams();

  let jwtDecode = jwt_decode(localStorage.getItem("token"));
  const userId =
    jwtDecode[
      "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
    ];
  console.log(userId);
  console.log(params);
  // console.log(params);
  useEffect(() => {
    chatServices
      .GetAllChatGroupMessage(params.id)
      .then((res) => {
        console.log(res.data.items);
        setMessageList(res.data.items);
      })
      .catch((err) => console.log(err));

    chatServices
      .GetByIdChatGroup(params.id)
      .then((res) => {
        console.log(res.data);
        setChatDetail(res.data);
      })
      .catch((err) => console.log(err));
  }, []);

  function send() {
    chatServices
      .AddChatGroupMessage(params.id, message, file)
      .then((res) => {
        console.log(res);
      })
      .catch((err) => console.log(err));
  }
  const onFileDrop = (e) => {
   setFile(e.target.files[0]);
    
  };
  console.log(file);
  return (
    <div className="container" style={{ marginTop: "80px" }}>
      <div className="chat-info">
        <div className="chat-info-title">{chatDetail.name}</div>
        <div
          className="chat-info-tag"
          style={{ backgroundColor: `${chatDetail.colorCode}` }}
        >
          {chatDetail.chatCategoryName}
        </div>
      </div>
      <div class="chat-container  ">
        <div class="chat-messages">
          {messageList.length == 0 ? (
            <div style={{ textAlign: "center", fontWeight: "bold" }}>
              Henüz kimse mesaj yazmadı.
            </div>
          ) : (
            messageList.map((res) => (
              <div
                class={`message ${res.userId == userId ? "sent" : "received"}`}
              >
                <img class="avatar" src={res.profilePhotoUrl} />
                {console.log(res.chatGroupMessageUrls[0])}
                <div class="message-content-received">
                  {res.message}
                  <div>
                    {res.chatGroupMessageUrls.length != 0 && (
                      <img
                        className="chat-img"
                        src={`${res.chatGroupMessageUrls[0].url}`}
                        alt=""
                      />
                    )}
                  </div>
                </div>
              </div>
            ))
          )}
        </div>
        <div class="chat-input">
          <input
            onChange={(e) => setMessage(e.target.value)}
            type="text"
            placeholder="Mesajınızı yazın..."
          />
         <div class="input-group ms-2" style={{width:"250px"}}>
  <input onChange={onFileDrop} type="file" class="form-control" id="inputGroupFile01"/>
</div>
          <button onClick={send}>Gönder</button>
        </div>
      </div>
      <div className="chat-author-and-online-div mt-5">
        <div className="chat-online-list">
          <div className="chat-author-title">Çevrimiçi Kullanıcılar</div>
          <div className="chat-author-info mb-2">
            <div style={{ position: "relative" }}>
              <img class="chat-author-img" src="/img/userface2.jpg" />
              <img
                className="chat-online-list-icon"
                src="/img/online-icon.png"
                alt=""
              />
            </div>
            <div className="chat-author-username">usernameusername</div>
          </div>
        </div>
        <div className="chat-author">
          <div className="chat-author-title">Sohbet Sahibi</div>

          <div className="chat-author-info mb-2">
            <img
              class="chat-author-img"
              src={`${chatDetail.profilePhotoUrl}`}
            />

            <div className="chat-author-username">{chatDetail.userName}</div>
          </div>
          <div className="chat-author-date">
            <FcCalendar className="chat-author-date-icon" />
            <span className="uspd-author-date-p mt-1">
              {new Date(chatDetail.createdDate).toLocaleDateString("tr-TR", {
                year: "numeric",
                month: "long",
                day: "numeric",
                weekday: "long",
              })}
            </span>{" "}
          </div>
        </div>
      </div>
    </div>
  );
};

export default Chat;
