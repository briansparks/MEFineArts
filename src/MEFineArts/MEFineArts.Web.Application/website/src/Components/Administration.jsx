import React, {Component} from 'react';
import { Button, FormGroup, FormControl } from "react-bootstrap";

export default class Administration extends Component {
    constructor(props) {
        super(props);

        this.state = { accessToken: "", fullForm: this.props.content }
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
        .then(x => x.json())
        .then((result) => {this.setState({ accessToken: result })})
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
                            <ContentItems content={this.state.fullForm} page={"Gallery"} handleChange={this.handleChange}/>
                        </div>
                    <h2 id="adminHeader">Contact Page</h2>
                        <div id="adminSection">
                            <ContentItems content={this.state.fullForm} page={"Contact"} handleChange={this.handleChange}/>
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
            else if (item.contentType == "Image") {
                return <img class="adminImage" src={item.value}></img>
            }
        }
    })
}