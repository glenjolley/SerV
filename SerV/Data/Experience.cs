namespace SerV.Data;

public class Experience
{
    public int Id { get; set; }
    public string Company { get; set; }
    public string Role { get; set; }
    public string Description { get; set; }
    public DateTime DateStarted { get; set; }
    public DateTime? DateEnded { get; set; }
}
