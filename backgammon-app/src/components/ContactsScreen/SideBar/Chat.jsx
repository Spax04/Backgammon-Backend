import React from 'react'
import BackIcon from '../../../assets/Icons/BackgammonIcon.png'
import ChatIcon from '../../../assets/Icons/ChatIcon.png'
import Messages from './Messages'
import Input from './Input'
import './SideBar.css'

const Chat = () => {
  return (
    <div className='chat'>
      <div className='chatInfo'>
        <span>Alex</span>
        <div className='chatIcons'>
          <img src={BackIcon} alt="Backgammon" />
          <img src={ChatIcon} alt="Chat" />
        </div>
      </div>
      <Messages />
      <Input />
    </div>
  )
}

export default Chat;



