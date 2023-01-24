import React from 'react'
import { Container } from 'react-bootstrap'
import Chat from '../../ContactsScreen/Chat/Chat'
import SideBar from '../../ContactsScreen/SideBar/SideBar'
import "../Home/Home.css"

const Home = () => {
  return (
    <div className='home'>
        <Container>
            <SideBar />
            <Chat/>
        </Container>
    </div>
  )
}
export default Home

