import Container from 'react-bootstrap/Container'
import Navbar from 'react-bootstrap/Navbar'
import Nav from 'react-bootstrap/Nav'
import { NavLink } from 'react-router-dom'
import { useState } from 'react'
import Figure from 'react-bootstrap/Figure'

function NavBar (props) {

  // const [userSignedIn,SetUserSignedIn] = useState(false)

  // if(props != null){
  //   SetUserSignedIn(true)
  // }


  return (
    <header>
      <Navbar bg='dark' variant='dark'>
        <Container>
          <Navbar.Brand to='/'>TalkBack</Navbar.Brand>
          <div className='d-flex'>
            <img
              className='profileImg'
              src='https://cdn.icon-icons.com/icons2/1378/PNG/512/avatardefault_92824.png'
              alt='user'
            />
            
          </div>
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
            <NavLink className='nav-link' to='/login'>Log In</NavLink>
            <NavLink className='nav-link' to='/register'>Register</NavLink>
          </Nav>
        </Container>
      </Navbar>
    </header>
  )
}

export default NavBar
