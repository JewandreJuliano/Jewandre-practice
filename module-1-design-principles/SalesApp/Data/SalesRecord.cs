namespace SalesApp.Data;

public class SalesRecord
{
    public int Id { get; set; }
    public string Region { get; set; } = "";
    public string SalesRep { get; set; } = "";
    public DateTime OrderDate { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; } = "";
}
