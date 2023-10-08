namespace LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;
public class LibraryBranch
{
  [Key]
  public int LibraryBranchId { get; set; }

  [Display(Name = "Branch Name")]
  public string? BranchName { get; set; }

  public string? ZipCode { get; set; }
  public string? Address { get; set; }

  [Required]
  public string? Phone { get; set; }
  public string? City { get; set; }
  public string? Email { get; set; }

  [Display(Name = "Opening Hours")]
  public string? OpeningHours { get; set; }

}