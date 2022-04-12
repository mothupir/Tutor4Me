using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutor4MeApi.Models
{
    public class Module
    {
        public Module()
        {
        }

        public Module(int moduleId, string name, string description)
        {
            ModuleId = moduleId;
            Name = name;
            Description = description;
        }

        public Module(Module module)
        {
            ModuleId = module.ModuleId;
            Name = module.Name;
            Description = module.Description;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModuleId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(8000)]
        public string Description { get; set; }
    }
}
