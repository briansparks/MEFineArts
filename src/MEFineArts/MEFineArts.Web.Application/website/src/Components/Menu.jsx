import React, {Component} from 'react';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import { NavLink } from 'react-router-dom';
import Home from './Home';
import Gallery from './Gallery';
import Contact from './Contact';
import About from './About';
import CMS from './CMS';

export default class Menu extends Component {
    checkActive = () => {
        if (window.location.pathname === '/') {
            return true;
        }
        return false;
    }

    render() {
        return (
            <Router>
                <div>
                    <div id= "menu">
                        <ul>
                            <li id="contact"><NavLink  to='/Contact' activeClassName="activeMenu">Contact</NavLink ></li>
                            <li id="gallery"><NavLink  to='/Gallery' activeClassName="activeMenu">Gallery</NavLink ></li>
                            <li id="about"><NavLink  to='/About' activeClassName="activeMenu">About</NavLink ></li>
                            <li id="home"><NavLink  to='/' activeClassName="activeMenu" isActive={this.checkActive}>Home</NavLink ></li>
                        </ul>
                    </div>
                    <Route exact path="/" render={(props) => <Home {...props} content={this.props.content}/>}/>
                    <Route path="/About" render={(props) => <About {...props} content={this.props.content}/>}/>
                    <Route path="/Gallery" render={(props) => <Gallery {...props} content={this.props.content}/>}/>
                    <Route path="/Contact" render={(props) => <Contact {...props} content={this.props.content}/>}/>
                    <Route path="/Admin" render={(props) => <CMS {...props} content={this.props.content}/>}/>
                </div>
            </Router>
        );
    }
}