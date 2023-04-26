import React from "react";

const TextArea = ({ span, placeholder, type, value, setState }) => {
  return (
    <div class="input-group">
        {" "}
        <img style={{width:"60px",height:"60px",borderRadius:"50%"}} src="/img/userface2.jpg" alt="" />
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
