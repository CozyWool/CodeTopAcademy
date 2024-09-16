import "./Colors.scss";
import {Component} from "react";

class Colors extends Component {
    constructor(props) {
        super(props);
        this.state = {
            currentColor: "yellow",
        }
    }

    render() {
        const handlerClick = (color) => {
            this.setState({currentColor: color})
        };
        
        return (
            <div id="Colors">
                <button className="button" onClick={() => handlerClick('red')}>Red</button>
                <button className="button" onClick={() => handlerClick('yellow')}>Yellow</button>
                <button className="button" onClick={() => handlerClick('green')}>Green</button>
                <div className={"canvas canvas_" + this.state.currentColor}></div>
            </div>
        );
    }
}

export default Colors