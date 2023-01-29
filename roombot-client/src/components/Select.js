import React, { useRef } from 'react';
import SelectCSS from '../css/select.css'

export default function Select( { id, reader, options } ) {
  const selectedOption = useRef();
  function change(){
    const obj = {}
    obj[`${id}`] = selectedOption.current.value;
    reader(obj);
  }
  return (
        <select ref={selectedOption} onChange={change} className="select">
            {options.map(element => {
                return <option>{element}</option>
            })}
        </select>
  )
}
