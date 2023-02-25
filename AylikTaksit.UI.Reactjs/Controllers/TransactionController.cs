using AylikTaksit.Api.Models.Transaction;
using AylikTaksit.Business;
using AylikTaksit.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace AylikTaksit.UI.Reactjs.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TransactionController : ControllerBase
{
    private readonly TransactionsBll _tb;

    public TransactionController(TransactionsBll tb)
    {
        _tb = tb;
    }
    [HttpGet(Name = nameof(All))]
    public IEnumerable<Transaction> All()
    {
        return _tb.GetTransactions().ToList();
    }
    
    [HttpPost(Name = nameof(AddTransaction))]
    public AddTransactionResponse AddTransaction(AddTransactionRequest transaction)
    {
        
        return new AddTransactionResponse(){CreatedTransactionId = _tb.AddTransaction(transaction)};
    }
}