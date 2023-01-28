import React from 'react'
import { useState,useEffect } from 'react'
import { Container } from 'react-bootstrap'
import Chat from '../../components/ContactsScreen/Chat/Chat'
import SideBar from '../../components/ContactsScreen/SideBar/SideBar'
import "../Home/Home.css"
import { useNavigate } from 'react-router-dom'
import IdentityService from '../../services/IdentityService'

const Home = (props) => {

  // const service = new IdentityService();

   const navigate = useNavigate();
   const [user,setUser] = useState(null);

  useEffect(()=>{

    let userId = sessionStorage.getItem('id');
     if(userId ==="" || userId === null ){
       navigate("/login");
     }

  //   service.GetUser(userId)
  //   .then((resp) =>  {
  //     return resp.json()
  //   })
  //   .then((resp)=>{
  //     console.log(resp)
  //     setUser(resp)
  //     console.log(user)
  //   })


  
   },[])

  return (
    <div className='home'>
    
        <Container>
            <SideBar user={props.user}/>
            <Chat />
        </Container>
    </div>
  )
}
export default Home

