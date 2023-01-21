
import React from 'react';
import Login from './Login'
import Bot from './Bot'
import AppCss from './css/app.css'
import { Route, Routes } from 'react-router-dom';
function App() {
  return (
    <>
      <div className='page-container'>
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="/bot" element={<Bot />} />
        </Routes>
      </div>
    </>
  );
}

export default App;
