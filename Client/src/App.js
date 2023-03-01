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
  const [chatters, setChatters] = useState([])

  const StopConnection = ()=>{
    if(connection){
      connection
      .stop()
      .then(() => {
        console.log('Connection from signalR closed')
      })
    }
  }

  const InitConnection = () =>{
    const connection = new HubConnectionBuilder()
    .withUrl(
      `http://localhost:7112/hub/chat/?token=${sessionStorage.getItem(
        'token'
      )}`
    )
    .build()
    console.log(connection)
    setConnection(connection);
   
    connection
    .start()
    .then(() => {
      console.log('Connection started!')
      console.log(connection)
      setConnection(connection);
     
      connection.on('ChatterConnected', newChatter=>{
        const newArr = [...chatters, newChatter]
        setChatters(newArr)
      });

      connection.on('SetChatters', chattersOnline => {
        console.log(chattersOnline)
        const newArr = [...chattersOnline]
        console.log(newArr)
        setChatters(newArr)
        
      });
      
    })
    .catch(error => {
      console.log('Conection closed with error fromCLient')
      console.error(error.message)
    })
    console.log(chatters);
  }


  useEffect(() => {
    
      if(!user){
        setUser(JSON.parse(localStorage.getItem("USER_IDENTITY_2")))
      }
      if(!connection){
        InitConnection();
      }
  }, [user,connection,chatters])


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
          element={<Home user={user} chatters={chatters} />}
        />
        <Route
          path='/login'
          element={<Login setUser={setUser} setChatters={setChatters}  InitConnection={InitConnection} />}
        />
        <Route path='/register' element={<Register />} />
        <Route path='/rules' element={<Rules />} />
      </Routes>
    </div>
  )
}

export default App
