using ValidadorINE.Areas.Administracion.Models;
using ValidadorINE.Areas.Operacion.Models;

namespace ValidadorINE.Areas.Persona.Models.Consulta
{
    public class CPersonaUsuario
    {
        public PersonaViewModel? Persona { get; set; }
        public Cat_RolViewModel? Rol { get; set; }
        public UsuarioViewModel? Usuario { get; set; }
    }
}
