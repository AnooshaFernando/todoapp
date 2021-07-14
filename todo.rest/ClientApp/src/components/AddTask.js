import React, { Component } from 'react';

export class AddTask extends Component {
  static displayName = AddTask.name;

    constructor(props) {
        super(props);
        this.state = {
            Name: "",
            Description: "",
            Due: undefined
        };
    }

    handleChange = (event) => {
        this.setState({ [event.target.name]: event.target.value });
    }

    handleSubmit = (event) => {
        fetch('api/todotasks', {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            },
            // We convert the React state to JSON and send it as the POST body
            body: JSON.stringify(this.state)
        }).then(function (response) {
            if (response.ok) {
                alert("Task Created")
            } else {
                alert("Task not created")
            }
            return response.json();
        });

        event.preventDefault();
    }

  render() {
    return (
        <form onSubmit={this.handleSubmit}>
            <label>
                Name:
                <input type="text" value={this.state.value} name="Name" onChange={this.handleChange} />
            </label>
            <label>
                Description:
                <input type="text" value={this.state.value} name="Description" onChange={this.handleChange} />
            </label>
            <label>
                Due:
                <input type="date" value={this.state.value} name="Due" onChange={this.handleChange} />
            </label>
            <input type="submit" value="Submit" />
        </form>
    );
  }
}
