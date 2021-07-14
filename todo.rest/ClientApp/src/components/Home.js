import React, { Component } from 'react';

function handleComplete(taskid) {
    fetch(`api/todotasks/${taskid}`, {
        method: 'PATCH',
    }).then(function (response) {
        if (response.ok) {
            alert("Task Completed")
        } else {
            alert("Task not completed")
        }
        return response.json();
    });
}

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { tasks: [], loading: true };
    }

    componentDidMount() {
        this.populateIncompleteTasks();
    }

    static renderIncompleteTasksTable(tasks) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Created</th>
                        <th>Due</th>
                        <th>Completed</th>
                    </tr>
                </thead>
                <tbody>
                    {tasks.map(task =>
                        <tr key={task.id}>
                            <td>{task.name}</td>
                            <td>{task.description}</td>
                            <td>{task.created}</td>
                            <td>{task.due}</td>
                            <td>
                                <button onClick={() => handleComplete(task.id)}>
                                    Complete
                                </button>
                            </td>

                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Home.renderIncompleteTasksTable(this.state.tasks);

        return (
            <div>
                <h1 id="tabelLabel" >Incomplete Tasks</h1>
                <p>All tasks yet to be completed.</p>
                {contents}
            </div>
        );
    }

    async populateIncompleteTasks() {
        const response = await fetch('api/todotasks/incomplete');
        const data = await response.json();
        this.setState({ tasks: data, loading: false });
    }
}

