using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    [Table("user_accounts")]
    public class UserAccount
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [Column("hashed_password")]
        public string HashedPassword { get; set; }

        [Column("role_id")]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; } // Навигационное свойство

        [Column("client_id")]
        public int? ClientId { get; set; } // Может быть null, если не все аккаунты связаны с клиентами
                                           // public Client Client { get; set; } // Раскомментируйте и определите, если у вас есть сущность Client

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }

}
