import React from "react";

const TextArea = ({ span, placeholder, type, value, setState }) => {
  return (
    <div class="input-group">
        {" "}
      <textarea
        className=" ms-2 form-control"
        aria-label="With textarea"
        type={type}
        placeholder={placeholder}
        value={value}
        onChange={(e) => setState(e.target.value)}
      ></textarea>
    </div>
  );
};

export default TextArea;
