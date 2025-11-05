using System.ComponentModel.DataAnnotations;

namespace EuroSkills.Models
{
    public class Szakma
    {
        [Key]
        public string Id { get; set; }
        public string SzakmaNev { get; set; }
    }
}
