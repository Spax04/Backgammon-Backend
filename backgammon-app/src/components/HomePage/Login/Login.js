import { NavLink } from "react-router-dom";
import "../Login/Login.css";

const LoginForm = () => {
  return (
    <div id="loginform">
      <FormHeader title="Sign In" />
      <Form />
      <Register />
      <OtherMethods />
    </div>
  );
};

const FormHeader = (props) => <h2 id="headerTitle">{props.title}</h2>;

const Form = (props) => (
  <div>
    <FormInput
      description="Username"
      placeholder="Enter your Name"
      type="text"
    />
    <FormInput
      description="Password"
      placeholder="Enter your Password"
      type="password"
    />
    <FormButton title="Log in" />
  </div>
);

const FormButton = (props) => (
  <div id="button" className="row">
    <button>{props.title}</button>
  </div>
);

const FormInput = (props) => (
  <div className="row">
    <label>{props.description}</label>
    <input type={props.type} placeholder={props.placeholder} />
  </div>
);
const Register = (props) => (
  <div className="alternativeLogin">
    <div className="createAcc">
        Dont have an account? <NavLink to="/Register"> Create here</NavLink>
    </div>
  </div>
);

const OtherMethods = (props) => (
  <div id="alternativeLogin">
    <div>Or sign in with:</div>
    <div id="iconGroup">
      <img
        src="https://icons.iconarchive.com/icons/yootheme/social-bookmark/128/social-facebook-box-blue-icon.png"
        alt=""
        id="facebookIcon"
      />
      <img
        src="https://icons.iconarchive.com/icons/graphics-vibe/simple-rounded-social/128/twitter-icon.png"
        alt=""
        id="twitterIcon"
      />
      <img
        src="https://icons.iconarchive.com/icons/graphics-vibe/simple-rounded-social/128/google-icon.png"
        alt=""
        id="googleIcon"
      />
    </div>
  </div>
);

export default LoginForm;
