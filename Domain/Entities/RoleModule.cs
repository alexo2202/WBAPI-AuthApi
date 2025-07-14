using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TblRolesModules", Schema = "Auth")]
    public class RoleModule
    {
        [Key]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }

}
