using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClinicaTurnos.Datos;

namespace ClinicaTurnos
{
    public partial class FrmEspecialidades : Form
    {
        public FrmEspecialidades()
        {
            InitializeComponent();
            Load += FrmEspecialidades_Load;
        }

        private void FrmEspecialidades_Load(object sender, EventArgs e)
        {
            try
            {
                EspecialidadDatos datos = new EspecialidadDatos();
                dgvEspecialidades.DataSource = datos.Listar();
            }
            catch (SqlException)
            {
                MessageBox.Show("No se pudieron cargar las especialidades. Revisá la conexión con la base de datos y volvé a abrir esta ventana.", "Especialidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
