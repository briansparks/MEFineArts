import React, {Component} from 'react';
import { getContentItem } from './ContentManager';

export default class Contact extends Component {
    render() {
        const contactTitle = getContentItem("contact-title", this.props.content);
        const email = getContentItem("contact-email", this.props.content);
        const facebook = getContentItem("contact-facebook", this.props.content);
        const linkedin = getContentItem("contact-linkedin", this.props.content);
        const contactImage = getContentItem("contact-image", this.props.content);

        return (
            <div>
                <div id="leftContact">
                    <h1 id="contactHeader">{contactTitle}</h1>
                    <div id="contactInfo">
                        <b>Email:</b> {email}<br />
                        <b>Facebook:</b> <a href={facebook}>{facebook}</a><br />
                        <b>LinkedIn:</b> <a href={linkedin}>{linkedin}</a><br />
                    </div>
                </div>
                <div id="rightContact">
                    <img id="contactArt" src={contactImage} />
                </div>
            </div>
        );
    }
}