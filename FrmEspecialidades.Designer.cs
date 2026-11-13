namespace ClinicaTurnos
{
    partial class FrmEspecialidades
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblEspecialidades = new System.Windows.Forms.Label();
            this.dgvEspecialidades = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).BeginInit();
            this.SuspendLayout();
            this.lblEspecialidades.AutoSize = true;
            this.lblEspecialidades.Location = new System.Drawing.Point(12, 15);
            this.lblEspecialidades.Name = "lblEspecialidades";
            this.lblEspecialidades.Size = new System.Drawing.Size(128, 13);
            this.lblEspecialidades.TabIndex = 0;
            this.lblEspecialidades.Text = "Listado de especialidades";
            this.dgvEspecialidades.AllowUserToAddRows = false;
            this.dgvEspecialidades.AllowUserToDeleteRows = false;
            this.dgvEspecialidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEspecialidades.AutoGenerateColumns = false;
            this.dgvEspecialidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEspecialidades.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEspecialidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId, this.colNombre});
            this.dgvEspecialidades.Location = new System.Drawing.Point(12, 40);
            this.dgvEspecialidades.MultiSelect = false;
            this.dgvEspecialidades.Name = "dgvEspecialidades";
            this.dgvEspecialidades.ReadOnly = true;
            this.dgvEspecialidades.RowHeadersVisible = false;
            this.dgvEspecialidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEspecialidades.Size = new System.Drawing.Size(796, 350);
            this.dgvEspecialidades.TabIndex = 1;
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Código";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.FillWeight = 40F;
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.HeaderText = "Especialidad";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.Location = new System.Drawing.Point(12, 408);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 30);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnModificar.Enabled = false;
            this.btnModificar.Location = new System.Drawing.Point(114, 408);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 30);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(216, 408);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(718, 408);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(90, 30);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(820, 450);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvEspecialidades);
            this.Controls.Add(this.lblEspecialidades);
            this.MinimumSize = new System.Drawing.Size(680, 360);
            this.Name = "FrmEspecialidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Especialidades";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblEspecialidades;
        private System.Windows.Forms.DataGridView dgvEspecialidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCerrar;
    }
}
