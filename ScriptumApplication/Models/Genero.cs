using System.ComponentModel.DataAnnotations;

namespace ScriptumApplication.Models
{
    public class Genero
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "El nombre del género es requerido")]
        public string Nombre { get; set; }
    }
}
