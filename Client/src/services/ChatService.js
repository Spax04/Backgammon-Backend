
import { useState, useEffect } from 'react'

import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr'
import { BehaviorSubject } from 'rxjs';


class ChatService {
  static connection;
  

  constructor () {
    if (ChatService.connection) {
      return ChatService.connection
    }else{
      ChatService.connection = localStorage.getItem("CHAT_CONNECTION")
    }
    ChatService.connection = this

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
        `http://localhost:7112/hub/chat/?token=${sessionStorage.getItem('token')}`
      )
      .build()
      
    //this.SetSignalRClientMethods()
    

    this.connection
      .start()
      .then(() => {
        console.log('Connection started!')
      })
      .catch(error => {
        console.log('Conection closed with error fromCLient')
        console.error(error.message)
      })

      localStorage.setItem("CHAT_CONNECTION",this.connection)

    return this.connection
  }

  async CloseConnection () {
    this.connection
    .stop()
    .then(() => {
      console.log('Connection from signalR closed')
    })
  }


}
export default ChatService
