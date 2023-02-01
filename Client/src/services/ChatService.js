import axios from "axios";
import { useState,useEffect } from "react";
import Cookies from 'js-cookie';
const API_URL = process.env.IDENTITY_API;
const REGIST = process.env.REGISTRATION;
const LOGIN = process.env.LOGIN;
const USER_REGEX = process.env.USER_REGEX;
const PWD_REGEX = process.env.PWD_REGEX;

class ChatService {
  
    async GetChatter(token){ // DEBUG OUTSIDE

      const response = fetch(`http://localhost:7112/api/Chatter/${token}`,{
            method : "GET",
            headers : {'Content-Type':"application/json", "Authorization": "bearer "+ sessionStorage.getItem('token')},
            credentials : "include",
            
          })
          return response
    }


}
export default ChatService
