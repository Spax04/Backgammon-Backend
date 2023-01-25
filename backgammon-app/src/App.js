import { getAllByText } from '@testing-library/react'
import React, { useState, useEffect } from 'react'
import { Routes,Route } from 'react-router-dom'

import Chat from './components/Chat/Chat'
import NavBar from './components/NavBar/navbar'
import Register from './components/HomePage/Register/Register'
import Login from './components/HomePage/Login/Login'
import Home from './components/HomePage/Home/Home'


function App () {
  const [alex, setAlex] = useState({})

  const getAllByText = () => {
    const url = 'http://localhost:5032/api/Test'
    fetch(url, {})
      .then(response => response.json())
      .then(postFormServer => {
        setAlex(postFormServer)
        console.log(postFormServer)
      })
  }

  useEffect(() => {
    getAllByText()
  }, [])

  return (
    <div>
      <NavBar/>
      <Routes>
        <Route path="/" exact element={<Login/>}></Route>
        <Route path="/startgame" exact element={<Home/>}></Route>
        <Route path="/contacts" exact element={<Home/>}></Route>
        <Route path="/rules" exact element={<Register/>}></Route>
        <Route path="/login" exact element={<Login/>}></Route>
        <Route path="/register" exact element={<Register/>}></Route>
      </Routes> 
      


    </div>
  )
}

export default App
