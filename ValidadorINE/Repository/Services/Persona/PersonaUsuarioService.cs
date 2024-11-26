using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using ValidadorINE.Areas.Administracion.Models.Consulta;
using ValidadorINE.Areas.Administracion.Models;
using ValidadorINE.Areas.Persona.Models.Consulta;
using ValidadorINE.Repository.Interface.Persona;

namespace ValidadorINE.Repository.Services.Persona
{
    public class PersonaUsuarioService : IPersonaUsuarioRepository
    {
        private readonly string _cadenaSQL = string.Empty;

        public PersonaUsuarioService(IConfiguration configuration)
        {
            _cadenaSQL = configuration.GetConnectionString("UsersAdminConectionSQL");
        }

        public async Task<List<CPersonaUsuario>> GetPersonaUsuario_Seleccionar()
        {
            List<CPersonaUsuario> _result = new List<CPersonaUsuario>();

            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Persona.PersonaUsuario_Seleccionar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        _result = JsonConvert.DeserializeObject<List<CPersonaUsuario>>(dr.GetValue(0).ToString());
                    }
                }
                conexion.Close();
                return _result;
            }
        }
    }
}
