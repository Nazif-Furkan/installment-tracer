import React, { Component } from 'react';
import { useState } from "react";
import TransactionForm from "./AddData";
import {UpdateCurrencies} from "./UpdateCurrencies";
export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { transactions: [], loading: true,dataLength: -1 };
  }

  componentDidMount() {
    this.populateWeatherData();
  }
  
  static renderTransactionTable(transactions) {
    console.log(transactions);
    const titles = {
        id: "Id",
        title: "Başlık",
        amount: "Tutar",
        installment: "Taksit sayısı",
    }
    return (<div>
            <UpdateCurrencies></UpdateCurrencies>
            <table className="table table-striped" aria-labelledby="tableLabel">
        <thead>
        <tr>
            {
                transactions.length > 0 ?
                    Object.keys(titles).map((key, index) => 
                    { return <th key={index}>{titles[key]}</th>}) : <th>Empty</th>
            }
        </tr>
        </thead>
        <tbody>
        {transactions.map(t =>
            <tr key={t.id}>
                {
                    Object.keys(titles).map((key, index) => {
                        console.log("key: " + key + ",index:" + index + "=>t.key:" + t[key]);
                            return <td key={index}>{t[key]}</td>;
                    }
                    )
                }
            </tr>
        )}
        </tbody>
    </table></div>
      
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderTransactionTable(this.state.transactions);
    return (
      <div>
        <h1 id="tableLabel">Aylık taksitler</h1>
        <TransactionForm updateTransactions={()=>this.populateWeatherData()}></TransactionForm>
        {contents}
      </div>
    );
  }
    
  async populateWeatherData() {
    const response = await fetch('api/Transaction/All');
    const data = await response.json();
    if (data.length !== this.state.dataLength) 
        this.setState({ transactions: data, loading: false });
  }
}
