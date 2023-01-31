import axios from 'axios'
import { useState } from 'react'
import { Container } from 'react-bootstrap'
import AddAvatar from '../../assets/Icons/AddAvatar.png'
import '../Register/Register.css'
import IdentityService from '../../services/IdentityService'
import { useNavigate } from 'react-router-dom'

const Register = () => {
  const service = new IdentityService()
  // States for registration
  const [username, setName] = useState('')
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [submitted, setSubmitted] = useState(false)
  const [error, setError] = useState("")
  const imgUrl = ''

  // States for checking the errors


  const navigate = useNavigate()

  const submit = async e => {
    const newUser = {
      username,
      email,
      password,
      imgUrl
    }
    e.preventDefault()

    const response = await service.Register(newUser)
    const content = await response.json()
    if(content.isSucceed){
      setSubmitted(true)
      
    }else{
      setError(content.message);
    }
    console.log(content)

    if(submitted){
      navigate('/login')
    }

  }

  // Handling the name change

  // Handling the Image change *still in procces*
  // const handleImage = (e) => {
  //   if (e.target.files && e.target.files[0]) {
  //     let img = e.target.files[0];
  //     setImage({ image: URL.createObjectURL(img) });
  //   }
  // };
  // Handling the form submission
  const handleSubmit = e => {
    // e.preventDefault();
    // if (username === "" || email === "" || password === "" ) {
    //   setError(true);
    // } else {
    //   setSubmitted(true);
    //   setError(false);
    //   const response =  axios
    //     .post("http://localhost:5032/api/register",
    //     JSON.stringify({username,email,password}),
    //       {
    //         headers:{'Content-Type':"application/json"},
    //         withCredentials:true
    //       }
    //     );
    //     console.log(response.data);
    // }
  }

  // Showing error message if error is true
  const errorMessage = () => {
    return (
      <div
        className='error'
        style={{
          display: error ? '' : 'none'
        }}
      >
        <h1>Please enter all the fields</h1>
      </div>
    )
  }
  const FormHeader = props => <h2 id='headerTitle'>Registration</h2>

  return (
    <Container>
      <div id='registerform'>
        <FormHeader />
        {/* Calling to the methods */}
        {errorMessage()}
        <form onSubmit={submit}>
          <div className='row'>
            <label>Name</label>
            <input
              type='text'
              description='Username'
              title=''
              placeholder='Enter your Name'
              onChange={e => setName(e.target.value)}
              autoComplete='off'
              required
              className='border-info'
              value={username}
            />
          </div>
          <div className='row'>
            <label>Email</label>
            <input
              type='email'
              title=''
              placeholder='Enter your Email'
              onChange={e => setEmail(e.target.value)}
              className='input'
              value={email}
            />
          </div>
          <div className='row'>
            <label>Password</label>
            <input
              title=''
              placeholder='Enter your Password'
              onChange={e => setPassword(e.target.value)}
              className='input'
              value={password}
              type='password'
            />
          </div>
          {/* <div className="row">
          <label>Image</label>
          <input
            title=""
            placeholder="Upload an Image"
           // onChange={(e) => handleImage(e)}
            className="input"
            
            type="file"
            id="file"
            style={{ display: "none" }}
          />
          <div id="imgFile">
            <label htmlFor="file">
              <img src={AddAvatar} alt="" />
              <span>Add an avatar</span>
            </label>
          </div>
        </div> */}
          <div className='row'>
            <button id='submitBtn' type='submit'>
              Sign Up
            </button>
          </div>
        </form>
      </div>
    </Container>
  )
}
export default Register
