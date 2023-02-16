import React from 'react'
import { useState, useEffect } from 'react'
import { Container } from 'react-bootstrap'
import Chat from '../../components/ContactsScreen/Chat/Chat'
import SideBar from '../../components/ContactsScreen/SideBar/SideBar'
import '../Home/Home.css'
import { useNavigate } from 'react-router-dom'
import IdentityService from '../../services/IdentityService'
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr'

function Home (props) {
  const service = new IdentityService()

  const navigate = useNavigate()
  const [connection,setConnection] = useState();
  const [users,setUsers] = useState([])
  

  useEffect(() => {
    let token = sessionStorage.getItem('token')
    if (token === '' || token === null) {
      navigate('/login')
    }else{
     
    //this.SetSignalRClientMethods()

    
    }
  }, [])

  return (
    <div className='home'>
      {props.user ? (
        
        <Container>
         
          <SideBar user={props.user} />
          <Chat />
        </Container>
      ) : (
        <div></div>
      )}
    </div>
  )
}
export default Home
