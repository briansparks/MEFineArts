import React, {Component} from 'react';
import { Button, FormGroup, FormControl } from "react-bootstrap";

export default class Administration extends Component {
    constructor(props) {
        super(props);

        const homePageContent = this.props.content.filter(function(item) {
            return item.page == "Home";
        });

        const aboutPageContent = this.props.content.filter(function(item) {
            return item.page == "About";
        });

        const galleryPageContent = this.props.content.filter(function(item) {
            return item.page == "Gallery";
        });

        const contactPageContent = this.props.content.filter(function(item) {
            return item.page == "Contact";
        });

        this.state = { accessToken: "", homeContent: homePageContent, aboutContent: aboutPageContent, galleryContent: galleryPageContent, contactContent: contactPageContent }
    }

    onFormSubmit = event => {
        event.preventDefault();

        fetch(`https://localhost:5001/api/content`, {
            method: 'PUT',
            body: this.props.content
        })
        .then(x => x.json())
        .then((result) => {this.setState({ accessToken: result })})
        .catch(console.log);  

        console.log("form submitted!");
    }

    handleChange = event => {
        // this.setState({
        //   [event.target.id]: event.target.value
        // });
      }

    render() {
        return(
            <div id="adminParent">
                <form onSubmit={this.onFormSubmit}>
                    <h2 id="adminHeader">Home Page</h2>
                        <div id="adminSection">
                            <ContentItems content={this.state.homeContent} handleChange={this.handleChange}/>
                        </div>
                    <h2 id="adminHeader">About Page</h2>
                        <div id="adminSection">
                            <ContentItems content={this.state.aboutContent} handleChange={this.handleChange}/>
                        </div>
                    <h2 id="adminHeader">Gallery Page</h2>
                        <div id="adminSection">
                            <ContentItems content={this.state.galleryContent} handleChange={this.handleChange}/>
                        </div>
                    <h2 id="adminHeader">Contact Page</h2>
                        <div id="adminSection">
                            <ContentItems content={this.state.contactContent} handleChange={this.handleChange}/>
                        </div>
                    <Button
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
        if (item.contentType == "Copy") {
            return <FormGroup controlid="contentitem">
                       <p>{item.contentId}</p>
                        <FormControl id="adminForm"
                            autoFocus
                            value={item.value}
                            onChange={props.handleChange}
                        />
                    </FormGroup>
        }
        else if (item.contentType == "Image") {
            return <img class="adminImage" src={item.value}></img>
        }
    })
}