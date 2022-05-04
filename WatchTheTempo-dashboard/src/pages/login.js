import { useState } from 'react';
import { onAuthStateChanged, signInWithEmailAndPassword } from 'firebase/auth';
import { auth } from './firebase-config';

const Login = function() {

  //Checks if user is authenticated and changes route
  if(auth.currentUser) {
    window.location.href='/dashboard'
  }

  //Hooks to set email, password and user
  const [email, setEmail] = useState('');
  const [pssw, setPssw] = useState('');
  const [user, setUser] = useState({});

  //Check if user changed and update it
  onAuthStateChanged(auth, (currentUser) => {
      if(currentUser) {
        setUser(currentUser);
      }
  });

  //Login function
  const login = async () => {
    try {
      signInWithEmailAndPassword(auth, email, pssw);
    } catch(error){};
  };

  return (
    <div>
      <input placeholder="Ingresa tu e-mail" onChange={(event) => {
        setEmail(event.target.value);
      }}></input><br/><br/>
      <input type="password" placeholder="Ingresa una password" onChange={(event) => {
        setPssw(event.target.value);
      }}></input><br/><br/>
      <button onClick={login}>Login User</button>
    </div>
  );
};

export default Login;
