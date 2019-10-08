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
        let imageRows = [];
        for (var i = 0; i <= this.state.galleryImages.length; i+=3) {
            let imageRow = [];
            imageRow.push(this.state.galleryImages[i]);
            imageRow.push(this.state.galleryImages[i+1]);
            imageRow.push(this.state.galleryImages[i+2]);
            imageRows.push(imageRow);
        }

        let tableContent = BuildTable(imageRows);

        return (
            <div id="galleryParent">
                <table id="galleryTable">
                    <tbody>
                        {tableContent}
                    </tbody>
                </table>
            </div>
        );
    }
}

export function BuildTable(imageRows) {
    return imageRows.map(function(imageRow) {
        return (
            <tr>
                {BuildTableData(imageRow[0])}
                {BuildTableData(imageRow[1])}
                {BuildTableData(imageRow[2])}
            </tr>
        )
    })
}

export function BuildTableData(image) {
    if (image) {
        return (
            <td><img class="galleryArt" src={image.value}/></td>
        )
    }
    else {
        return null;
    }
}