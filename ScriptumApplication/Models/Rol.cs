using System.ComponentModel.DataAnnotations;

namespace ScriptumApplication.Models
{
    public class Rol
    {
        public int Id { get; set; }
        [Display(Name = "Nombre del rol")]
        public string NombreRol { get; set; }
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }
    }
}
