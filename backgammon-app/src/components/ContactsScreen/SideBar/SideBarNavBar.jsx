import React from 'react'
import '../SideBar.css'

const SideBarNavBar = (props) => {
  return (
    <div className='sideBarNavBar'>
        <span className='logo'>Chat</span>
        <div className='user'>
            <span>{props.user.username}</span>
        </div>
    </div>
  )
}
export default SideBarNavBar;

