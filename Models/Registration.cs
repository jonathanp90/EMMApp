using System.ComponentModel.DataAnnotations;

namespace EMMapp.Models;

public class Registration
{
    public int id{get; set;}
    [Required]
    public String lastName{get; set;}
    [Required]
    public String hisName{get; set;}
    [Required]
    public String herName{get; set;}
    [Required]
    public String city{get; set;}
    [Required]
    public String hisPhone{get; set;}
    public String herPhone{get; set;}
    public String readSpanish{get; set;}
    public String churchMarried{get;set;}
    public int yearsMarried{get;set;}
    [Required]
    public int zone{get; set;}
    public int paid{get; set;}
    public String comments{get; set;}

    public DateTime CreatedAt{ get; set;} = DateTime.UtcNow;
}