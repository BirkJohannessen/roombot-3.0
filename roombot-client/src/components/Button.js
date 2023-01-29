import ButtonCss from '../css/button.css'
function Button({ name, handler }) {
  return (
        <button onClick={() => handler()} className="button">{name}</button>
  );
}

export default Button;