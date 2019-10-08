import React, {Component} from 'react';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import Home from './Home';
import Gallery from './Gallery';
import Contact from './Contact';
import About from './About';
import CMS from './CMS';

export default class Menu extends Component {
    constructor(props) {
        super(props);

        this.state = {contactStyle : {backgroundColor:'#333'}, galleryStyle : {backgroundColor:'#333'}, aboutStyle : {backgroundColor:'#333'}, homeStyle : {backgroundColor:'black'}}
    }

    render() {
        const hoverStyle = {backgroundColor:'#336699'};
        const noHoverStyle = {backgroundColor:'#333'};
      
        const toggleHover = (style, status) => {        
            if (status) {
                this.setState({[style]: hoverStyle})
            }
            else {
                this.setState({[style]: noHoverStyle})
            }
        }

        return (
            <Router>
                <div>
                    <div id= "menu">
                        <ul>
                            <li id="contact" onMouseEnter={() => toggleHover("contactStyle", true)} onMouseLeave={() => toggleHover("contactStyle", false)} style={this.state.contactStyle}><Link to='/Contact'>Contact</Link></li>
                            <li id="gallery" onMouseEnter={() => toggleHover("galleryStyle", true)} onMouseLeave={() => toggleHover("galleryStyle", false)} style={this.state.galleryStyle}><Link to='Gallery'>Gallery</Link></li>
                            <li id="about" onMouseEnter={() => toggleHover("aboutStyle", true)} onMouseLeave={() => toggleHover("aboutStyle", false)} style={this.state.aboutStyle}><Link to='/About'>About</Link></li>
                            <li id="home" onMouseEnter={() => toggleHover("homeStyle", true)} onMouseLeave={() => toggleHover("homeStyle", false)} style={this.state.homeStyle}><Link to='/'>Home</Link></li>
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