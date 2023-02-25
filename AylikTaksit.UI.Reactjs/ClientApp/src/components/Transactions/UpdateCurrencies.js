import React, { Component } from 'react';

export class UpdateCurrencies extends Component {

  constructor(props) {
    super(props);
    this.state = { transactions: [], loading: true,dataLength: 0 };
  }

  componentDidMount() {
    this.fetchCurrencies();
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : this.renderCurrencies();
    return (
      <div>
        {contents}
      </div>
    );
  }
    renderCurrencies = () => (<div>
        <div>Gold: {this.state.gold}</div>
        <div>Dollar: {this.state.dollar}</div>
    </div>);
  async fetchCurrencies() {
        const dollarPromise =  fetch('/api/Currency/Dollar');
      const goldPromise =  fetch('/api/Currency/Gold');
        const [dollar, gold] = await Promise.all([dollarPromise, goldPromise]);
      const data = await gold.json();
      this.setState({ gold: data["ga"]["satis"],dollar:await dollar.json(), loading: false });
  }
}
