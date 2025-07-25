using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Entities
{
    public class Owners
    {
        [Key]
        [Required(ErrorMessage = "Document is required")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Document must be exactly 8 digits")]
        [Display(Name = "Document*")]
        public string Document { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50)]
        [Display(Name = "First Name*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50)]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; }

        [Display(Name = "Owner Name")]
        [StringLength(100)]
        public string? OwnerName { get; set; }

        [Display(Name = "Fixed Phone")]
        [Phone(ErrorMessage = "Invalid fixed phone")]
        [StringLength(20)]
        public string? FixedPhone { get; set; }

        [Display(Name = "Cell Phone")]
        [Phone(ErrorMessage = "Invalid cell phone")]
        [StringLength(20)]
        public string? CellPhone { get; set; }

        [Display(Name = "Address")]
        [StringLength(200)]
        public string? Address { get; set; }
    }
}
