using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClinicaTurnos.Datos;
using ClinicaTurnos.Dominio;

namespace ClinicaTurnos
{
    public partial class FrmEspecialidadDetalle : Form
    {
        private readonly Especialidad especialidadExistente;

        public FrmEspecialidadDetalle() : this(null)
        {
        }

        public FrmEspecialidadDetalle(Especialidad especialidad)
        {
            InitializeComponent();
            especialidadExistente = especialidad;
            if (especialidadExistente != null)
            {
                Text = "Modificar especialidad";
                txtNombre.Text = especialidadExistente.Nombre;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            if (nombre.Length == 0)
            {
                MessageBox.Show(this, "Ingresá el nombre de la especialidad.", "Especialidades", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }
            Especialidad especialidad = new Especialidad
            {
                Id = especialidadExistente == null ? 0 : especialidadExistente.Id,
                Nombre = nombre
            };
            try
            {
                EspecialidadDatos datos = new EspecialidadDatos();
                if (datos.ExisteNombre(especialidad.Nombre, especialidad.Id))
                {
                    MessageBox.Show(this, "Ya existe una especialidad con ese nombre.", "Especialidades", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }
                if (especialidadExistente == null)
                {
                    datos.Agregar(especialidad);
                }
                else
                {
                    datos.Modificar(especialidad);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show(this, "No se pudieron guardar los cambios. Revisá la base de datos e intentá nuevamente.", "Especialidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
