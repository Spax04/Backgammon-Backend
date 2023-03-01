import React from "react";
import { useState, useEffect } from 'react'
const Chats = (props) => {

  const [chatterList, setList] = useState([])

  useEffect(()=>{
    setList(props.chatters);
    if(!chatterList){
      setList(props.chatters);
    }


  },[props.chatters])
  return <div>
    {
    chatterList ? 
      <div className="chats">
        {chatterList.map(chatter =>
           <div key={chatter.id} className="userChat">
           <div className="userChatInfo">
             <span>{chatter.name}</span>
           </div>
       </div> )}
       
      </div> 
    : 
    <div className="chats" ></div>
  }
  </div>
  
};

export default Chats;
