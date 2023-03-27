import React from "react";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import "./Carousel.css"
import { style } from "@mui/system";

const Carousel = () => {
  function SampleNextArrow(props) {
    const { className, style, onClick } = props;
    return (
      <div
        className={className}
         style={{
          // width: "50px",
          // height: "50px",
          filter:
            "invert(3%) sepia(7%) saturate(7029%) hue-rotate(94deg) brightness(86%) contrast(93%)"
        }}
        onClick={onClick}
      />
    );
  }
  function SamplePrevArrow(props) {
    const { className, style, onClick } = props;
    return (
      <div
        className={className}
        style={{
          // width: "50px",
          // height: "50px",
          filter:
            "invert(3%) sepia(7%) saturate(7029%) hue-rotate(94deg) brightness(86%) contrast(93%)"
        }}
        onClick={onClick}
      />
    );
  }
  var settings = {
    dots: true,
    infinite: false,
    speed: 500,
    slidesToShow: 3,
    slidesToScroll: 3,
    initialSlide: 0,
    nextArrow: <SampleNextArrow />,
      prevArrow: <SamplePrevArrow />,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2,
          infinite: true,
          dots: true,
        },
      },
      {
        breakpoint: 600,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2,
          initialSlide: 2,
        },
      },
      {
        breakpoint: 480,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
        },
      },
    ],
  };
  return (
    <div className="slider-div">
      <Slider {...settings}>
        <div className="slider-item-div">
        <div className="slider-item">
          <p className="slider-text-title">Title title title</p>
          <p className="slider-text-title">Text text text text text</p>
        </div>
        </div>
        <div className="slider-item-div">
        <div className="slider-item">
          <p className="slider-text-title">Title title title</p>
          <p className="slider-text-title">Text text text text text</p>
        </div>
        </div>
        <div className="slider-item-div">
        <div className="slider-item">
          <p className="slider-text-title">Title title title</p>
          <p className="slider-text-title">Text text text text text</p>
        </div>
        </div>
        <div className="slider-item-div">
        <div className="slider-item">
          <p className="slider-text-title">Title title title</p>
          <p className="slider-text-title">Text text text text text</p>
        </div>
        </div>
        <div className="slider-item-div">
        <div className="slider-item">
          <p className="slider-text-title">Title title title</p>
          <p className="slider-text-title">Text text text text text</p>
        </div>
        </div>
      </Slider>
    </div>
  );
};

export default Carousel;
