using ValidadorINE.Areas.Persona.Models;
using ValidadorINE.Areas.Persona.Models.Consulta;

namespace ValidadorINE.Repository.Interface.Persona
{
    public interface IPersonaINERepository
    {
        Task<List<PersonaINEViewModel>> GetPersonaINE_Seleccionar();
    }
}
