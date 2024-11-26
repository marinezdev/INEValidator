using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using ValidadorINE.Areas.Administracion.Models.Consulta;
using ValidadorINE.Areas.Administracion.Models;
using ValidadorINE.Areas.Persona.Models.Consulta;
using ValidadorINE.Repository.Interface.Persona;
using ValidadorINE.Areas.Persona.Models;

namespace ValidadorINE.Repository.Services.Persona
{
    public class PersonaINEService : IPersonaINERepository
    { 
        private readonly string _cadenaSQL = string.Empty; 

        public PersonaINEService(IConfiguration configuration)
        {
            _cadenaSQL = configuration.GetConnectionString("UsersAdminConectionSQL");
        }

        public async Task<List<PersonaINEViewModel>> GetPersonaINE_Seleccionar()
        {
            List<PersonaINEViewModel> _result = new List<PersonaINEViewModel>();

            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Persona.INE_Consultar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        _result = JsonConvert.DeserializeObject<List<PersonaINEViewModel>>(dr.GetValue(0).ToString());
                    }
                }
                conexion.Close();
                return _result;
            }
        }
    }
}
