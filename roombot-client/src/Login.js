import LoginCss from './css/login.css'
function Login() {
  return (
    <div className="login-form">
        <input type="text" className="login-input"/>
        <input type="password" className="login-input"/>
    </div>
  );
}

export default Login;