namespace SerV.Data;

public class CV
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Title { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string LinkedIn { get; set; }
    public string Address { get; set; }
    public string About { get; set; }
    public List<Experience> Experiences { get; set; }
    public List<Education> Educations { get; set; }
    public List<Skills> Skills { get; set; }
}
