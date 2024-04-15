namespace Entities;

public class FinancialDoc
{
    public Guid DocumentId { get; set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public string Currency { get; set; }
    public List<Transaction> Transactions { get; set; }
}
