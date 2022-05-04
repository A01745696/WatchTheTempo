import { useState } from 'react';

const Home = function() {

  //Changes route into /login when called
  const login = async () => {
    window.location.href='/login'
  };

  //Changes route into /register when called
  const register = async () => {
    window.location.href='/register'
  };

  return (
      <div>
        <button onClick={login}>Login User</button><br/><br/>
        <button onClick={register}>Register User</button><br/><br/>
      </div>
    );
};

export default Home;
