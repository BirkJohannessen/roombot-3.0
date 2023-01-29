import React, { useRef } from 'react';
import InputCss from '../css/inputlogin.css';
function InputLogin({reader}) {
  const username = useRef();
  const password = useRef();
  function update(){
    //reader([username.current.value, password.current.value]);
    reader({"username":username.current.value, "password":password.current.value});
  }
  return (
    <div className="input-wrapper">
        <input onChange={update} ref={username} type="text" className="input"/>
        <input onChange={update} ref={password} type="password" className="input"/>
    </div>
  );
}

export default InputLogin;