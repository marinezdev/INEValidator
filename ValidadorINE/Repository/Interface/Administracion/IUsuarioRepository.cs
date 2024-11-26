using ValidadorINE.Areas.Administracion.Models;
using ValidadorINE.Areas.Administracion.Models.Consulta;

namespace ValidadorINE.Repository.Interface.Administracion
{
    public interface IUsuarioRepository
    {
        Task<UsuariodbViewModel> GetAutentificar(UsuarioViewModel usuario);
    }
}
