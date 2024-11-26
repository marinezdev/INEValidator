using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValidadorINE.Areas.Administracion.Controllers;
using ValidadorINE.Areas.Persona.Models.Consulta;
using ValidadorINE.Repository.Interface.Administracion;
using ValidadorINE.Repository.Interface.Persona;

namespace ValidadorINE.Areas.Persona.Controllers
{
    [Authorize]
    [Area("Persona")]
    public class PersonaUsuarioController : Controller
    {
        private readonly ILogger<PersonaUsuarioController> _logger;
        private readonly IPersonaUsuarioRepository _personaUsuarioRepository;

        public PersonaUsuarioController(ILogger<PersonaUsuarioController> logger, IPersonaUsuarioRepository personaUsuarioRepository)
        {
            _logger = logger;
            _personaUsuarioRepository = personaUsuarioRepository;
        }
        // GET: PersonaUsuarioController
        public virtual async Task<IActionResult> Index()
        {
            List<CPersonaUsuario> db_PersonaUsuario = await _personaUsuarioRepository.GetPersonaUsuario_Seleccionar();

            ViewBag.Persona = db_PersonaUsuario;
            return View();
        }

    }
}
