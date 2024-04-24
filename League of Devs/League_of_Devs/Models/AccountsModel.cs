using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace League_of_Devs.Models
{
    public class AccountsModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string Password2 { get; set; }
        public string Authorization { get; set; } = "developer";
        public string Bio { get; set; } = "";
        public string Experience { get; set; } = "";
        public string Availability { get; set; } = "";
        

    }
}