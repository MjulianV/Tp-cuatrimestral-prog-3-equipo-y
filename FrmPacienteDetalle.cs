using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClinicaTurnos
{
    public partial class FrmPacienteDetalle : Form
    {
        public FrmPacienteDetalle()
        {
            InitializeComponent();
            dtpFechaNacimiento.MaxDate = DateTime.Today;
            txtDni.TextChanged += txtDni_TextChanged;
            txtEmail.TextChanged += txtEmail_TextChanged;
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            bool tieneLetrasOSimbolos = Regex.IsMatch(txtDni.Text, "[^0-9]");
            errores.SetError(txtDni, tieneLetrasOSimbolos ? "Ingresá el DNI solo con números." : "");
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string correo = txtEmail.Text.Trim();
            bool formatoIncorrecto = correo.Length > 0 && !Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            errores.SetError(txtEmail, formatoIncorrecto ? "Ingresá un correo como nombre@ejemplo.com." : "");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
