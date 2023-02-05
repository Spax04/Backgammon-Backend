import axios from 'axios'
import { useState, useEffect } from 'react'
import Cookies from 'js-cookie'
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr'
import { BehaviorSubject } from 'rxjs';
const API_URL = process.env.IDENTITY_API
const REGIST = process.env.REGISTRATION
const LOGIN = process.env.LOGIN
const USER_REGEX = process.env.USER_REGEX
const PWD_REGEX = process.env.PWD_REGEX

class ChatService {
  static connection;
  

  constructor () {
    if (ChatService.connection) {
      return ChatService.connection
    }
    ChatService.connection = this
    this.chattersArray = new BehaviorSubject([]);

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

  InitConnection () {
    this.connection = new HubConnectionBuilder()
      .withUrl(
        `http://localhost:7112/hub/chat/?token=${sessionStorage.getItem(
          'token'
        )}`,
        {
          // accessTokenFactory: () => {
          //   return sessionStorage.getItem('token')
          // }
          // transport: HttpTransportType.WebSockets | HttpTransportType.LongPolling
        }
      )
      //.configureLogging(LogLevel.Information)
      .build()
      this.connection.on("ChatterConnected",(c)=>{

        let reconected = this.chattersArray.find(cur => cur.id === c.id);
        if(reconected){
          reconected.isConnected = true;
          this.chattersArray.next(currentArray);
        }else{
          let chatter = {id:c.id,name:c.name,isConnected:true,lastSeen:undefined};
          this.chattersArray.next([...this.chattersArray.value,chatter]);
        }
      });
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

    return this.connection
  }

  async CloseConnection () {
    this.connection.stop().then(() => {
      console.log('Connection from signalR closed')
    })
  }


}
export const chatService = new ChatService()
