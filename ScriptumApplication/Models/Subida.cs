using System.ComponentModel.DataAnnotations;

namespace ScriptumApplication.Models
{
    public class Subida
    {
        public int Id { get; set; }
        [Display(Name = "Id autor")]
        public int IdAutor { get; set; }
        [Display(Name = "Id libro")]
        public int IdLibro { get; set; }
        [Display(Name = "Rol del autor")]
        public string RolAutor { get; set; }
    }
}
