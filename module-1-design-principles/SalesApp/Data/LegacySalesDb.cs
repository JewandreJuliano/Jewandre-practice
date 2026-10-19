using System.Text;

namespace SalesApp.Data;

public interface ISalesRepository
{
    List<SalesRecord> GetAllSales();
    Task<List<SalesRecord>> GetAllSalesAsync();
    void DeleteSale(int id);
    void UpdateStatus(int id, string status);
    string ExportToCsv();
    void EmailToAuditor(string auditorEmail);
}

/// <summary>
/// Pretends to be a SQL Server database. The data lives in memory so the app runs
/// on any machine without a real database, but the class is written the way a lot of
/// older production code talks to SQL.
/// </summary>
public class LegacySalesDb : ISalesRepository
{
    private readonly string _connectionString;

    // Shared "table": deletes and updates persist until you restart the app.
    protected static readonly List<SalesRecord> Table = Seed();

    public LegacySalesDb(string connectionString)
    {
        _connectionString = connectionString;
        Console.WriteLine($"[LegacySalesDb] Opening connection: {_connectionString}");
    }

    public virtual List<SalesRecord> GetAllSales()
    {
        Thread.Sleep(300); // pretend this is a slow database round trip
        lock (Table)
        {
            return Table.Select(Clone).ToList();
        }
    }

    public virtual async Task<List<SalesRecord>> GetAllSalesAsync()
    {
        await Task.Delay(300); // pretend this is a slow database round trip
        lock (Table)
        {
            return Table.Select(Clone).ToList();
        }
    }

    public virtual void DeleteSale(int id)
    {
        lock (Table)
        {
            Table.RemoveAll(s => s.Id == id);
        }
    }

    public virtual void UpdateStatus(int id, string status)
    {
        lock (Table)
        {
            var sale = Table.FirstOrDefault(s => s.Id == id);
            if (sale != null)
            {
                sale.Status = status;
            }
        }
    }

    public virtual string ExportToCsv()
    {
        var sb = new StringBuilder("Id,Region,SalesRep,OrderDate,Amount,Status\n");
        foreach (var s in GetAllSales())
        {
            sb.AppendLine($"{s.Id},{s.Region},{s.SalesRep},{s.OrderDate:yyyy-MM-dd},{s.Amount},{s.Status}");
        }
        return sb.ToString();
    }

    public virtual void EmailToAuditor(string auditorEmail)
    {
        Console.WriteLine($"[LegacySalesDb] Emailing full sales export to {auditorEmail}");
    }

    private static SalesRecord Clone(SalesRecord s) => new()
    {
        Id = s.Id,
        Region = s.Region,
        SalesRep = s.SalesRep,
        OrderDate = s.OrderDate,
        Amount = s.Amount,
        Status = s.Status
    };

    private static List<SalesRecord> Seed()
    {
        var random = new Random(42); // fixed seed so everyone sees the same data
        string[] regions = { "Gauteng", "Western Cape", "KwaZulu-Natal", "Eastern Cape" };
        string[] reps = { "Thabo M.", "Aisha K.", "Pieter V.", "Naledi S.", "Ryan D.", "Zanele N." };
        string[] statuses = { "Completed", "Completed", "Completed", "Pending", "Cancelled" };
        var start = new DateTime(2025, 1, 1);

        var list = new List<SalesRecord>();
        for (var i = 1; i <= 240; i++)
        {
            list.Add(new SalesRecord
            {
                Id = i,
                Region = regions[random.Next(regions.Length)],
                SalesRep = reps[random.Next(reps.Length)],
                OrderDate = start.AddDays(random.Next(0, 640)),
                Amount = Math.Round((decimal)(random.NextDouble() * 15000 + 250), 2),
                Status = statuses[random.Next(statuses.Length)]
            });
        }
        return list;
    }
}

/// <summary>
/// Archived (pre-2026) sales. Added later by a different developer.
/// </summary>
public class ArchivedSalesDb : LegacySalesDb
{
    public ArchivedSalesDb(string connectionString) : base(connectionString)
    {
    }

    public override List<SalesRecord> GetAllSales() =>
        base.GetAllSales().Where(s => s.OrderDate.Year < 2026).ToList();

    public override async Task<List<SalesRecord>> GetAllSalesAsync() =>
        (await base.GetAllSalesAsync()).Where(s => s.OrderDate.Year < 2026).ToList();

    public override void DeleteSale(int id) =>
        throw new NotSupportedException("Archived sales are read-only.");

    public override void UpdateStatus(int id, string status) =>
        throw new NotSupportedException("Archived sales are read-only.");
}
