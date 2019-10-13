import React, {Component} from 'react';
import Lightbox from 'react-image-lightbox';
import 'react-image-lightbox/style.css';
 
export default class Gallery extends Component {
    constructor(props) {
        super(props);

        this.state = { "fullScreen" : false, "expandedImageSource" : "" }
    }
      
    buildTableData = (image) => {
        if (image) {
            return (
                <td><img class="galleryArt" src={image.value} onClick={() => this.setState({ fullScreen: true, expandedImageSource : image.value })}/></td>
            )
        }
        else {
            return null;
        }
    }

    buildTable(imageRows, buildTable) {
        return imageRows.map(function(imageRow) {
            return (
                <tr>
                    {buildTable(imageRow[0])}
                    {buildTable(imageRow[1])}
                    {buildTable(imageRow[2])}
                </tr>
            )
        })
    }

    render() {
        const images = this.props.content.filter(function(item) {
            return item.page == "Gallery" && item.contentType === "Image";
        });

        let imageRows = [];
        for (var i = 0; i <= images.length; i+=3) {
            let imageRow = [];
            imageRow.push(images[i]);
            imageRow.push(images[i+1]);
            imageRow.push(images[i+2]);
            imageRows.push(imageRow);
        }

        let tableContent = this.buildTable(imageRows, this.buildTableData.bind(this));

        const { fullScreen, expandedImageSource } = this.state;

        return (
            <div id="galleryParent">
                <table id="galleryTable">
                    <tbody>
                        {tableContent}
                    </tbody>
                </table>
                {fullScreen && (
                    <Lightbox
                        mainSrc={expandedImageSource}
                        onCloseRequest={() => this.setState({ fullScreen: false })}
                    />
                )}
            </div>
        );
    }
}