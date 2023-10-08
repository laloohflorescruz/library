namespace LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;
public class LibraryBranch
{ 
    [Key]
    public int LibraryBranchId { get; set; }
    public string BranchName { get; set; }
      public string ZipCode {get; set;}
    public string Address { get; set; }
    public string Phone { get; set; }
    public string City {get; set;}
    public string Email {get; set;}
    public string OpeningHours {get; set;}


}