import React, {Component} from 'react';
import { Button, FormGroup, FormControl } from "react-bootstrap";

export default class Login extends Component {
    constructor(props) {
        super(props);

        this.state = { username: "", password: "" }
    }

    handleChange = event => {
        this.setState({
          [event.target.id]: event.target.value
        });
      }

    render() {
        return(
            <div>
                <div id="loginForm">
                    <h2 id="loginHeader">Administration</h2>
                    <form onSubmit={this.props.handleLogin(this.state.username, this.state.password)}>
                        <FormGroup controlId="username">
                            <p>Username</p>
                            <FormControl
                                autoFocus
                                type="username"
                                value={this.state.username}
                                onChange={this.handleChange}
                            />
                        </FormGroup>
                        <FormGroup controlId="password">
                            <p>Password</p>
                            <FormControl
                                autoFocus
                                type="password"
                                value={this.state.password}
                                onChange={this.handleChange}
                            />
                        </FormGroup>
                        <br />
                        <Button
                            block
                            bsSize="large"
                            type="submit"
                        >
                            Submit
                        </Button>
                    </form>
                </div>
            </div>
        )
    }
}