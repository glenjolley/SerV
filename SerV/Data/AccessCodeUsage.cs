namespace SerV.Data;

public class AccessCodeUsage
{
    public int Id { get; set; }
    public AccessCode AccessCode { get; set; }
    public DateTime UsedAt { get; set; }
}
