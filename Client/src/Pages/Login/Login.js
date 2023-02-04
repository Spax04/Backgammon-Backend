import { NavLink } from 'react-router-dom'
import { useState } from 'react'
import '../Login/Login.css'
import IdentityService from '../../services/IdentityService'
import { useNavigate } from 'react-router-dom'
import ChatService from '../../services/ChatService'
import Cookies from 'js-cookie'
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr'

const LoginForm = props => {
  const service = new IdentityService()
  const [username, setUsername] = useState('')
  const [password, setPassword] = useState('')
  const navigation = useNavigate()

  // const InitConnection = () => {
  //   const newConnection = new HubConnectionBuilder()
  //     .withUrl('http://localhost:7112/hub/chat/', {
  //       accessTokenFactory: () => {
  //         return sessionStorage.getItem('token')
  //       }
  //       // transport: HttpTransportType.WebSockets | HttpTransportType.LongPolling
  //     })
  //     //.configureLogging(LogLevel.Information)
  //     .build()

  //   //this.SetSignalRClientMethods()

  //   newConnection
  //     .start()
  //     .then(() => {
  //       console.log('Connection started!')
  //       setConnection(newConnection);
  //       //newConnection.invoke("OnConnectedAsync");
  //     })
  //     .catch(error => {
  //       console.log('Conection closed with error fromCLient')
  //       console.error(error.message)
  //     })
  // }

  const submit = async e => {
    const loginUser = {
      username,
      password
    }
    e.preventDefault()

    await service
      .Login(loginUser)
      .then(resp => {
        return resp.json()
      })
      .then(resp => {
        sessionStorage.setItem('token', resp.token)

        service
          .GetUser(resp.token)
          .then(resp => {
            return resp.json()
          })
          .then(resp => {
            props.setUser(resp)
          })

        const chatService = new ChatService()

        chatService
          .GetChatter(resp.token)
          .then(resp => {
            return resp.json()
          })
          .then(resp => {
            props.setChatter(resp)
            console.log(resp)
          })

        // chatService
        // .InitConnection();

        // .then(resp => {
        //               return resp.json()
        //             })
        //             .then(resp => {
        //               console.log(resp + " init From Login")
        //             })

        const newConnection = chatService.InitConnection()
        props.setConnection(newConnection)
        navigation('/')
      })
  }

  return (
    <form onSubmit={submit}>
      <div id='loginform'>
        <FormHeader title='Sign In' />
        <div className='row'>
          <label>Username</label>
          <input
            type='text'
            onChange={e => setUsername(e.target.value)}
            placeholder='Enter your Name'
          />
        </div>
        <div className='row'>
          <label>Password</label>
          <input
            type='password'
            onChange={e => setPassword(e.target.value)}
            placeholder='Enter your Password'
          />
          <button id='submitBtn' type='submit'>
            Sign in
          </button>
        </div>

        <Register />
        <OtherMethods />
      </div>
    </form>
  )
}

const FormHeader = props => <h2 id='headerTitle'>{props.title}</h2>

const Register = props => (
  <div className='alternativeLogin'>
    <div className='createAcc'>
      Dont have an account? <NavLink to='/register'> Create here</NavLink>
    </div>
  </div>
)

const OtherMethods = props => (
  <div id='alternativeLogin'>
    <div>Or sign in with:</div>
    <div id='iconGroup'>
      <img
        src='https://icons.iconarchive.com/icons/yootheme/social-bookmark/128/social-facebook-box-blue-icon.png'
        alt=''
        id='facebookIcon'
      />
      <img
        src='https://icons.iconarchive.com/icons/graphics-vibe/simple-rounded-social/128/twitter-icon.png'
        alt=''
        id='twitterIcon'
      />
      <img
        src='https://icons.iconarchive.com/icons/graphics-vibe/simple-rounded-social/128/google-icon.png'
        alt=''
        id='googleIcon'
      />
    </div>
  </div>
)

export default LoginForm
