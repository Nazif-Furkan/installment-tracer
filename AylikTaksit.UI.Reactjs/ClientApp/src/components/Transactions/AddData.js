import React, { useState } from 'react';

function TransactionForm({ updateTransactions }) {
    const [title, setTitle] = useState('');
    const [amount, setAmount] = useState('0.00');
    const [installment, setInstallment] = useState('1');

    const handleSubmit = (e) => {
        e.preventDefault();

        const transaction = {
            title: title,
            amount: parseFloat(amount),
            dollarCurrencyWhenSpend: 0,
            installment: parseInt(installment),
            groupId: 0,
            connectedAccount: 0
        };

        fetch('/api/Transaction/AddTransaction', {
            method: 'POST',
            body: JSON.stringify(transaction),
            headers: {
                'Content-Type': 'application/json'
            },
        })
            .then(response => {
                if (response.status === 200) {
                    updateTransactions();
                    setTitle('');
                    setAmount('0.00');
                    setInstallment('1');
                }
            })
            .catch(error => console.error(error));
    };

    return (
        <form onSubmit={handleSubmit}>
            <label htmlFor="title">Başlık:</label><br />
            <input type="text" id="title" name="title" value={title} onChange={(e) => setTitle(e.target.value)} /><br />

            <label htmlFor="amount">Tutar:</label><br />
            <input type="text" id="amount" name="amount" value={amount} onChange={(e) => setAmount(e.target.value)} /><br />

            <label htmlFor="installment">Taksit Sayısı:</label><br />
            <input type="text" id="installment" name="installment" value={installment} onChange={(e) => setInstallment(e.target.value)} /><br />

            <button type="submit">Add</button>
        </form>
    );
}

export default TransactionForm;