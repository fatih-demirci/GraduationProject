import zIndex from "@mui/material/styles/zIndex";
import React from "react";

const ForumTextModal = () => {
  return (
    <div>
      <div className="d-flex justify-content-center">
        <button
          type="button"
          class="btn btn-info r"
          data-bs-toggle="modal"
          data-bs-target="#exampleModal"
        >
          Bir tartışma başlat
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
                Modal title
              </h1>
              <button
                type="button"
                class="btn-close"
                data-bs-dismiss="modal"
                aria-label="Close"
              ></button>
            </div>
            <div class="modal-body">...</div>
            <div class="modal-footer">
              <button
                type="button"
                class="btn btn-secondary"
                data-bs-dismiss="modal"
              >
                Close
              </button>
              <button type="button" class="btn btn-primary">
                Save changes
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ForumTextModal;
