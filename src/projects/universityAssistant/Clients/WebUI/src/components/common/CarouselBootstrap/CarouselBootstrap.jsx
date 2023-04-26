import React from 'react'
import "./CarouselBootstrap.css"
const CarouselBootstrap = () => {
  return (
    <div className="carousel-bootstrap-main-div">
    <div id="carouselExampleAutoplaying" className="carousel slide carousel-bootstrap" data-bs-ride="carousel">
  <div className="carousel-inner">
    <div className="carousel-item carousel-itemm active">
      <img src="/img/firatuni.jpg" className="d-block w-100 carousel-bootstrap-img" alt="..."/>
    </div>
    <div className="carousel-item carousel-itemm justify-content-center">
      <img src="/img/userface.jpg" className="d-block w-100 carousel-bootstrap-img" alt="..."/>
    </div>
    <div className="carousel-item carousel-itemm">
      <img src="/img/firatunilogo.png" className="d-block w-100 carousel-bootstrap-img" alt="..."/>
    </div>
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
  )
}

export default CarouselBootstrap