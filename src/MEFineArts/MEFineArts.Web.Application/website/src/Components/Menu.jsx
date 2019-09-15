import React, {Component} from 'react';

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
            <div id= "menu">
                <ul>
                    <li id="contact" onMouseEnter={() => toggleHover("contactStyle", true)} onMouseLeave={() => toggleHover("contactStyle", false)}><a style={this.state.contactStyle}>Contact</a></li>
                    <li id="gallery" onMouseEnter={() => toggleHover("galleryStyle", true)} onMouseLeave={() => toggleHover("galleryStyle", false)}><a style={this.state.galleryStyle}>Gallery</a></li>
                    <li id="about" onMouseEnter={() => toggleHover("aboutStyle", true)} onMouseLeave={() => toggleHover("aboutStyle", false)}><a style={this.state.aboutStyle}>About</a></li>
                    <li id="home" onMouseEnter={() => toggleHover("homeStyle", true)} onMouseLeave={() => toggleHover("homeStyle", false)}><a style={this.state.homeStyle}>Home</a></li>
                </ul>
            </div>
        );
    }
}