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

        // Atributos
        public Paciente paciente { get; set; }

        // Constructor
        // public EditModel(IRepositorioPaciente repoPaciente)
        // {
        //     repoPaciente = _repoPaciente;
        // }

        // Metodos
        public IActionResult OnGet(int? idPaciente)
        {
            if (idPaciente.HasValue)
            {
                paciente = _repoPaciente.GetPaciente(idPaciente.Value);
            }
            else
            {
                paciente = new Paciente();
            }

            if (paciente == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }

        }

        public IActionResult OnPost(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                if (paciente.Id > 0)
                {
                    paciente = _repoPaciente.UpdatePaciente(paciente);
                }
                else
                {
                    _repoPaciente.AddPaciente(paciente);
                }
                return RedirectToPage("./Paciente");
            }
            else
            {
                return Page();
            }
        }
    }
}
