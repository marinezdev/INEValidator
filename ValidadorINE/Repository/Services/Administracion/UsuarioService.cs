using ValidadorINE.Areas.Administracion.Models;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using ValidadorINE.Repository.Interface.Administracion;
using ValidadorINE.Areas.Administracion.Models.Consulta;


namespace ValidadorINE.Repository.Services.Administracion
{
    public class UsuarioService : IUsuarioRepository
    {
        private readonly string _cadenaSQL = string.Empty;

        public UsuarioService(IConfiguration configuration)
        {
            _cadenaSQL = configuration.GetConnectionString("UsersAdminConectionSQL");
        }

        public async Task<UsuariodbViewModel> GetAutentificar(UsuarioViewModel usuario)
        {
            UsuariodbViewModel _result = new UsuariodbViewModel();

            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Administracion.Usuario_Autentificar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Usuario", usuario.Usuario);
                cmd.Parameters.AddWithValue("Password", usuario.Password);

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        _result = JsonConvert.DeserializeObject<UsuariodbViewModel>(dr.GetValue(0).ToString());
                    }
                }
                conexion.Close();
                return _result;
            }
        }
    }
}
