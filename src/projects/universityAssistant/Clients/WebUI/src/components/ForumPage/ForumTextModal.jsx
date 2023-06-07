import zIndex from "@mui/material/styles/zIndex";
import React from "react";
import { useEffect } from "react";
import ChatServices from "../../Services/ChatServices";
import { useState } from "react";
import { toast } from "react-toastify";

const ForumTextModal = ({
  title,
  setTitle,
  selectedValue,
  setSelectedValue,
}) => {
  let chatServices = new ChatServices();
  const [categories, setCategories] = useState([]);
  useEffect(() => {
    chatServices
      .GetAllCountryCategories()
      .then((res) => {
        setCategories(res.data.items);
        console.log(res.data.items);
      })
      .catch((err) => console.log(err));
  }, []);

  console.log(title);
  console.log(selectedValue);
  function addChatGroup() {
    chatServices.AddChatGroup(selectedValue,title).then(res => {
      toast.success("Başarıyla oluşturuldu",{
        autoClose:1500
      })
      setTimeout(() => {
        window.location.reload()
      }, 1500);
      console.log(res)}).catch(err => console.log(err))
    
  }
  return (
    <div>
      <div className="d-flex justify-content-center">
        <button
          type="button"
          class="btn btn-info r"
          data-bs-toggle="modal"
          data-bs-target="#exampleModal"
        >
          Bir sohbet başlat
        </button>
      </div>

      <div
        class="modal fade"
        id="exampleModal"
        tabindex="-1"
        aria-labelledby="exampleModalLabel"
        aria-hidden="true"
        style={{ marginTop: "80px" }}
      >
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <h1 class="modal-title fs-5" id="exampleModalLabel">
                Sohbet odası oluştur
              </h1>
              <button
                type="button"
                class="btn-close"
                data-bs-dismiss="modal"
                aria-label="Close"
              ></button>
            </div>
            <div class="modal-body">
              <div class="input-group mb-3">
                <span class="input-group-text" id="basic-addon1">
                  Başlık
                </span>
                <input
                  type="text"
                  class="form-control"
                  placeholder="Sohbet başlığı"
                  aria-label="Username"
                  aria-describedby="basic-addon1"
                  value={title}
                  onChange={(e) => setTitle(e.target.value)}
                />
              </div>
              <div>
                <select
                  onChange={(e) => setSelectedValue(e.target.value)}
                  class="form-select"
                  aria-label="Default select example"
                >
                  <option selected>Sohbet konusu</option>
                  {categories.map((data) => (
                    <option value={data.id}>{data.name}</option>
                  ))}
                </select>
              </div>
            </div>
            <div class="modal-footer">
              <button
                type="button"
                class="btn btn-secondary"
                data-bs-dismiss="modal"
              >
                Kapat
              </button>
              <button onClick={addChatGroup} type="button" class="btn btn-primary">
                Oluştur
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ForumTextModal;
