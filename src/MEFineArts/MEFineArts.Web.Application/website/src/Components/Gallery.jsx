import React, {Component} from 'react';

export default class Gallery extends Component {
    constructor(props) {
        super(props);

        const images = this.props.content.filter(function(item) {
            return item.page == "Gallery" && item.contentType === "Image";
        });

        this.state = { "galleryImages": images }
    }

    render() {
        return (
            <div id="galleryParent">
                {this.state.galleryImages.map(function(image) {
                    return <img class="galleryArt" src={image.value} />
                })}
            </div>
        );
    }
}