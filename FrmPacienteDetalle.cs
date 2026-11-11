using System;
using System.Data.SqlClient;
using ClinicaTurnos.Datos;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ClinicaTurnos.Dominio;

namespace ClinicaTurnos
{
    public partial class FrmPacienteDetalle : Form
    {
        public Paciente DatosPaciente { get; private set; }

        public FrmPacienteDetalle()
        {
            InitializeComponent();
            dtpFechaNacimiento.MaxDate = DateTime.Today;
            txtDni.KeyPress += SoloNumeros_KeyPress;
            txtTelefono.KeyPress += SoloNumeros_KeyPress;
            txtNombre.KeyPress += SoloLetras_KeyPress;
            txtApellido.KeyPress += SoloLetras_KeyPress;
            btnGuardar.Click += btnGuardar_Click;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }

        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            DatosPaciente = new Paciente
            {
                Dni = txtDni.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value.Date,
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim()
            };

            try
            {
                PacienteDatos datos = new PacienteDatos();
                datos.Agregar(DatosPaciente);
            }
            catch (SqlException)
            {
                MessageBox.Show("No se pudo guardar el paciente. Revisá la conexión con la base de datos e intentá nuevamente.", "Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidarCampos()
        {
            errores.Clear();
            bool valido = true;
            string dni = txtDni.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string correo = txtEmail.Text.Trim();

            if (dni.Length == 0)
            {
                errores.SetError(txtDni, "Ingresá el DNI.");
                valido = false;
            }
            else if (!Regex.IsMatch(dni, @"^[0-9]+$"))
            {
                errores.SetError(txtDni, "El DNI debe tener solo números.");
                valido = false;
            }

            if (nombre.Length == 0)
            {
                errores.SetError(txtNombre, "Ingresá el nombre.");
                valido = false;
            }
            else if (!Regex.IsMatch(nombre, @"^[\p{L} ]+$"))
            {
                errores.SetError(txtNombre, "El nombre debe tener solo letras.");
                valido = false;
            }

            if (apellido.Length == 0)
            {
                errores.SetError(txtApellido, "Ingresá el apellido.");
                valido = false;
            }
            else if (!Regex.IsMatch(apellido, @"^[\p{L} ]+$"))
            {
                errores.SetError(txtApellido, "El apellido debe tener solo letras.");
                valido = false;
            }

            if (telefono.Length > 0 && !Regex.IsMatch(telefono, @"^[0-9]+$"))
            {
                errores.SetError(txtTelefono, "El teléfono debe tener solo números.");
                valido = false;
            }

            if (correo.Length == 0)
            {
                errores.SetError(txtEmail, "Ingresá el correo electrónico.");
                valido = false;
            }
            else if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errores.SetError(txtEmail, "Ingresá un correo válido, como nombre@ejemplo.com.");
                valido = false;
            }

            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
