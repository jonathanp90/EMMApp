using System.ComponentModel.DataAnnotations;

namespace EMMapp.Models;

public class Registration
{
    public int id{get; set;}
    [Required]
    public required string lastName { get; set; }
    [Required]
    public required string hisName { get; set; }
    [Required]
    public required string herName { get; set; }
    [Required]
    public required string city { get; set; }
    [Required]
    public required string hisPhone { get; set; }
    public string herPhone { get; set; } = "";
    public string readSpanish { get; set; } = "No";
    public string churchMarried { get; set; } = "No";
    public int yearsMarried{get;set;}
    [Required]
    public int zone{get; set;}
    public int paid{get; set;}
    public string comments { get; set; } = "";

    public DateTime CreatedAt{ get; set;} = DateTime.UtcNow;
}
