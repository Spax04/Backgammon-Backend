import { render } from "@testing-library/react";
import React from "react";
import Chats from "./Chats";
import { useState } from "react";
import Search from "./Search";
import SideBarNavBar from "./SideBarNavBar";

const SideBar = (props) => {

  const [newRender,setRender] = useState(false);
  if(props.user != null){
    setRender(true)
  }


  return <div>
    {newRender ? <div className="sidebar">
      
      <SideBarNavBar user={props.user}/>
      <Search />
      <Chats />
  
    </div> : <div></div> }
  </div>

    

  
};

export default SideBar;
