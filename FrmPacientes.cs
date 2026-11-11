using System;
using System.Data.SqlClient;
using ClinicaTurnos.Datos;
using System.ComponentModel;
using System.Windows.Forms;
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
