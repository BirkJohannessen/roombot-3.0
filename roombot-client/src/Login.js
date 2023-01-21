import LoginCss from './css/login.css'
function Login() {
  var error=false;
  function login(inp) {
    error=true;
    console.log(inp);
  }
  return (
    <div className="login-form">
        <div class="login-info">Roombot requires login autentication</div>
        <div class="login-info">................................................................................</div>
        <input type="text" className="login-input"/>
        <input type="password" className="login-input"/>
        <div if={error} class="login-error">no login match.</div>
        <button class="login-submit" OnClick={login("asdf")} >Login</button>
    </div>
  );
}

export default Login;