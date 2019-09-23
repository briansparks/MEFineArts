import React, {Component} from 'react';
import {getContentItem} from './ContentManager';

export default class Home extends Component { 
    render() {
        const title = getContentItem("home-title", this.props.content);
        const image = getContentItem("home-image", this.props.content);

        return(
            <div>
                <div id="image-body">
                    <h2 id="homeTitle">{title}</h2>
                    <img id="homePageImage" src={image} />
                </div>
            </div>
        )
    }
}