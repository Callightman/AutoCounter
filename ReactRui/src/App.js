import React, { Component } from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import logo from "./logo.svg";
import "./App.css";
import Counters from "./components/counters";
import Customers from "./components/customers";
import AddCustomer from "./components/AddCustomer";

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <div>
          <div>
            <nav className="navbar navbar-expand-md navbar-dark bg-dark mb-4">
              <a className="navbar-brand" href="/">
                Kopitek
              </a>
              <button
                className="navbar-toggler"
                type="button"
                data-toggle="collapse"
                data-target="#navbarCollapse"
                aria-controls="navbarCollapse"
                aria-expanded="false"
                aria-label="Toggle navigation"
              >
                <span className="navbar-toggler-icon" />
              </button>
              <div className="collapse navbar-collapse" id="navbarCollapse">
                <ul className="navbar-nav mr-auto">
                  <li className="nav-item active">
                    <a className="nav-link" href="/">
                      Sayaçlar <span className="sr-only">(current)</span>
                    </a>
                  </li>
                  <li className="nav-item">
                    <a className="nav-link" href="/customers">
                      Müşteriler
                    </a>
                  </li>
                  <li className="nav-item">
                    <a className="nav-link" href="/add">
                      Müşteri Ekle
                    </a>
                  </li>
                </ul>
              </div>
            </nav>
          </div>
          <div>
            <main role="main" className="container">
              <Switch>
                <Route exact path="/" component={Counters} />
                <Route path="/customers" component={Customers} />
                <Route path="/add" component={AddCustomer} />
              </Switch>
            </main>
          </div>
        </div>
      </BrowserRouter>
    );
  }
}

export default App;
