using System.ComponentModel.DataAnnotations.Schema;

namespace League_of_Devs.Models
{
    public class AccountsModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string Password2 { get; set; }
    }
}