import { NavLink } from 'react-router-dom'
import { useState } from 'react'
import '../Login/Login.css'
import IdentityService from '../../services/IdentityService'
import { useNavigate } from 'react-router-dom'
import ChatService from '../../services/ChatService'
import Cookies from 'js-cookie';

const LoginForm = props => {
  const service = new IdentityService()
  const chatService = new ChatService();
  const [username, setUsername] = useState('')
  const [password, setPassword] = useState('')
  const navigation = useNavigate()

  const getCookie = name => {
    const value = `; ${document.cookie}`
    const parts = value.split(`; ${name}=`)
    if (parts.length === 2) return parts.pop().split(';').shift()
  }

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
          });


          chatService
            .GetChatter(resp.token)
            .then(resp => {
              return resp.json()
            })
            .then(resp => {
              props.setChatter(resp)
            })
            
          
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
