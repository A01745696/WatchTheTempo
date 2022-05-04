import { useState } from 'react';
import { createUserWithEmailAndPassword, onAuthStateChanged } from 'firebase/auth';
import { auth } from './firebase-config';

const Register = function() {

  //Hooks to set email, password and user
  const [email, setEmail] = useState('');
  const [pssw, setPssw] = useState('');
  const [user, setUser] = useState({});

  //Checks if user is authenticated and changes route
  if(auth.currentUser) {
    window.location.href='/dashboard'
  }

  //Check if user changed and update it
  onAuthStateChanged(auth, (currentUser) => {
      if(currentUser) {
        setUser(currentUser);
      }
  });

  //Register user when entering email and password
  async function register() {
    try {
      await createUserWithEmailAndPassword(auth, email, pssw).then(() => {logData();});
    } catch(error){};
  };

  //fetch function to post email and password from user
  const logData = async () => {
      //fetch request from local API on port 5000
      //fetch("http://127.0.0.1:5000/post", {
      fetch("https://64.227.109.201:8443/post", {
        method: "POST",
        headers: {
          'Accept': 'application/json',
          "Content-Type": "application/json"//Header to specify JSON format
        },
        body: JSON.stringify({
	username: auth.currentUser.email,//get user email from currentUser
        password: auth.currentUser.uid//get UID from currentUser
      	})
      });
  };

  return (
    <div>
      <input placeholder="Enter e-mail" onChange={(event) => {
        setEmail(event.target.value);
      }}></input><br/><br/>
      <input type="password" placeholder="Enter password" onChange={(event) => {
        setPssw(event.target.value);
      }}></input><br/><br/>
      <button onClick={register}>Register User</button>
    </div>
  );
};

export default Register;
