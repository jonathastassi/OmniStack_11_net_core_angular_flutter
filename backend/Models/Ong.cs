using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Ong
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Whatsapp { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string City { get; set; }
        [Required]
        [Column(TypeName = "varchar(2)")]
        public string Uf { get; set; }

        public List<Incident> Incidents { get; set; }
    }
}