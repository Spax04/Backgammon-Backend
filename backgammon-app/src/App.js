import { getAllByText } from '@testing-library/react'
import React, { useState, useEffect } from 'react'
import { Routes,Route } from 'react-router-dom'

import Chat from './components/Chat/Chat'
import NavBar from './components/NavBar/navbar'
import Home from './components/Home/home'


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
        <Route path="/" exact element={<Home/>}></Route>
        <Route path="/startgame" exact element={<Home/>}></Route>
        <Route path="/friends" exact element={<Home/>}></Route>
        <Route path="/rules" exact element={<Home/>}></Route>
      </Routes>

    </div>
  )
}

export default App
