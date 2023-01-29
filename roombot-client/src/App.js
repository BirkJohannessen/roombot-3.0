
import React from 'react';
import Login from './Login'
import Admin from './Admin';
import Bot from './Bot'
import AppCss from './css/app.css'
import { Route, Routes } from 'react-router-dom';
import ReservationView from './ReservationView';
import Header from './components/Header'
function App() {
  return (
    <>
      <div className='page-container'>
        <Header />
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="/bot" element={<Bot />} />
          <Route path="/reservations" element={<ReservationView />} />
          <Route path="/admin" element={<Admin />} />
        </Routes>
      </div>
    </>
  );
}

export default App;
