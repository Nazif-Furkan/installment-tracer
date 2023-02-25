using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AylikTaksit.DataAccess;

public class Transaction
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public double Amount { get; set; }
    public double? DollarCurrencyWhenSpend { get; set; }
    public int Installment { get; set; }
    public bool IsAmountFirstCalculation { get; set; } = true;
    public int GroupId { get; set; }
    public int? ConnectedAccount{ get; set; }
}