import React from 'react'
import Chat from '../../ContactsScreen/SideBar/Chat'
import SideBar from '../../ContactsScreen/SideBar/SideBar'
import "../Home/Home.css"

const Home = () => {
  return (
    <div className='home'>
        <div className='container'>
            <SideBar />
            <Chat/>
        </div>
    </div>
  )
}
export default Home

