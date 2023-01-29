import React, { useState } from 'react'
import Reservations from './components/Reservations'
import { Options } from './config/data'
import InputLogin from './components/InputLogin'
import Button from './components/Button'

export default function Admin() {
  //TODO: do not render if isAdmin function returns false.
  //implement isAdmin.
  return (
    <div className='bot-container'>
        <div className="bot-header">Roombot 3.0</div>
        <div className="bot-header">................................................................................</div>
        <div className="bot-header"> Secret Admin Page </div>
        <div className="bot-header">................................................................................</div>
        <div className="bot-header"> Register user </div>
            <InputLogin /> 
            <Button name="Register user"/>
        <div className="bot-header">................................................................................</div>
        <div className="bot-header">All user data</div>
            <Reservations remoteReservationList={Options.reservations} />
    </div>
  )
}
