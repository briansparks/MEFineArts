import React, {Component} from 'react';
import {getContentItem} from './ContentManager';

export default class Home extends Component { 
    render() {
        const title = getContentItem("home-title", this.props.content);

        return(
            <div>
                <div id="homeBody">
                    <h2 id="homeTitle">{title}</h2>
                    <img id="homePageImage" src="../src/Content/Images/home.jpg" />
                </div>
            </div>
        )
    }
}