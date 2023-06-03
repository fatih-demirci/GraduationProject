import React from "react";
import "./Chat.css";
import { FcCalendar } from "react-icons/fc";
const Chat = () => {
  return (
    // <div
    // //   ref={ref}
    //   className={`message  owner mt-5
    //     // message.senderId === currentUser.uid && "owner"

    //   `
    // }
    // >
    //   <div className="messageInfo">
    //     <img
    //       src={
    //         // message.senderId === currentUser.uid
    //         //   ? currentUser.photoURL
    //         //   : data.user.photoURL
    //         "/img/userface.jpg"
    //       }
    //       alt=""
    //     />
    //     <span>just now</span>
    //   </div>
    //   <div className="messageContent">
    //     {/* <p>{message.text}</p> */}
    //     <p className="messageContent-p">message.text</p>
    //     {/* {message.img && <img src={message.img} alt="" />} */}
    //     <img className='messageContentImage' src="/img/userface2.jpg"alt="" />
    //   </div>
    // </div>
    <div className="container" style={{ marginTop: "80px" }}>
      <div className="chat-info">
        <div className="chat-info-title">
          Tyt matematikte süre sıkıntısı ve kaynak önerisi
        </div>
        <div className="chat-info-tag" style={{ backgroundColor: "#0fbbff" }}>
          Sayısal
        </div>
      </div>
      <div class="chat-container  ">
        <div class="chat-messages">
          <div class="message received">
            <img class="avatar" src="/img/userface.jpg" />
            <div class="message-content-received">
            Merhaba! Merhaba! Nasılsın? Merhaba! Merhaba! Nasılsın? {" "}
            </div>
          </div>
          <div class="message sent ">
            <div class="message-content-sent">
              <p className="sent"> Merhaba! Nasılsın?</p>
            </div>
            <img class="avatar" src="/img/userface2.jpg" />
          </div>
        </div>
        <div class="chat-input">
          <input type="text" placeholder="Mesajınızı yazın..." />
          <button>Gönder</button>
        </div>
      </div>
      <div className="chat-author-and-online-div">
        
        <div className="chat-online-list">
        <div className="chat-author-title">Çevrimiçi Kullanıcılar</div>
          <div className="chat-author-info mb-2">
            <div style={{position:"relative"}}>
            <img class="chat-author-img" src="/img/userface2.jpg" />
<img className="chat-online-list-icon" src="/img/online-icon.png" alt="" />
</div>
            <div className="chat-author-username">usernameusername</div>
            
          </div>
        </div>
        <div className="chat-author">
          <div className="chat-author-title">Sohbet Sahibi</div>

          <div className="chat-author-info mb-2">
            <img class="chat-author-img" src="/img/userface2.jpg" />

            <div className="chat-author-username">usernameusername</div>
          </div>
          <div className="chat-author-date">
            <FcCalendar className="chat-author-date-icon" />
            11.03.2020
          </div>
        </div>
      </div>
    </div>
  );
};

export default Chat;
