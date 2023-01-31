import React, { useState, useEffect } from 'react'
import { Routes, Route, useNavigate } from 'react-router-dom'
import IdentityService from './services/IdentityService'
import Chat from './components/Chat/Chat'
import NavBar from './components/NavBar/Navbar'
import Register from '../src/Pages/Register/Register'
import Login from '../src/Pages/Login/Login'
import Home from '../src/Pages/Home/Home'
import Rules from './Pages/Rules/Rules'

function App () {
  const service = new IdentityService()

  const navigate = useNavigate()
  const [isRendered, setIsRendered] = useState(false)
  const [user, setUser] = useState(null)

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

  useEffect(() => {
    let token = sessionStorage.getItem('token')
    if (token === '' || token === null) {
      navigate('/login')
    } else {
      getUserFromApi(token)
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
        <Route path='/' exact element={<Home user={user} />} />
        <Route path='/login' element={<Login setUser={setUser} />} />
        <Route path='/register' element={<Register />} />
        <Route path='/rules' element={<Rules />} />
      </Routes>
    </div>
  )
}

export default App
