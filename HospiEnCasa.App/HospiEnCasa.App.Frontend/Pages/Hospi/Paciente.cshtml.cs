using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class PacienteModel : PageModel
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());

        // Atributos
        public IEnumerable<Paciente> Pacientes {get; set;}

        public Paciente Paciente { get; set; }

        // Metodos
        public void OnGet(int idPaciente)
        {
            Pacientes = _repoPaciente.GetAllPacientes(); 

            Paciente = _repoPaciente.GetPaciente(idPaciente);
            if (Paciente == null)
            {
                RedirectToPage("./NotFound");
            }
            else
            {
                _repoPaciente.DeletePaciente(Paciente.Id);
                Page();
            }           
        }
    }
}
