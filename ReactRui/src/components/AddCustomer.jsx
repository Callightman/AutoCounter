import React, { Component } from "react";
import axios from "axios";
import qs from "qs";

class AddCustomer extends Component {
  state = {
    name: "",
    message: ""
  };
  componentDidMount() {
    document.title = "Kopitek Sayaç Sistemi";
  }
  handleClick = () => {
    const instance = axios.create({
      headers: {
        "X-Api-Key": "V24e05S83"
      }
    });

    let customer = {
      name: this.state.name
    };
    instance
      .post(
        "http://counter.kopitek.com.tr/api/customers",
        qs.stringify(customer)
      )
      .then(response => {
        console.log(response);
        this.setState({ message: "Müşteri Kaydedildi" });
      })
      .catch(error => {
        console.log(error);
        this.setState({ message: "Hata oluştu" });
      });
  };
  handleChange = event => {
    this.setState({ name: event.target.value });
  };
  render() {
    return (
      <div className="row">
        <h2>Yeni müşteri kaydet</h2>
        <p className="lead">
          Müşteri listesinden müşterinin daha önce kayıtlı olup olmadığını
          mutlaka kontrol edin.
        </p>
        <div className="col-md-8 order-md-1">
          <div className="form-group">
            <label>Müşteri Adı</label>
            <input
              className="form-control"
              id="exampleFormControlFile1"
              value={this.state.name}
              onChange={this.handleChange}
            />
          </div>
          <button
            type="submit"
            className="btn btn-primary mb-2"
            onClick={this.handleClick}
          >
            Müşteri Kaydet
          </button>
          <label>{this.state.message}</label>
        </div>
      </div>
    );
  }
}

export default AddCustomer;
