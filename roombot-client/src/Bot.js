import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';
import LoginCss from './css/bot.css'
import InputCss from './css/select.css'
import InputLogin from './components/InputLogin';
import Button from './components/Button'
import { Options } from './config/data'
import Select from './components/Select';

function Bot() {
  const [bookInfo, setBookInfo] = useState({"username":"", "password":"", "room":"A204", "from":"06:00", "to":"06:00", "mode":"Kjør kontinuerlig"});
  const navigate = useNavigate();

  function updateInfo(update){
    const newBookInfo = bookInfo;
    for (const prop in update){
      newBookInfo[`${prop}`] = update[`${prop}`];
    }
    setBookInfo(newBookInfo);
  }

  function handleBookSubmit() {
    console.log(bookInfo);
    //local check, throw error.
    //send to api
    navigate("/reservations");
  }

  return (
    <div className="bot-container">
        <div className="bot-header">Roombot 3.0</div>
        <div className="bot-header">................................................................................</div>
        <div className="bot-info">
            Grunnet måten roombot håndterer tidslogikk blir data lagret. Men brukeren har tilgang på å slette dataen/reservasjonen.
            Jeg har gått til en tilstrekkelig lengde å sørge for at jeg ikke skal kunne lese passordene til brukere i klartekst i log og database.
            Det krever tillit fra brukeren å stole på at jeg ikke har ond hensikt.
            Alternativt kan du bruke CLI verktøyet <a className="bot-info" href="https://github.com/BirkJohannessen/ROOMBOT">ROOMBOT 1.0</a> lokalt.
        </div>
        <div className="bot-header">................................................................................</div>
        <div className="bot-form">
          <div className="bot-forminfo">Feide login</div>
          <InputLogin reader={updateInfo} />

          <div className="bot-forminfo">Grupperom</div>
          <Select id="room" reader={updateInfo} options={Options.rooms} />

          <div className="bot-forminfo">Fra</div>
          <Select id="from" reader={updateInfo} options={Options.hours} />

          <div className="bot-forminfo">Til</div>
          <Select id="to" reader={updateInfo} options={Options.hours} />

          <div className="bot-forminfo">Roombotmode</div>
          <Select id="mode" reader={updateInfo} options={Options.modes} />

          <Button handler={handleBookSubmit} name="Book" />

        </div>


    </div>
  );
}

export default Bot;