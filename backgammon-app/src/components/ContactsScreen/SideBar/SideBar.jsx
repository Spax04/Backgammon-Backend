import React from "react";
import Chats from "./Chats";

import Search from "./Search";
import SideBarNavBar from "./SideBarNavBar";

const SideBar = () => {
  return (

    <div className="sidebar">
      
        <SideBarNavBar />
        <Search />
        <Chats />
      
    </div>

  );
};

export default SideBar;
