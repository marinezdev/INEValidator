using System.ComponentModel.DataAnnotations;

namespace ValidadorINE.Areas.Administracion.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public Cat_RolViewModel? Cat_Rol { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string? Usuario { get; set; }
    }
}
