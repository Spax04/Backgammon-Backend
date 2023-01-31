import React from 'react'
import { useState, useEffect } from 'react'
import { Container } from 'react-bootstrap'
import Chat from '../../components/ContactsScreen/Chat/Chat'
import SideBar from '../../components/ContactsScreen/SideBar/SideBar'
import '../Home/Home.css'
import { useNavigate } from 'react-router-dom'
import IdentityService from '../../services/IdentityService'

function Home (props) {
  const service = new IdentityService()

  const navigate = useNavigate()
  const [innetUser, setInnerUser] = useState(null)

  useEffect(() => {
    let token = sessionStorage.getItem('token')
    if (token === '' || token === null) {
      navigate('/login')
    }else{
      setInnerUser(props.user)
    }
  }, [])

  const testToChat = ()=>{
      const response = fetch(`http://localhost:7112/api/Chat/`,{
            method : "GET",
            headers : {'Content-Type':"application/json", "Authorization": "bearer "+ sessionStorage.getItem('token')},
            credentials : "include",
            
          }).then((resp)=>{
            return resp.json()
          }).then((resp)=>{
            console.log(resp)
          })
          
    }
  

  return (
    <div className='home'>
      {props.user ? (
        
        <Container>
          <button onClick={testToChat}>Send Test</button>
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
