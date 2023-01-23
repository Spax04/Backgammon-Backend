import React from 'react'
import './SideBar.css'

const SideBarNavBar = () => {
  return (
    <div className='sideBarNavBar'>
        <span className='logo'>TalkBack Chat</span>
        <div className='user'>
            <img src='https://i.pinimg.com/736x/52/e4/ff/52e4ff859d7159aaeb3a71e65fea34f2.jpg' alt='' />
            <span>Daniel</span>
            <button>Logout</button>
        </div>
    </div>
  )
}
export default SideBarNavBar;

