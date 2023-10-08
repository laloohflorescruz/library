namespace LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;
public class Customer
{
     [Key]
    public int CustomerId { get; set; }
    public string LastName { get; set; }
    public string FirtName { get; set; }
    public DateOnly Brithday { get; set; }
    public bool Student { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateOnly MembershipSince { get; set; }


}
