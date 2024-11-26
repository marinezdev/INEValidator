using ValidadorINE.Areas.Operacion.Models;

namespace ValidadorINE.Areas.Persona.Models
{
    public class PersonaINEViewModel
    {
        public PersonaViewModel? Persona { get; set; }
        public int Id { get; set; } 
        public string? Domicilio { get; set; }
        public string? ClaveElector { get; set; }
        public string? CURP { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Sexo { get; set; }
        public int YearRegistro { get; set; }
        public int Estado { get; set; }
        public int Municipio { get; set; }
        public int Seccion { get; set; }
        public int Localidad { get; set; }
        public int Emision { get; set; }
        public int Vigencia { get; set; }


    }
}
