using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TblRoles", Schema = "Auth")]
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RoleModule> RoleModules { get; set; }
        public ICollection<User> Users { get; set; }
    }

}
