using System.ComponentModel.DataAnnotations.Schema;

namespace League_of_Devs.Models
{
    public class PostsModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AccountsModel Accounts { get; set; }
    }
}