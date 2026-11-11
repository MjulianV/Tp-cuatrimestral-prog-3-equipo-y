using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClinicaTurnos.Datos;
using ClinicaTurnos.Dominio;

namespace ClinicaTurnos
{
    public partial class FrmPacientes : Form
    {
        private readonly BindingList<Paciente> pacientes = new BindingList<Paciente>();

        public FrmPacientes()
        {
            InitializeComponent();
            dgvPacientes.DataSource = pacientes;
            Load += FrmPacientes_Load;
            dgvPacientes.SelectionChanged += dgvPacientes_SelectionChanged;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void FrmPacientes_Load(object sender, EventArgs e)
        {
            try
            {
                PacienteDatos datos = new PacienteDatos();
                foreach (Paciente paciente in datos.Listar())
                {
                    pacientes.Add(paciente);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("No se pudieron cargar los pacientes. Revisá la conexión con la base de datos y volvé a abrir esta ventana.", "Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAgregar.Enabled = false;
            }
        }

        private void dgvPacientes_SelectionChanged(object sender, EventArgs e)
        {
            btnModificar.Enabled = dgvPacientes.SelectedRows.Count > 0;
            btnEliminar.Enabled = dgvPacientes.SelectedRows.Count > 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (FrmPacienteDetalle ventana = new FrmPacienteDetalle())
            {
                if (ventana.ShowDialog(this) == DialogResult.OK)
                {
                    pacientes.Add(ventana.DatosPaciente);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
            {
                return;
            }

            Paciente pacienteSeleccionado = dgvPacientes.SelectedRows[0].DataBoundItem as Paciente;
            if (pacienteSeleccionado == null)
            {
                return;
            }

            using (FrmPacienteDetalle ventana = new FrmPacienteDetalle(pacienteSeleccionado))
            {
                if (ventana.ShowDialog(this) == DialogResult.OK)
                {
                    int indice = pacientes.IndexOf(pacienteSeleccionado);
                    if (indice >= 0)
                    {
                        pacientes[indice] = ventana.DatosPaciente;
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
            {
                return;
            }

            Paciente pacienteSeleccionado = dgvPacientes.SelectedRows[0].DataBoundItem as Paciente;
            if (pacienteSeleccionado == null)
            {
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Eliminar al paciente " + pacienteSeleccionado.Nombre + " " + pacienteSeleccionado.Apellido + "?", "Eliminar paciente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                PacienteDatos datos = new PacienteDatos();
                datos.Eliminar(pacienteSeleccionado.Id);
                pacientes.Remove(pacienteSeleccionado);
            }
            catch (SqlException)
            {
                MessageBox.Show("No se pudo eliminar el paciente. Revisá la conexión con la base de datos e intentá nuevamente.", "Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
