using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using ClinicaTurnos.Dominio;

namespace ClinicaTurnos.Datos
{
    public class EspecialidadDatos
    {
        private readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["ClinicaTurnos"].ConnectionString;

        public List<Especialidad> Listar()
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            using (SqlCommand comando = new SqlCommand("SELECT Id, Nombre FROM dbo.Especialidades ORDER BY Nombre", conexion))
            {
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Especialidad especialidad = new Especialidad
                        {
                            Id = (int)lector["Id"],
                            Nombre = (string)lector["Nombre"]
                        };
                        especialidades.Add(especialidad);
                    }
                }
            }

            return especialidades;
        }
    }
}
