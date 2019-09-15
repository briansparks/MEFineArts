import React, {Component} from 'react';
import Menu from './Menu';
import Home from './Home';

export default class App extends Component {
    constructor(props) {
        super(props);

        this.state = { "content" : [] };
    }

    componentDidMount() {
        fetch("https://localhost:44393/api/content")
        .then(x => x.json())
        .then((result) => {this.setState({ content: result })})
        .catch(console.log);        
    }
    
    render() {
        return (
            <div>
                <Menu />
                <Home content={this.state.content}/>
                <div id="bottom"> 
                    <a href="https://facebook.com/ArtME15/" class="fa fa-facebook"></a>
                    <a href="https://www.linkedin.com/in/megan-eisenhauer-97a923137" class="fa fa-linkedin"></a>
                    <a href="https://www.instagram.com/mefinearts17/?hl=en" class="fa fa-instagram"></a>
                </div>
            </div>
        );
    }
}
