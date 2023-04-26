import zIndex from "@mui/material/styles/zIndex";
import JoditEditor from "jodit-react";
import React, { useMemo, useRef, useState } from "react";
import "./TextModal.css"

const TextModal = ({ initialValue, getValue }) => {
  const editor = useRef(null);
	const [content, setContent] = useState('');
  // const config = useMemo(
	// 	{
	// 		readonly: false, // all options from https://xdsoft.net/jodit/docs/,
	// 		placeholder: placeholder || 'Start typings...'
	// 	},
	// 	[placeholder]
	// );
  return (
    <div className="text-modal-container">
      <div className="d-flex justify-content-center">
        <button
          type="button"
          class="btn btn-info r"
          data-bs-toggle="modal"
          data-bs-target="#exampleModal"
        >
          Bir gönderi paylaş.
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
        <div class="modal-dialog modal-xl">
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
            <div class="modal-body">
            <JoditEditor
        ref={editor}
        value={initialValue}
        // config={config}
        // tabIndex={10}
        onBlur={(newContent) => getValue(newContent)}
        // onChange={(newContent) => getValue(newContent)}
      />
            </div>
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

export default TextModal;
