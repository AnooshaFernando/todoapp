import React, { Component } from 'react';
import {
    Route,
    NavLink,
    HashRouter
} from "react-router-dom";
import { Home } from './components/Home';
import { CompletedTask } from './components/CompletedTask';
import { AddTask } from './components/AddTask';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
      return (
          <HashRouter>
              <div>
                  <h1>Todo App</h1>
                  <ul className="header">
                      <li><NavLink to="/">Home</NavLink></li>
                      <li><NavLink to="/AddTask">Add Task</NavLink></li>
                      <li><NavLink to="/CompletedTask">Completed Tasks</NavLink></li>
                  </ul>
                  <div className="content">
                      <Route exact path="/" component={Home} />
                      <Route path="/AddTask" component={AddTask} />
                      <Route path="/CompletedTask" component={CompletedTask} />
                  </div>
              </div>
          </HashRouter>
    );
  }
}
