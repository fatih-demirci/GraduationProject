import React from 'react'
import "./CarouselBootstrap.css"
import { useState } from 'react';
const CarouselBootstrap = ({commentDetailFiles}) => {
  console.log(commentDetailFiles);
  console.log(commentDetailFiles.length);

  return (
    <div style={commentDetailFiles.length===0 ? {display:"none"} : {display:"block"}}>
    <div className="carousel-bootstrap-main-div">
    <div id="carouselExampleAutoplaying" className="carousel slide carousel-bootstrap" data-bs-ride="carousel">
  <div className="carousel-inner">
    {/* <div className="carousel-item carousel-itemm active">
      <img src="/img/firatunilogo.png" className="d-block w-100 carousel-bootstrap-img" alt="..."/>
    </div> */}
    {commentDetailFiles.map(res => (
    <div className="carousel-item carousel-itemm active">
      <img src={res.Url} className="d-block w-100 carousel-bootstrap-img" alt="..."/>
    </div>
    ))}
    {/* <div className="carousel-item carousel-itemm">
      <img src="/img/firatunilogo.png" className="d-block w-100 carousel-bootstrap-img" alt="..."/>
    </div> */}
  </div>
  <button  className="carousel-control-prev" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="prev">
    <span className="carousel-control-prev-icon" aria-hidden="true"></span>
    <span className="visually-hidden" >Previous</span>
  </button>
  <button className="carousel-control-next" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="next">
    <span className="carousel-control-next-icon" aria-hidden="true"></span>
    <span className="visually-hidden">Next</span>
  </button>
</div>
</div>
</div>
  )
}

export default CarouselBootstrap