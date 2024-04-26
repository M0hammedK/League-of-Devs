using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace League_of_Devs.Models
{
    public class PostsModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        [NotMapped]
        public IFormFile ThumbImage { get; set; }
        public string thumbimage { get; set; }
        public string Content { get; set; }
        [NotMapped]
        public List<IFormFile> Image { get; set; }
        public string image { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public AccountsModel Account { get; set; }
    }
}