using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ClinicaTurnos.Dominio;

namespace ClinicaTurnos.Datos
{
    public class PacienteDatos
    {
        private readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["ClinicaTurnos"].ConnectionString;

        public List<Paciente> Listar()
        {
            List<Paciente> pacientes = new List<Paciente>();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            using (SqlCommand comando = new SqlCommand("SELECT Id, Dni, Nombre, Apellido, FechaNacimiento, Telefono, Email, Direccion FROM dbo.Pacientes ORDER BY Apellido, Nombre, Id", conexion))
            {
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Paciente paciente = new Paciente
                        {
                            Id = (int)lector["Id"],
                            Dni = (string)lector["Dni"],
                            Nombre = (string)lector["Nombre"],
                            Apellido = (string)lector["Apellido"],
                            FechaNacimiento = (DateTime)lector["FechaNacimiento"],
                            Telefono = (string)lector["Telefono"],
                            Email = (string)lector["Email"],
                            Direccion = (string)lector["Direccion"]
                        };
                        pacientes.Add(paciente);
                    }
                }
            }

            return pacientes;
        }

        public void Agregar(Paciente paciente)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            using (SqlCommand comando = new SqlCommand("INSERT INTO dbo.Pacientes (Dni, Nombre, Apellido, FechaNacimiento, Telefono, Email, Direccion) OUTPUT INSERTED.Id VALUES (@Dni, @Nombre, @Apellido, @FechaNacimiento, @Telefono, @Email, @Direccion)", conexion))
            {
                comando.Parameters.Add("@Dni", SqlDbType.NVarChar, 20).Value = paciente.Dni;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 80).Value = paciente.Nombre;
                comando.Parameters.Add("@Apellido", SqlDbType.NVarChar, 80).Value = paciente.Apellido;
                comando.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = paciente.FechaNacimiento.Date;
                comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 30).Value = paciente.Telefono;
                comando.Parameters.Add("@Email", SqlDbType.NVarChar, 254).Value = paciente.Email;
                comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 250).Value = paciente.Direccion;
                conexion.Open();
                paciente.Id = (int)comando.ExecuteScalar();
            }
        }
    }
}
