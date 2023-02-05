using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AylikTaksit.DataAccess;

public class PaymentAccount
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime? ExtractDate { get; set; }
    public int GroupId { get; set; }
}