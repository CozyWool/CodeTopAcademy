import React from "react";
import "./Counter.css"
import City from "../City/City";

class Counter extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            currentValue: props.start,
        };
    }

    render() {
        const handlerClick = () => {
            if (this.state.currentValue < 6) {
                this.setState({currentValue: this.state.currentValue + 1});
            } else {
                this.setState({currentValue: 1});
            }
        }
        return (

            <React.Fragment>
                <City count={this.state.currentValue}/>
                <button onClick={handlerClick} className="clicker">{this.state.currentValue}</button>
            </React.Fragment>
        );
    }
}

export default Counter;