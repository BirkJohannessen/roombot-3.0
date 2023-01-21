import LoginCss from './css/login.css'
import InputLogin from './components/InputLogin'
import Button from './components/Button'
function Login() {
  var error=false;
  function login(inp) {
    error=true;
    console.log(inp);
  }
  return (
    <div className="login-form">
        <div className="login-info">Roombot requires login autentication</div>
        <div className="login-info">................................................................................</div>
        <InputLogin />
        <div if={error.toString()} className="login-error">no login match.</div>
        <Button onClick={login("213")}/>
    </div>
  );
}

export default Login;