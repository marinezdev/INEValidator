using ValidadorINE.Areas.Persona.Models.Consulta;

namespace ValidadorINE.Repository.Interface.Persona
{
    public interface IPersonaUsuarioRepository
    {
        Task<List<CPersonaUsuario>> GetPersonaUsuario_Seleccionar();
    }
}
