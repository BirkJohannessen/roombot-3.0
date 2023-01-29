import React from 'react'
import { useNavigate } from 'react-router-dom';
import css from './../css/header.css'
export default function Header() {
  const navigate = useNavigate();
    function isAdmin(){
        return true;
    }
    function logout(){
        console.log("logout");
        navigate("/")
    }
  return (
    <div className='header-container'>
        <div className='header'>
            Roombot
        </div>
        <div className='nav-wrap'>
            {isAdmin() && <div className='nav-elem' onClick={() => navigate("/admin")}>admin</div>}
            <div className='nav-elem' onClick={() => navigate("/bot")}>bot</div>
            <div className='nav-elem' onClick={() => navigate("reservations")}>reservations</div>
            <div className='nav-elem' onClick={() => logout()}>logout</div>
        </div>

    </div>
  )
}
