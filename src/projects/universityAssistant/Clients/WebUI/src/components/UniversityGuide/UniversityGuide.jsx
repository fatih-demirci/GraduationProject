import React from "react";
import { Link } from "react-router-dom";
import TurkeyMap from "turkey-map-react";
import "./UniversityGuide.css";
import { useEffect } from "react";
import { useRef } from "react";
import { useState } from "react";
const UniversityGuide = () => {
  const [first, setfirst] = useState({
    pageX:0,
    pageY:0
  })
  console.log(first);
  let coor;
  function myFunction(e) {
    first.pageX = e.clientX;
    first.pageY = e.clientY;
    // coor = "Coordinates: (" + x + "," + y + ")";
    document.getElementById("coor").innerHTML = first.pageX + " + " + first.pageY;
  }
  console.log(coor);


  function clearCoor() {
    document.getElementById("info").innerHTML = "İl seçiniz.";
  }

  const [data, setData] = useState([])

  return (
    <div className="turkey-map">
      <div id="info">İl seçiniz.</div>
      <div  onMouseMove={myFunction} onMouseOut={clearCoor} >
      <TurkeyMap
      customStyle={{ idleColor: "#444", hoverColor: "#dc3528" }}
      // data={setData}
        hoverable={true}
        onHover={({ plateNumber, name }) =>  ( <div >{document.getElementById("info").innerHTML = name}</div> )
    }
        onClick={({ plateNumber, name }) =>
        (
          (window.location.href = "/university-guide" + "/" + plateNumber)
         
   ) }
      />
      </div>

      {/* <img src='img/Turkey_provinces_blank_gray.svg'></img> */}
    </div>
  );
};

export default UniversityGuide;
