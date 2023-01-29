import React, { useState } from 'react'
import CSS from './../css/reservations.css'
import x from './../img/x.png'
export default function Reservations({ remoteReservationList }) {
    const [reservations, setReservations] = useState(remoteReservationList);
    function handleX(id){
        console.log(id);
        console.log(reservations);
        const resCopy = reservations;
        const newdata = resCopy.filter(x => x.id!=id);
        setReservations(newdata);
    }
  return (
    <div className='reservations-container'>
        {reservations.map(obj => {
            return (
                <div className='reservation'>
                    <div className='res-info-long'>{obj.username}</div>
                    <div className='res-info-short'>{obj.room}</div>
                    <div className='res-info-short'>{obj.from}</div>
                    <div className='res-info-short'>{obj.to}</div>
                    <div className='res-info-long'>{obj.mode}</div>
                    <img onClick={() => handleX(obj.id)} src={x} className='res-img' />
                </div>
            )
        })}
    </div>
  )
}
