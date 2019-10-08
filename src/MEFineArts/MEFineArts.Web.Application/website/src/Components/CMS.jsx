import React, {Component} from 'react';
import Administration from './Administration';
import Login from './Login';

export default class CMS extends Component {
    constructor(props) {
        super(props);

        this.state = { accessToken : "", loggedIn : false }
    }

    handleLogin(username, password) {
        return event => {
            event.preventDefault();
            
            fetch(`https://localhost:5001/api/login/user?username=${username}&password=${password}`, {
                method: 'GET',
                headers : { 
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                   }
            })
            .then(x => x.json())
            .then((result) => {this.setState({ accessToken: result })})
            .catch(console.log);  

            if (this.state.accessToken !== undefined && this.state.accessToken !== null && this.state.accessToken !== "") {
                this.setState({ loggedIn : true })
            }  
        }
    }

    render() {
        return (
            <div>
                <CmsBody 
                    loggedIn={this.state.loggedIn} 
                    accessToken={this.state.accessToken} 
                    handleLogin={this.handleLogin.bind(this)}
                    content={this.props.content}
                />
            </div>
        )
    }
}

function CmsBody(props) {
    if (props.loggedIn) {
        return <Administration accessToken={props.accessToken} content={props.content}/>
    }
    else {
        return <Login handleLogin={props.handleLogin.bind(this)} />
    }
}