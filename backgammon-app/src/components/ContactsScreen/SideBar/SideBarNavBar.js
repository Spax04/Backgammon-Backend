import React from 'react'
import '../SideBar.css'
import { useState,useEffect } from 'react'

const SideBarNavBar = (props) => {


  return (
    <div className='sideBarNavBar'>
        <span className='logo'>Chat</span>
        <div className='user'>
            <span>{props.username}</span>
        </div>
    </div>
  )
}
export default SideBarNavBar;

