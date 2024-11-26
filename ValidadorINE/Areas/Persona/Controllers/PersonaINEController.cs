using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValidadorINE.Areas.Administracion.Controllers;
using ValidadorINE.Areas.Persona.Models;
using ValidadorINE.Repository.Interface.Administracion;
using ValidadorINE.Repository.Interface.Persona;

namespace ValidadorINE.Areas.Persona.Controllers
{
    [Authorize]
    [Area("Persona")]
    public class PersonaINEController : Controller
    { 
        private readonly ILogger<PersonaINEController> _logger;
        private readonly IPersonaINERepository _personaINERepository; 

        public PersonaINEController(ILogger<PersonaINEController> logger, IPersonaINERepository personaINERepository)
        {
            _logger = logger;
            _personaINERepository = personaINERepository;
        }

        public virtual async Task<IActionResult> INE()
        {
            List<PersonaINEViewModel> Result_PersonaINE = await _personaINERepository.GetPersonaINE_Seleccionar();
            
            ViewBag.PersonaINE = Result_PersonaINE;
            return View();
        }
    }
}
