using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Incident
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Value { get; set; }

        public string OngId { get; set; }
        public Ong Ong { get; set; }
    }
}