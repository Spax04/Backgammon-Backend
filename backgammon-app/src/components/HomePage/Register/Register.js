import axios from "axios";
import { useState } from "react";
import { Container } from "react-bootstrap"
import AddAvatar from "../../../assets/Icons/AddAvatar.png"
import "../Register/Register.css"


const Register = () => {
  // States for registration
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [image, setImage] = useState(null);

  // States for checking the errors
  const [submitted, setSubmitted] = useState(false);
  const [error, setError] = useState(false);

  // Handling the name change
  const handleName = (value) => {
    setName(value);
    setSubmitted(false);
  };

  // Handling the email change
  const handleEmail = (value) => {
    setEmail(value);
    setSubmitted(false);
  };

  // Handling the password change
  const handlePassword = (value) => {
    setPassword(value);
    setSubmitted(false);
  };
  // Handling the Image change *still in procces*
  const handleImage = (e) => {
    if (e.target.files && e.target.files[0]) {
      let img = e.target.files[0];
      setImage({ image: URL.createObjectURL(img) });
    }
  };
  // Handling the form submission
  const handleSubmit = (e) => {
    e.preventDefault();
    if (name === "" || email === "" || password === "" || image === null) {
      setError(true);
    } else {
      setSubmitted(true);
      setError(false);
      const url = "http://localhost:5032/index.html";
      const data = {
        NickName: name,
        Email: email,
        Password: password,
        isConnected: true,
        PhotoFileStream: image,
      };
      axios
        .post(url, data)
        .then((result) => {
          alert(result.data);
        })
        .catch((error) => {
          alert(error);
        });
    }
  };

  // Showing success message
  const successMessage = () => {
    return (
      <div
        className="success"
        style={{
          display: submitted ? "" : "none",
        }}
      >
        <h1>User {name} successfully registered!!</h1>
      </div>
    );
  };

  // Showing error message if error is true
  const errorMessage = () => {
    return (
      <div
        className="error"
        style={{
          display: error ? "" : "none",
        }}
      >
        <h1>Please enter all the fields</h1>
      </div>
    );
  };
  const FormHeader = (props) => <h2 id="headerTitle">Registration</h2>;
  
  return (
    <Container >
      <div id="registerform">
      <FormHeader />
      {/* Calling to the methods */}
        {errorMessage()}
      <form>
        <div className="row">
          <label>Name</label>
          <input
            type="text"
            description="Username"
            title=""
            placeholder="Enter your Name"
            onChange={(e) => handleName(e.target.value)}
            className="border-info"
            value={name}
          />
        </div>
        <div className="row">
          <label>Email</label>
          <input
            type="email"
            title=""
            placeholder="Enter your Email"
            onChange={(e) => handleEmail(e.target.value)}
            className="input"
            value={email}
          />
        </div>
        <div className="row">
          <label>Password</label>
          <input
            title=""
            placeholder="Enter your Password"
            onChange={(e) => handlePassword(e.target.value)}
            className="input"
            value={password}
            type="password"
          />
        </div>
        <div className="row">
          <label>Image</label>
          <input
            title=""
            placeholder="Upload an Image"
            onChange={(e) => handleImage(e)}
            className="input"
            value={image}
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
        </div>
        <div className="row">
          <input id="submitBtn" onClick={() => handleSubmit()} type="submit" />
        </div>
      </form>
      </div>
    </Container>
  );
};
export default Register;
