import './App.css';
import {Home} from './components/Home';
import {Department} from './components/Department';
import {Employee} from './components/Employee';
import Button from 'react-bootstrap/Button';
import {Browser,BrowserRouter,NavLink,Route,Switch} from 'react-router-dom';
import {Navigation} from './components/Navigation';
function App() {
  return (
    <BrowserRouter>
    <div className="container">
      <h3 className="m-3 d-flex justify-content-center">React JS with Wep api Demo</h3>
      <h5 className="m-3 d-flex justify-content-center">Employee Management Portal</h5>
      <Navigation/>
     <Switch>
       <Route  path='/' component={Home} exact></Route>
       <Route  path='/Department' component={Department} ></Route>
       <Route  path='/Employee' component={Employee} ></Route>
     </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
