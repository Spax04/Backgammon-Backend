import axios from 'axios'
import { useState, useEffect } from 'react'
import Cookies from 'js-cookie'
import {HubConnectionBuilder, LogLevel} from '@microsoft/signalr'
const API_URL = process.env.IDENTITY_API
const REGIST = process.env.REGISTRATION
const LOGIN = process.env.LOGIN
const USER_REGEX = process.env.USER_REGEX
const PWD_REGEX = process.env.PWD_REGEX



class ChatService {
 

  constructor(){
    this.connection = new HubConnectionBuilder()
    .withUrl(`http://localhost:7112/hub/chat/?token=${sessionStorage.getItem('token')}`, {
      // accessTokenFactory: () => {
      //   return sessionStorage.getItem('token')
      // }
      // transport: HttpTransportType.WebSockets | HttpTransportType.LongPolling
    })
    //.configureLogging(LogLevel.Information)
    .build()
  }
  



  async GetChatter (token) {
    const response = fetch(`http://localhost:7112/api/Chatter/${token}`, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
        Authorization: 'bearer ' + sessionStorage.getItem('token')
      },
      credentials: 'include'
    })
    return response
  }

  

   InitConnection() {
    

    //this.SetSignalRClientMethods()
      
    this.connection
      .start()
      .then(() => {
        console.log('Connection started!')
        
        //newConnection.invoke("OnConnectedAsync");
      })
      .catch(error => {
        console.log('Conection closed with error fromCLient')
        console.error(error.message)
      })

      return this.connection;
  }

  async CloseConnection(connection){
     this.connection.stop()
    .then(()=>{
      console.log("Connection from signalR closed")
    })
    
    

  }


  async SetSignalRClientMethods(){
    //this.connection.on("ChatterConnected",)
  }

}
export default ChatService
