import React, { Component } from 'react';
import { Button, Table,ButtonToolbar } from 'react-bootstrap';
import { AddDepModal } from './AddDepModal';

export class Department extends Component {
    constructor(props) {
        super(props);
        this.state = { deps: [],addModalShow:false}
    }
    componentDidMount() {
        this.refreshList();
    }
    refreshList() {
        fetch('https://localhost:44387/api/Department')
            .then(response => response.json())
            .then(data => {
                this.setState({ deps: data });

            });
    }
    componentDidUpdate() {
        this.refreshList();
    }

    render() {
        const { deps } = this.state;
        let addModalClose = () => this.setState({ addModalShow: false });
        return (
            <div>
            <Table className="mt-4" striped border hover size="sm">
                <thead>
                    <tr>
                        <th>Department ID</th>
                        <th>Department Name</th>
                    </tr>
                </thead>
                <tbody>
                    {deps.map(dep =>
                        <tr key={dep.DepartmentID}>
                            <td>{dep.DepartmentID}</td>
                            <td>{dep.DepartmentName}</td>
                        </tr>
                    )}
                </tbody>

            </Table>

            <ButtonToolbar>
            <Button variant='primary' onClick={()=>this.setState({addModalShow:true})}>
                    AddDepartment
            </Button>
            <AddDepModal show={this.state.addModalShow} onHide={addModalClose}></AddDepModal>
           </ButtonToolbar>
            </div>
        )
    }
}
