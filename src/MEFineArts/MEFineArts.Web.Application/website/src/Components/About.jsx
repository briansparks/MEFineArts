import React, {Component} from 'react';
import {getContentItem} from './ContentManager';

export default class About extends Component {
    render() {
        const aboutTitle = getContentItem("about-title", this.props.content);
        const aboutSubtitle = getContentItem("about-subtitle", this.props.content);
        const aboutImage = getContentItem("about-image", this.props.content);
        const aboutBio = getContentItem("about-bio", this.props.content);

        return (
            <div>
                <div id="aboutHeaderParent">
                    <h1 id="aboutHeader">{aboutTitle}</h1>
                    <h2 id="aboutSubHeader">{aboutSubtitle}</h2>
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