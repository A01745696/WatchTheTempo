import Home from './pages/home'

import Login from './pages/login'

import Register from './pages/register';

import Dashboard from './pages/dashboard';

import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import './styles.css'

function App() {
  return (
    <Router>
      <div className="wrapper">
        <Switch>
          <Route exact path="/">
            <Home />
          </Route>
          <Route exact path="/login">
            <Login />
          </Route>
          <Route exact path="/register">
            <Register />
          </Route>
          <Route exact path="/dashboard">
            <Dashboard />
          </Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
