import React, { Component } from 'react';
//import logo from './logo.svg';
import './App.css';
import Footer from './Components/Footer'
import NavigationBar from './Components/NavigationBar'
//import $ from 'jquery'

class App extends Component {
  render() {
    return (
      <div className="App">
        <header>
          <NavigationBar/>
          <div id="loadingBox">Loading ...</div>
          <div id="infoBox">Info msg</div>
          <div id="errorBox">Error msg </div>
        </header>
        <div id="main">MAIN APP VIEW</div>
        <Footer/>
      </div>
    );
  }
}

export default App;
