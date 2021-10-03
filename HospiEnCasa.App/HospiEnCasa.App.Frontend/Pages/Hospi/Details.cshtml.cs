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
    public class DetailsModel : PageModel
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());

        // Atributos
        public Paciente Paciente { get; set; }
        
        // Metodos
        public IActionResult OnGet(int idPaciente)
        {
            Paciente = _repoPaciente.GetPaciente(idPaciente);

            if (Paciente == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
