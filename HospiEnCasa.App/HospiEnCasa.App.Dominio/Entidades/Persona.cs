using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
      
    public class Persona
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido"), StringLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido"), StringLength(50)]
        public string Apellidos { get; set; }
        public string NumeroTelefono { get; set; }
        public Genero Genero { set; get; }

    }
}
