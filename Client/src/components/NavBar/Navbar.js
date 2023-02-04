import Container from 'react-bootstrap/Container'
import Navbar from 'react-bootstrap/Navbar'
import Nav from 'react-bootstrap/Nav'
import { NavLink } from 'react-router-dom'
import { useState,useEffect } from 'react'
import Figure from 'react-bootstrap/Figure'
import IdentityService from '../../services/IdentityService'
import ChatService from '../../services/ChatService'

function NavBar (props) {
  // const [userSignedIn,SetUserSignedIn] = useState(false)
  const chatService = new ChatService();

  // if(props != null){
  //   SetUserSignedIn(true)
  // }
  const service = new IdentityService()
  const logout = () => {
    service.Logout()
    sessionStorage.clear('token')
    props.setUser(null)
    chatService.CloseConnection(props.connection);
  }

  return (
    <header>
      <Navbar bg='dark' variant='dark'>
        <Container>
          <Navbar.Brand to='/'>TalkBack</Navbar.Brand>
          <Nav className='justify-content-end'>
            <NavLink className='nav-link' to='/rules'>
              Rules
            </NavLink>
            <NavLink className='nav-link' to='/'>
              Home
            </NavLink>
            <NavLink className='nav-link' to='/contacts'>
              Contacts
            </NavLink>
            {props.isLogedIn ? (
              <NavLink className='nav-link' to='/login' onClick={logout}>
                Log out
              </NavLink>
            ) : (
              <div className='d-flex'>
                <NavLink className='nav-link' to='/login'>
                  Log In
                </NavLink>
                <NavLink className='nav-link' to='/register'>
                  Register
                </NavLink>
              </div>
            )}
          </Nav>
        </Container>
      </Navbar>
    </header>
  )
}

export default NavBar
