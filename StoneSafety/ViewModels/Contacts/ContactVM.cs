using System.ComponentModel.DataAnnotations;

namespace StoneSafety.ViewModels.Contacts
{
    public class ContactVM
    {
        public int Id { get; set; }
        public string Name { get; set; }     
        public string SurName { get; set; }      
        public string Email { get; set; }    
        public string Subject { get; set; }  
        public string Message { get; set; }


        public string ContactEmail { get; set; }
        public string Phone { get; set; }
        public string Phone1 { get; set; }
        public string Location { get; set; }
    }
}
