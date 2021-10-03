using System;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
     
    public class Paciente : Persona
    {
        [Required(ErrorMessage = "El campo {0} es requerido"), StringLength(50)]
        public string Direccion { get; set; }

        [Required]
        public float Latitud { get; set; }

        [Required]
        public float Longitud { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido"), StringLength(50)]
        public string Ciudad { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }
        public FamiliarDesignado Familiar { get; set; }
        public Enfermera Enfermera { get; set; }
        public Medico Medico { get; set; }
        public Historia Historia { get; set; }
        public System.Collections.Generic.List<SignoVital> SignosVitales { get; set; }
    }
}
