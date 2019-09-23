import React, {Component} from 'react';
import {getContentItem} from './ContentManager';

export default class About extends Component {
    render() {
        const aboutImage = getContentItem("about-image", this.props.content);
        const aboutBio = getContentItem("about-bio", this.props.content);

        return (
            <div>
                <div id="aboutHeaderParent">
                    <h1 id="aboutHeader">M.E. Fine Arts</h1>
                    <h2 id="aboutSubHeader">Megan Eisenhauer</h2>
                </div>
                <div id="bio" class="left">
                    {aboutBio}
                </div>
                <div class="right">
                    <img id="aboutImage" src={aboutImage} />
                </div>
            </div>
        );
    }
}