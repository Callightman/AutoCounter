import React, { Component } from "react";
import axios from "axios";
import Select from "react-select";

class Counters extends Component {
  state = {
    counters: [],
    customers: [],
    options: [],
    filteredCounters: []
  };
  async componentDidMount() {
    const instance = axios.create({
      headers: {
        "X-Api-Key": "V24e05S83"
      }
    });

    let { data: counters } = await instance.get(
      "http://counter.kopitek.com.tr/api/counters"
    );
    let { data: customers } = await instance.get(
      "http://counter.kopitek.com.tr/api/customers"
    );

    customers.map(customer => this.pushtoState(customer));
    this.setState({ counters });
    this.setState({ customers });
    this.setState({ filteredCounters: counters });
  }

  pushtoState(customer) {
    let optionToBePushed = [];
    let option = { label: "", value: "" };
    option.label = customer.name;
    option.value = customer.id;

    this.setState({ options: this.state.options.concat(option) });
  }

  handleChange = event => {
    let counters = this.state.counters.filter(
      c => c.customerId === event.value
    );
    this.setState({ filteredCounters: counters });
  };

  render() {
    const { label, value } = this.state.options;
    console.log(value);
    return (
      <div>
        <h2>Kopitek Müşteri Sayaç Bilgi Ekranı</h2>
        <p className="lead">Bilgi almak istediğiniz müşteriyi aratın...</p>
        <Select options={this.state.options} onChange={this.handleChange} />
        <p />
        <table className="table table-striped">
          <thead className="thead-dark">
            <tr>
              <th>Müşteri Numarası</th>
              <th>Ip</th>
              <th>Serial</th>
              <th>101</th>
              <th>112</th>
              <th>113</th>
              <th>122</th>
              <th>123</th>
              <th>Son Güncelleme</th>
              <th>Cihaz Durumu</th>
            </tr>
          </thead>
          <tbody>
            {this.state.filteredCounters.map(counter => (
              <tr>
                <td>{counter.customerId}</td>
                <td>{counter.ip}</td>
                <td>{counter.serial}</td>
                <td>{counter.a4101}</td>
                <td>{counter.a3112}</td>
                <td>{counter.a4113}</td>
                <td>{counter.a3122Color}</td>
                <td>{counter.a4123Color}</td>
                <td>{counter.updateTime}</td>
                <td>{counter.lastStatus}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}

export default Counters;
