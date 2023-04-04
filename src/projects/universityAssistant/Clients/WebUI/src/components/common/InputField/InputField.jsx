import React from 'react'

const InputField = ({span,placeholder,type,value,setState}) => {
  return (
    <div class="input-group mb-3">
  {/* <span class="input-group-text" id="basic-addon1">{span}</span>
  <input type={type} class="form-control" placeholder={placeholder} aria-label="Username" aria-describedby="basic-addon1"/> */}
  <input
            className="signin-form-input"
            type={type}
            placeholder={placeholder}
            value={value}
            onChange={(e) => setState(e.target.value)}
          />
</div>
  )
}

export default InputField