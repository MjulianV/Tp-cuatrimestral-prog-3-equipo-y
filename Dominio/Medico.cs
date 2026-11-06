using System.Collections.Generic;

namespace ClinicaTurnos.Dominio
{
    public class Medico
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<Especialidad> Especialidades { get; set; }
        public TurnoTrabajo TurnoTrabajo { get; set; }

        public Medico()
        {
            Especialidades = new List<Especialidad>();
        }
    }
}
