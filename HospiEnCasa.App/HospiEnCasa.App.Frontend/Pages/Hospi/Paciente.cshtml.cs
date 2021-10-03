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
        [BindProperty(SupportsGet = true)]
        public string FiltroBusqueda { get; set; }

        public IEnumerable<Paciente> Pacientes {get; set;}

        public Paciente Paciente { get; set; }

        // Metodos
        public void OnGet(int idPaciente, string filtroBusqueda)
        {
            // Pacientes = _repoPaciente.GetAllPacientes();

            FiltroBusqueda = filtroBusqueda;

            Pacientes = _repoPaciente.GetPacientePorFiltro(filtroBusqueda); 

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
