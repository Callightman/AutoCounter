import React, { Component } from "react";
import axios from "axios";
class Customers extends Component {
  state = {
    customers: []
  };
  async componentDidMount() {
    document.title = "Kopitek Sayaç Sistemi";
    const instance = axios.create({
      headers: {
        "X-Api-Key": "V24e05S83"
      }
    });

    let { data: customers } = await instance.get(
      "http://counter.kopitek.com.tr/api/customers"
    );
    this.setState({ customers });
  }
  render() {
    return (
      <table className="table table-striped">
        <thead className="thead-dark">
          <tr>
            <th>Müşteri Numarası</th>
            <th>Müşteri Adı</th>
          </tr>
        </thead>
        <tbody>
          {this.state.customers.map(customer => (
            <tr>
              <td>{customer.id}</td>
              <td>{customer.name}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }
}

export default Customers;
