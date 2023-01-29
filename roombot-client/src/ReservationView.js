import React from 'react'
import Reservation from './components/Reservations'
import CSS from './css/reservations.css'
import { Options } from './config/data'
export default function ReservationView() {
  return (
    <div className='bot-container'>
        <div className="bot-header">Roombot 3.0</div>
        <div className="bot-header">................................................................................</div>
        <div className="bot-header">
            Manage your active reservations
        </div>
        <div className="bot-header">................................................................................</div>
        <Reservation remoteReservationList={Options.reservations} />
    </div>
  )
}
