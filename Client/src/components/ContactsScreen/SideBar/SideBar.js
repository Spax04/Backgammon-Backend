import { render } from "@testing-library/react";
import React from "react";
import Chats from "./Chats";
import { useState,useEffect } from "react";
import Search from "./Search";
import SideBarNavBar from "./SideBarNavBar";

const SideBar = (props) => {



  useEffect(()=>{
    
  },[])

  return <div>
     <div className="sidebar">
      <SideBarNavBar username={props.user.username}/>
      <Search />
      <Chats chatters={props.chatters}/>
    </div>
  </div>

};

export default SideBar;
