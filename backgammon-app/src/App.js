import React, { useState, useEffect } from 'react'
import {Routes,Route } from 'react-router-dom'

import Chat from './components/Chat/Chat'
import NavBar from './components/NavBar/Navbar'
import Register from '../src/Pages/Register/Register'
import Login from '../src/Pages/Login/Login'
import Home from '../src/Pages/Home/Home'


function App () {
  
  return (
    <div>
      <NavBar/>
      <Routes>
        <Route path="/" exact element={<Home/>}></Route>
        <Route path="/contacts" element={<Home/>}></Route>
        <Route path="/rules" element={<Home/>}></Route>
        <Route path="/login" element={<Login/>}></Route>
        <Route path="/register" element={<Register/>}></Route>
      </Routes> 
      


    </div>
  )
}

export default App
