import React, {Component} from 'react';
import { getContentItem } from './ContentManager';

export default class Contact extends Component {
    render() {
        const contactImage = getContentItem("contact-image", this.props.content);

        return (
            <div>
                <div id="leftContact">
                    <h1 id="contactHeader">Contact Information:</h1>
                    <div id="contactInfo">
                        <b>Email:</b>MEFineArts17@gmail.com<br />
                        <b>Facebook:</b> <a href="https://www.facebook.com/ArtME15/">https://www.facebook.com/ArtME15</a><br />
                        <b>LinkedIn:</b> <a href="https://www.linkedin.com/in/megan-eisenhauer-97a923137">https://www.linkedin.com/in/megan-eisenhauer</a><br />
                    </div>
                </div>
                <div id="rightContact">
                    <img id="contactArt" src={contactImage} />
                </div>
            </div>
        );
    }
}