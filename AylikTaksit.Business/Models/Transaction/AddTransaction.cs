namespace AylikTaksit.Api.Models.Transaction;

public class AddTransactionRequest
{
    public string? Title { get; set; }
    public double Amount { get; set; }
    public double? DollarCurrencyWhenSpend { get; set; }
    public int Installment { get; set; }
    public int GroupId { get; set; }
    public int? ConnectedAccount{ get; set; }
}

public class AddTransactionResponse
{
    public int CreatedTransactionId { get; set; }
}