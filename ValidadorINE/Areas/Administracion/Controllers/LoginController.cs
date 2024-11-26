﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ValidadorINE.Repository.Utilidades;
using ValidadorINE.Repository.Interface.Administracion;
using ValidadorINE.Areas.Administracion.Models;
using ValidadorINE.Areas.Administracion.Models.Consulta;

namespace ValidadorINE.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(ILogger<LoginController> logger, IUsuarioRepository usuarioRepository)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }

        public virtual async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> IniciarSesion([FromBody] UsuarioViewModel usuario)
        {
            usuario.Password = Encriptar.EncriptarClave(usuario.Password);

            UsuariodbViewModel db_usuario = await _usuarioRepository.GetAutentificar(usuario);

            if (db_usuario.Usuario.Id > 0)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Sid, db_usuario.Usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, db_usuario.Persona.Nombre + " " +  db_usuario.Persona.ApellidoPaterno),
                    new Claim(ClaimTypes.Role, db_usuario.Usuario.Cat_Rol.Nombre.ToString())
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    properties
                );
            }

            return Json(db_usuario);
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Administracion");
        }
    }
}
