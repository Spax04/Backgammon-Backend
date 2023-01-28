import React, { useState, useEffect } from 'react'
import {Routes,Route,useNavigate } from 'react-router-dom'
import IdentityService from './services/IdentityService'
import Chat from './components/Chat/Chat'
import NavBar from './components/NavBar/Navbar'
import Register from '../src/Pages/Register/Register'
import Login from '../src/Pages/Login/Login'
import Home from '../src/Pages/Home/Home'


function App () {
  const service = new IdentityService();

  const navigate = useNavigate();
  const [user,setUser] = useState(null);

  useEffect(()=>{
    (
      async () =>{
        let userId = sessionStorage.getItem('id');
        if(userId ==="" || userId === null ){
        
        }else{
          service.GetUser(userId)
          .then((resp) =>  {
            return resp.json()
          })
          .then((resp)=>{
            console.log(resp)
            setUser(resp)
            console.log(user)
          })
        }
      }
    )(); 
    

  },[])
  

  // },[])
  return (
    <div>
      <NavBar />
      <Routes>
        <Route path="/" exact element={()=><Home user={user}/>}/>
        <Route path="/home" exact element={()=><Home user={user}/>}/>
        <Route path="/login" element={<Login/>}/>
        <Route path="/register" element={<Register/>}/>
      </Routes> 
      


    </div>
  )
}

export default App
