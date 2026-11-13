using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClinicaTurnos.Datos;
using ClinicaTurnos.Dominio;

namespace ClinicaTurnos
{
    public partial class FrmEspecialidades : Form
    {
        public FrmEspecialidades()
        {
            InitializeComponent();
            Load += FrmEspecialidades_Load;
            dgvEspecialidades.SelectionChanged += dgvEspecialidades_SelectionChanged;
        }

        private void FrmEspecialidades_Load(object sender, EventArgs e)
        {
            CargarEspecialidades();
        }

        private void CargarEspecialidades()
        {
            try
            {
                EspecialidadDatos datos = new EspecialidadDatos();
                dgvEspecialidades.DataSource = datos.Listar();
                btnAgregar.Enabled = true;
            }
            catch (SqlException)
            {
                dgvEspecialidades.DataSource = null;
                btnAgregar.Enabled = false;
                MessageBox.Show(this, "No se pudieron cargar las especialidades. Revisá la base de datos y volvé a abrir esta ventana.", "Especialidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnModificar.Enabled = dgvEspecialidades.SelectedRows.Count > 0;
            btnEliminar.Enabled = dgvEspecialidades.SelectedRows.Count > 0;
        }

        private void dgvEspecialidades_SelectionChanged(object sender, EventArgs e)
        {
            btnModificar.Enabled = dgvEspecialidades.SelectedRows.Count > 0;
            btnEliminar.Enabled = dgvEspecialidades.SelectedRows.Count > 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (FrmEspecialidadDetalle ventana = new FrmEspecialidadDetalle())
            {
                if (ventana.ShowDialog(this) == DialogResult.OK)
                {
                    CargarEspecialidades();
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count == 0)
            {
                return;
            }
            Especialidad seleccionada = dgvEspecialidades.SelectedRows[0].DataBoundItem as Especialidad;
            if (seleccionada == null)
            {
                return;
            }
            using (FrmEspecialidadDetalle ventana = new FrmEspecialidadDetalle(seleccionada))
            {
                if (ventana.ShowDialog(this) == DialogResult.OK)
                {
                    CargarEspecialidades();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count == 0)
            {
                return;
            }
            Especialidad seleccionada = dgvEspecialidades.SelectedRows[0].DataBoundItem as Especialidad;
            if (seleccionada == null)
            {
                return;
            }
            DialogResult respuesta = MessageBox.Show(this, "¿Eliminar la especialidad " + seleccionada.Nombre + "?", "Eliminar especialidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta != DialogResult.Yes)
            {
                return;
            }
            try
            {
                EspecialidadDatos datos = new EspecialidadDatos();
                datos.Eliminar(seleccionada.Id);
            }
            catch (SqlException)
            {
                MessageBox.Show(this, "No se pudo eliminar la especialidad. Revisá la base de datos e intentá nuevamente.", "Especialidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CargarEspecialidades();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
