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


function App () {
  const service = new IdentityService()
  const chatService = new ChatService();

  const navigate = useNavigate()
  const [isRendered, setIsRendered] = useState(false)
  const [user, setUser] = useState(null);
  const [chatter, setChatter] = useState(null)
  const [chattersOnline, setChattersOnline] = useState([])

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

  const getChatterOnlineFromApi = () => {
    
    chatService
      .GetChattersOnline()
      .then(resp => {
        return resp.json()
      })
      .then(resp => {
        setChattersOnline(resp)
        console.log(chattersOnline)
      })
    
  }

  useEffect(() => {
    let token = sessionStorage.getItem('token')
    if (token === '' || token === null) {
      navigate('/login')
    } else {
      getUserFromApi(token)
      getChatterFromApi(token)
      getChatterOnlineFromApi()
    }
  }, [])

  return (
    <div>
      {user ? (
        <NavBar isLogedIn={true} setUser={setUser} />
      ) : (
        <NavBar isLogedIn={false} setUser={setUser} />
      )}

      <Routes>
        <Route path='/' exact element={<Home user={user} chatter={chatter} chattersOnline={chattersOnline} />} />
        <Route path='/login' element={<Login setUser={setUser} setChatter={setChatter} />} />
        <Route path='/register' element={<Register />} />
        <Route path='/rules' element={<Rules />} />
      </Routes>
    </div>
  )
}

export default App
