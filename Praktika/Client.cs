using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    [Table("clients")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("client_id")]
        public int ClientId { get; set; }

        [Required]
        [Column("full_name")]
        public string FullName { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("gender")]
        public string Gender { get; set; }


        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Column("interests")]
        public string Interests { get; set; }

        [Column("relationship_type")]
        public string RelationshipType { get; set; }

        [Column("partner_preferences")]
        public string PartnerPreferences { get; set; }

        // Это поле может быть лишним, если вы используете отдельную систему аутентификации
        [Column("password")]
        public string Password { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
