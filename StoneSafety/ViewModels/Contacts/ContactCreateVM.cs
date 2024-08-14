using System.ComponentModel.DataAnnotations;

namespace StoneSafety.ViewModels.Contacts
{
    public class ContactCreateVM
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string SurName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required] 
        public string Subject { get; set; }
        [Required] 
        public string Message { get; set; }
    }
}
