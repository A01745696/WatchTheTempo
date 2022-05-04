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
      fetch("http://watchthetempo.games:5000/post", {
        method: "POST",
        headers: {
          'Accept': 'application/json',
          "Content-Type": "application/json"//Header to specify JSON format
        },
        body: JSON.stringify({
        usuario: auth.currentUser.email,//get user email from currentUser
        password: auth.currentUser.uid,//get UID from currentUser
        fecha: 'test'
      })
      });
  };

  return (
    <div>
      <input placeholder="Ingresa tu e-mail" onChange={(event) => {
        setEmail(event.target.value);
      }}></input><br/><br/>
      <input type="password" placeholder="Ingresa una password" onChange={(event) => {
        setPssw(event.target.value);
      }}></input><br/><br/>
      <button onClick={register}>Register User</button>
    </div>
  );
};

export default Register;
