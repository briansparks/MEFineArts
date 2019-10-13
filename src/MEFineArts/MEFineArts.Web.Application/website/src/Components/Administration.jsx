import React, {Component} from 'react';
import { Button, FormGroup, FormControl } from "react-bootstrap";
import ImageUploader from 'react-images-upload';
import axios from 'axios';

export default class Administration extends Component {
    constructor(props) {
        super(props);

        this.state = { accessToken: "", fullForm: this.props.content, imageUploadStatus: "" }
    }

    onFormSubmit = event => {
        event.preventDefault();

        fetch(`https://localhost:5001/api/content`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'X-Authorization-Access-Token': this.props.accessToken
            },
            body: JSON.stringify(this.props.content)
        })
        .catch(console.log);  
    }

    handleChange = event => {
        let newForm = this.state.fullForm;
        newForm.map(function(item) {
            if (item.contentId === event.target.id) {
                item.value = event.target.value;
            }
        })

        this.setState({
            fullForm: newForm
        });
      }

    uploadGalleryImage(images) {
        const formData = new FormData();
        formData.append("file", images[images.length-1]);

        const config = {
            headers: {
            'content-type': 'multipart/form-data',
            'X-Authorization-Access-Token': this.props.accessToken
            }
          }

        axios.put(`https://localhost:5001/api/content/image`, formData, config)
            .then(this.setState({ imageUploadStatus : "success" }))
            .catch(err => {console.log(err); this.setState({ imageUploadStatus : "failed" });});  
    }  

    handleDelete(contentId, accessToken) {
        let newForm = this.state.fullForm.filter(function(item) {
            return item.contentId !== contentId;
        })
        
        fetch(`https://localhost:5001/api/content/${contentId}`, {
            method: 'DELETE',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'X-Authorization-Access-Token': accessToken
            }
        })
        .then(() => {console.log('setting state');this.setState({ fullForm: newForm })})
        .catch(console.log);  
    }

    render() {
        return(
            <div id="adminParent">
                <form onSubmit={this.onFormSubmit}>
                    <h2 id="adminHeader">Home Page</h2>
                        <div id="adminSection">
                            <ContentItems content={this.state.fullForm} page={"Home"} handleChange={this.handleChange}/>
                        </div>
                    <h2 id="adminHeader">About Page</h2>
                        <div id="adminSection">
                            <ContentItems content={this.state.fullForm} page={"About"} handleChange={this.handleChange}/>
                        </div>
                    <h2 id="adminHeader">Gallery Page</h2>
                        <div id="adminSection">
                            <ContentItems content={this.state.fullForm} page={"Gallery"} handleChange={this.handleChange} handleDelete={this.handleDelete.bind(this)} accessToken={this.props.accessToken}/>
                            <ImageUploadStatus
                                uploadStatus={this.state.imageUploadStatus}
                            />
                            <ImageUploader
                                withIcon={false}
                                buttonText='Upload image'
                                onChange={this.uploadGalleryImage.bind(this)}
                                imgExtension={['.jpg', '.png']}
                                maxFileSize={5242880}
                                singleImage={true}
                            />
                        </div>
                    <h2 id="adminHeader">Contact Page</h2>
                        <div id="adminSection">
                            <ContentItems content={this.state.fullForm} page={"Contact"} handleChange={this.handleChange} />
                        </div>
                    <Button
                        id="adminSubmitButton"
                        block
                        bsSize="large"
                        type="submit"
                    >
                        Submit
                    </Button>
                </form>
            </div>
        )
    }
}

function ContentItems(props) {
    return props.content.map(function(item) {
        if (props.page === item.page) {
            if (item.contentType === "Copy") {
                return <FormGroup controlid={item.contentId}>
                           <p id="contentHeader">{item.contentId}</p>
                            <FormControl class="adminForm"
                                id={item.contentId}
                                autoFocus
                                value={item.value}
                                onChange={props.handleChange}
                            />
                        </FormGroup>
            }
            else if (item.contentType === "Image" && item.page === "Gallery") {
                return <div class="adminImageContainer">
                           <img class="adminGalleryImage" src={item.value}></img>
                           <button class="adminDeleteButton" type="button" onClick={() => props.handleDelete(item.contentId, props.accessToken)}>Delete</button>
                       </div>
                
            }
            else if (item.contentType === "Image") {
                return <img class="adminImage" src={item.value}></img>
            }
        }
    })
}

function ImageUploadStatus(props) {
    if (props.uploadStatus === "success") {
        return <div id="imageUploadStatus">
               <p id="uploadSuccess">Success!</p>
        </div>
    }
    else if (props.uploadStatus === "failed") {
        return <div id="imageUploadStatus">
               <p id="uploadFailure">Upload failed!</p>
        </div>
    }

    return null;
}