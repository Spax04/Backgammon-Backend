import axios from "axios";
import { useState,useEffect } from "react";
import Cookies from 'js-cookie';
const API_URL = process.env.IDENTITY_API;
const REGIST = process.env.REGISTRATION;
const LOGIN = process.env.LOGIN;
const USER_REGEX = process.env.USER_REGEX;
const PWD_REGEX = process.env.PWD_REGEX;




class IdentityService {
  
  static user;
  

  constructor () {
    if (IdentityService.user) {
      return IdentityService.user
    }
    IdentityService.user = this
  }

    async Register(data){
      const response = fetch("http://localhost:5032/api/Auth/register",{
            method:"POST",
            headers:{'Content-Type':"application/json"},
            body:JSON.stringify(data)
          })
          return response
    }

    async Login(data){
      const response = fetch("http://localhost:5032/api/Auth/login",{
            method : "POST",
            headers : {'Content-Type':"application/json"},
            credentials : "include",
            body : JSON.stringify(data)
          })
          return response
    }

    async Logout(){
      const response = fetch("http://localhost:5032/api/Auth/logout",{
            method : "POST",
            headers : {'Content-Type':"application/json", "Authorization": "bearer "+ sessionStorage.getItem('token')},
            credentials : "include",
          })
          return response
    }

    async GetUser(token){ // DEBUG OUTSIDE

      const response = fetch(`http://localhost:5032/api/User/${token}`,{
            method : "GET",
            headers : {'Content-Type':"application/json", "Authorization": "bearer "+ sessionStorage.getItem('token')},
            credentials : "include",
            
          })
          return response
    }


}
export default IdentityService
