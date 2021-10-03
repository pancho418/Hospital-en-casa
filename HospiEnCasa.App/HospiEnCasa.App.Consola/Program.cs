using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // AddPaciente();
            // BuscarPaciente(1);
            // TodosPacientes();
        }

        private static void AddPaciente()
        {
            var paciente = new Paciente
            {
                Nombre = "Jesus",
                Apellidos = "Mauricio",
                NumeroTelefono = "310000000",
                Genero = Genero.Masculino,
                Direccion = "Calle 1 2-3",
                Longitud = 5.07062F,
                Latitud = -75.52290F,
                Ciudad = "Neiva",
                FechaNacimiento = new DateTime(1990, 08, 12)
            };
            _repoPaciente.AddPaciente(paciente);
        }

        private static void BuscarPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            Console.WriteLine(paciente.Nombre + " " + paciente.Apellidos);
        }
        
        private static void TodosPacientes()
        {
            var pacientes = _repoPaciente.GetAllPacientes();
            
            foreach (var paciente in pacientes)
            {
                Console.WriteLine(paciente.Nombre + " " + paciente.Apellidos);
                Console.WriteLine(paciente.Genero);
            }

            
        }
    }
}
