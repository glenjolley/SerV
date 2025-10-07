namespace SerV.Data;

public class AccessCode
{
    public int Id { get; set; }
    public string Code { get; set; }
    public CV CV { get; set; }
    public bool IsExpired { get; set; }
    public DateTime? ExpiredAt { get; set; }
}
