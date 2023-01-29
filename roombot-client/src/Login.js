import React, { useState, useRef } from 'react';
import { useNavigate } from 'react-router-dom';
import LoginCss from './css/login.css';
import InputLogin from './components/InputLogin';
import Button from './components/Button';
function Login() {
  const [loginInfo, setLoginInfo] = useState([]);
  const [errorBool, setErrorBool] = useState(false);
  const navigate = useNavigate();
  function updateLogin(loginInfo){
    setLoginInfo(loginInfo);
  }

  function handleLoginSubmit() {
    console.log(loginInfo);
    setErrorBool(true);
    //send info to API loginInfo[0]
    //and loginInfo[1]..
    //edit error message accordingly,
    //or redirect login with cookie.
    //navigate("/bot");
  }
  return (
    <div className="login-form">
        <div className="login-info">Roombot requires login autentication</div>
        <div className="login-info">................................................................................</div>
        <InputLogin reader={updateLogin}/>
        {errorBool && <div className="login-error">no login match.</div>}
        <Button name="Login" handler={handleLoginSubmit}/>
    </div>
  );
}

export default Login;