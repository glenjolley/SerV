namespace SerV.Data;

public class Education
{
    public int Id { get; set; }
    public string Institution { get; set; }
    public string Qualification { get; set; }
    public string Topic { get; set; }
    public short YearStarted { get; set; }
    public short? YearEnded { get; set; }
}
