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
    public class EditModel : PageModel
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());

        public Paciente Paciente { get; set; }

        public IActionResult OnGet(int? idPaciente)
        {
            if (idPaciente.HasValue)
            {
                Paciente = _repoPaciente.GetPaciente(idPaciente.Value);
            }
            else
            {
                Paciente = new Paciente();
            }

            if (Paciente == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Paciente.Id > 0)
            {
                Paciente = _repoPaciente.UpdatePaciente(Paciente);
            }
            else
            {
                _repoPaciente.AddPaciente(Paciente);
            }
            return Page();
        }
    }
}
