import LoginCss from './css/bot.css'
import InputLogin from './components/InputLogin';
import InputCss from './css/select.css'
import Button from './components/Button'
import SelectRoom from './components/SelectRoom';
import SelectTime from './components/SelectTime';
function Bot() {
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
          <InputLogin />
          <div className="bot-forminfo">Grupperom</div>
          <SelectRoom />
          <div className="bot-forminfo">Fra</div>
          <SelectTime />
          <div className="bot-forminfo">Til</div>
          <SelectTime />
          <div className="bot-forminfo">Roombotmode</div>
          <select className="select">
            <option>Kjør kontinuerlig</option>
            <option>Kjør en gang</option>
          </select>
          
          <Button />

        </div>


    </div>
  );
}

export default Bot;