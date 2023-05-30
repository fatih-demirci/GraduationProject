import React from "react";
import { useRef } from "react";
import { useState } from "react";
import { ImageConfig } from "../FileUploadComponent/ImageConfig.js";
import uploadIMG from "../../../../src/assets/cloud-upload-regular-240.png";
import "./FileUploadComponent.css"

const FileUploadComponent = ({ file, setFile, uploaded }) => {
  //   const [file, setFile] = useState([]);
  //   const [uploaded, setUploaded] = useState(null);
  const wrapperRef = useRef(null);
  const onDragEnter = () => wrapperRef.current.classList.add("dragover");

  const onDragLeave = () => wrapperRef.current.classList.remove("dragover");

  const onDrop = () => wrapperRef.current.classList.remove("dragover");

  const fileRemove = (filee) => {
    const updatedList = [...file];
    updatedList.splice(file.indexOf(filee), 1);
    setFile(updatedList);
  };

  const onFileDrop = (e) => {
    const newFile = e.target.files[0];
    if (newFile) {
      const updatedList = [...file, newFile];
      setFile(updatedList);
      // setUploadFile(updatedList)
      // props.onFileChange(updatedList);
    }
  };
  console.log(file);
  console.log(uploaded);
  return (
    <div className="drop-file-input-div">
      <div
        ref={wrapperRef}
        onDragEnter={onDragEnter}
        onDragLeave={onDragLeave}
        onDrop={onDrop}
        className="drop-file-input mt-4"
      >
        <div className="drop-file-input__label">
          <img src={uploadIMG}></img>
          <p>SÜRÜKLE VE BIRAK</p>
        </div>
        <input type="file" onChange={onFileDrop}></input>
      </div>

      {file.length > 0 ? (
        <div className="drop-file-preview">
          {/* <p className="drop-file-preview__title">Ready to upload</p> */}
          {file.map((item, index) => (
            <div key={index} className="drop-file-preview__item">
              <img
                src={
                  ImageConfig[item.type.split("/")[1]] || ImageConfig["default"]
                }
                alt=""
              />
              <div className="drop-file-preview__item__info">
                <p>{item.name}</p>
                <p>{(item.size / (1024 * 1024)).toFixed(2)} MB</p>
              </div>
              <span
                className="drop-file-preview__item__del"
                onClick={() => fileRemove(item)}
              >
                x
              </span>
            </div>
          ))}
        </div>
      ) : null}
      {uploaded && (
        <div className="progress mt-2">
          <div
            className="progress-bar"
            role="progressbar"
            aria-valuenow={uploaded}
            aria-valuemin="0"
            aria-valuemax="100"
            style={{ width: `${uploaded}%` }}
          >
            {`${uploaded}%`}
          </div>
        </div>
      )}
    </div>
  );
};

export default FileUploadComponent;
