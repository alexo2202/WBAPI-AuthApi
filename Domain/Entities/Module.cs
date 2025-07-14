using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TblModules", Schema = "Auth")]
    public class Module
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RoleModule> RoleModules { get; set; }
    }

}
