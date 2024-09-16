import './App.css';
import React from "react";
import User from "./components/User/User";
import Counter from "./components/Counter/Counter";
import Colors from "./components/Colors/Colors";


class App extends React.Component {
    render() {
        return (
            <React.Fragment>
                <div className="App">
                    <User/>
                    <Counter start={2}/>
                    <Colors />
                </div>
            </React.Fragment>
        );
    }
}

export default App;
