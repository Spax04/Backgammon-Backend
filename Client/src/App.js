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
import Chats from './components/ContactsScreen/SideBar/Chats'

function App () {
  const service = new IdentityService()
  const chatService = new ChatService()

  const navigate = useNavigate()
  const [user, setUser] = useState(null)
  const [connection, setConnection] = useState()
  const [users,setUsers] = useState([])

  const StopConnection = ()=>{
    if(connection){
      connection
      .stop()
      .then(() => {
        console.log('Connection from signalR closed')
      })
    }
  }


  useEffect(() => {
    
      if(!user){
        setUser(JSON.parse(localStorage.getItem("USER_IDENTITY_2")))
      }
      if(!connection){
        chatService.InitConnection();
        setConnection(ChatService.connection);
      }
      console.log("$$$ AppJS $$$ " + connection)    
     
  }, [user,connection])


  return (
    <div>
      {user ? (
        <NavBar isLogedIn={true} setUser={setUser}  StopConnection={StopConnection} />
      ) : (
        <NavBar isLogedIn={false} setUser={setUser}  StopConnection={StopConnection} />
      )}

      <Routes>
        <Route
          path='/'
          exact
          element={<Home user={user}  setConnection={setConnection}/>}
        />
        <Route
          path='/login'
          element={<Login setUser={setUser}  setConnection={setConnection} />}
        />
        <Route path='/register' element={<Register />} />
        <Route path='/rules' element={<Rules />} />
      </Routes>
    </div>
  )
}

export default App
