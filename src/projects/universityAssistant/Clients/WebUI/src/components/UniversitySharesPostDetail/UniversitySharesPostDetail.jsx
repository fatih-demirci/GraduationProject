import React from "react";
import "./UniversitySharesPostDetail.css";
import CarouselBootstrap from "../common/CarouselBootstrap/CarouselBootstrap";
import {FcCalendar} from "react-icons/fc"
const UniversitySharesPostDetail = () => {
  return (
    <div className="container university-shares-post-detail-container">
      <CarouselBootstrap />
      <div className="university-shares-post-detail mt-3">
        <div className="uspd-author">
          <div className="uspd-author-info">
            <img className="uspd-author-img" src="/img/userface.jpg" alt="" />
            <div className="uspd-author-name">
               <p className="uspd-author-name-p">usernameusername</p> </div>
          </div>
          <div className="uspd-author-date">
            <span className="uspd-author-date-calendar-icon">
           <FcCalendar style={{marginBottom:"4px",marginRight:"7px"}}/>

            </span>
           <p className="uspd-author-date-p">
             11.03.2023</p> </div>
        </div>
        <div className="uspd-title-text mt-3">
          <h3 className="uspd-title">
            Title title title title titletitle title title title titletitle
          </h3>
          <div className="uspd-text mt-3">
            Lorem, ipsum dolor sit amet consectetur adipisicing elit. Iure
            quaerat eveniet voluptatibus et omnis, beatae cum neque vitae quae
            explicabo quo tempore. Unde ullam ratione, ipsam eos assumenda dicta
            ipsa accusantium exercitationem harum alias facilis optio fugit
            illo, labore blanditiis repudiandae expedita, nam repellat? Quos
            quisquam temporibus itaque eos. Esse praesentium impedit deleniti
            aspernatur modi temporibus debitis saepe vitae, porro at. Nemo quia
            tenetur et repellat? Quia rem iusto dignissimos, id nostrum, quas
            fugit quaerat tempora voluptate aspernatur sint laborum minus
            mollitia cum labore ipsum illum unde repudiandae animi saepe neque.
            Aliquid vel eum animi voluptatem repellat laudantium fugiat
            repudiandae earum dolorum quis consectetur, exercitationem dolores
            tempora assumenda? A, quisquam? Exercitationem incidunt repudiandae
            quo deserunt architecto quam, laudantium, velit, placeat qui
            pariatur recusandae corrupti provident! Voluptate, totam ex? Aliquam
            quibusdam nobis recusandae praesentium voluptate tempora ex modi hic
            veniam reiciendis fugiat quis, doloribus quas distinctio voluptas,
            explicabo officia id maxime nostrum animi illum maiores deleniti
            quia? Dolorem delectus possimus explicabo asperiores eligendi,
            temporibus velit? Quia animi blanditiis harum alias expedita modi
            dolorum accusantium unde pariatur error quae quaerat voluptatem
            repudiandae illum molestiae at, perspiciatis quidem veritatis ullam!
            In quas porro dolores aliquam voluptatem quod amet quam animi cumque
            aperiam autem nostrum officiis provident necessitatibus reiciendis
            nulla, quibusdam distinctio harum vero nisi. Delectus provident
            eaque cumque debitis, laudantium modi mollitia sequi blanditiis,
            sunt, eum officiis ut ipsa accusamus. Et, incidunt odio aliquid
            aliquam quis consequuntur totam ducimus. Eos, ex neque enim
            repellendus cupiditate corporis, illo similique facilis, architecto
            at maxime. Voluptate, animi id. Error dicta, sit nesciunt,
            perspiciatis magni quis illo adipisci accusantium fugit facilis
            sequi, praesentium harum autem porro unde. Cum laborum eos suscipit
            sed aliquam in beatae, quae ducimus autem? Atque deleniti placeat
            tempore dolore reiciendis. Facere, fugit veritatis. Qui distinctio
            libero praesentium, itaque molestias totam ipsum? Placeat, beatae!
          </div>
        </div>
      </div>
    </div>
  );
};

export default UniversitySharesPostDetail;
