namespace EMMapp.Dtos;

public class RegistrationCreateDto
{
     public required string lastName { get; set; }
     public required string hisName { get; set; }
     public required string herName { get; set; }
     public required string hisPhone { get; set; }
     public string herPhone { get; set; } = "";
     public required string city { get; set; }
     public int zone { get; set; }
     public string readSpanish { get; set; } = "No";
     public string churchMarried { get; set; } = "No";
     public int yearsMarried { get; set; }
     public int paid { get; set; }
     public string comments { get; set; } = "";
}
