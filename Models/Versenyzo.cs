using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EuroSkills.Models
{
    public class Versenyzo
    {
        [Key]
        public int Id { get; set; }
        public string Nev { get; set; }
        public string SzakmaId { get; set; }
        public string OrszagId { get; set; }
        public int Pont { get; set; }

        [ForeignKey(nameof(SzakmaId))]
        [JsonIgnore]
        public Orszag? Orszag { get; set; }

        [ForeignKey(nameof(OrszagId))]
        [JsonIgnore]
        public Szakma? Szakma { get; set; }
    }
}
