using System;

namespace ClinicaTurnos.Dominio
{
    public class TurnoTrabajo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
    }
}
