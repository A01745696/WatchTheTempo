import { useState, useEffect } from 'react';
import { onAuthStateChanged, signOut } from 'firebase/auth';
import { auth } from './firebase-config';
import DataTable from 'react-data-table-component';

const Dashboard = function() {

  //Hooks to set current user and query data
  const [user, setUser] = useState({});
  const [query, setQuery] = useState([]);

  useEffect(() => {
    fetchData();
  });

  //Check if user changed and update it
  onAuthStateChanged(auth, (currentUser) => {
      if(currentUser) {
        setUser(currentUser);
      }
  });

  //Logout function
  const logout = async () => {
    await signOut(auth);
    window.location.href='/login';
  };

  //fetch function to retrieve data from API on port 5000
  const fetchData = async () => {
    fetch("http://watchthetempo.games:5000/test/*/jugadores").then((response) => response.text()).then((data) => {
    //Once we get the data split it so we can process it
    var rawData = data.slice(1, -1);
    rawData = rawData.split("},");

    //Stores the data on a list
    var prodData = [];

    //Map the data and reassemble it into proper format
    rawData.map((data) => {
      if(data[data.length-1] === "}") {
        prodData.push(JSON.parse(data));
      }
      else {
        prodData.push(JSON.parse(data+"}"));
      }
    });
    //Set final data on hook
    setQuery(prodData);
  });
  };

  //Defines the format for the table depending on data
  const columns = [
      {
          name: 'Usuario',
          selector: 'usuario'
      },
      {
          name: 'Password',
          selector: 'password'
      },
      {
          name: 'Fecha',
          selector: 'fecha'
      },
  ];

  return (
      <div>
          <span>Login successful</span><br/><br/>
          <span>Email: {user?.email}</span><br/><br/>
          <span>UID: {user?.uid}</span><br/><br/>
          <button onClick={logout}>Logout User</button>
          <div>
            {query !== undefined &&
              <DataTable columns={columns} data={query}/>
            }
          </div>
      </div>
  );
};

export default Dashboard;
