import React, { useState, useEffect } from 'react'
import { Routes, Route, useNavigate } from 'react-router-dom'
import IdentityService from './services/IdentityService'

import Chat from './components/Chat/Chat'
import NavBar from './components/NavBar/Navbar'
import Register from '../src/Pages/Register/Register'
import Login from '../src/Pages/Login/Login'
import Home from '../src/Pages/Home/Home'
import Rules from './Pages/Rules/Rules'
import ChatService from './services/ChatService'
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr'

function App () {
  const service = new IdentityService()
  const chatService = new ChatService()

  const navigate = useNavigate()
  const [user, setUser] = useState(null)
  const [chatter, setChatter] = useState(null)
  const [connection, setConnection] = useState()

  const getUserFromApi = token => {
    if (token == null) {
      service
        .GetUser(token)
        .then(resp => {
          return resp.json()
        })
        .then(resp => {
          setUser(resp)
        })
    }
  }

  const getChatterFromApi = token => {
    if (token == null) {
      chatService
        .GetChatter(token)
        .then(resp => {
          return resp.json()
        })
        .then(resp => {
          setChatter(resp)
          console.log(chatter)
        })
    }
  }

  useEffect(() => {
    let token = sessionStorage.getItem('token')
    if (token === '' || token === null) {
      navigate('/login')
    } else {
      getUserFromApi(token)
      getChatterFromApi(token)
      chatService.InitConnection()

    }
  }, [])

  return (
    <div>
      {user ? (
        <NavBar isLogedIn={true} setUser={setUser}  connection={connection} />
      ) : (
        <NavBar isLogedIn={false} setUser={setUser}  connection={connection} />
      )}

      <Routes>
        <Route
          path='/'
          exact
          element={<Home user={user} chatter={chatter} />}
        />
        <Route
          path='/login'
          element={<Login setUser={setUser} setChatter={setChatter} setConnection={setConnection} />}
        />
        <Route path='/register' element={<Register />} />
        <Route path='/rules' element={<Rules />} />
      </Routes>
    </div>
  )
}

export default App
