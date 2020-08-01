using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Document { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="The {0} field can not have more than {1} caracters")]
        [Display (Name="First Name")]
        public string FirstName  { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} caracters")]
        [Display (Name ="Last Name")]
        public string LastName { get; set; }
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} caracters")]
        [Display(Name = "Fixed Phone")]
        public string FixedPhone { get; set; }
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} caracters")]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} caracters")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display (Name ="Owner Name")]
        public string FullName => $"{FirstName} {LastName}";
        public string FullNameW => $"{FirstName} {LastName} - {Document}";
        public ICollection<Property> Properties { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
