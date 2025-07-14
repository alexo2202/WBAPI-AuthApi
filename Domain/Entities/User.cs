using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TblUsers", Schema = "Auth")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "varbinary(max)")]
        public byte[] Password { get; set; }
        [Column(TypeName = "varbinary(max)")]
        public byte[] PasswordKey { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int EmployeeId { get; set; }
    }

}
