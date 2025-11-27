namespace IntegradorPIII.FE
{
    partial class AlumnosView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtLegajo = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            btnAgregarAlum = new Button();
            dgvAlumnos = new DataGridView();
            lblNombre = new Label();
            lblApellido = new Label();
            lblLegajo = new Label();
            lblFechaNac = new Label();
            btnActualizarAlum = new Button();
            btnEliminarAlum = new Button();
            lblTitulo = new Label();
            btnInscribir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(123, 22);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(266, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(123, 51);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(266, 23);
            txtApellido.TabIndex = 1;
            // 
            // txtLegajo
            // 
            txtLegajo.Location = new Point(123, 80);
            txtLegajo.Name = "txtLegajo";
            txtLegajo.Size = new Size(266, 23);
            txtLegajo.TabIndex = 2;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(123, 109);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(266, 23);
            dtpFechaNacimiento.TabIndex = 3;
            // 
            // btnAgregarAlum
            // 
            btnAgregarAlum.BackColor = Color.FromArgb(99, 122, 185);
            btnAgregarAlum.ForeColor = Color.Black;
            btnAgregarAlum.Location = new Point(535, 22);
            btnAgregarAlum.Name = "btnAgregarAlum";
            btnAgregarAlum.Size = new Size(124, 34);
            btnAgregarAlum.TabIndex = 4;
            btnAgregarAlum.Text = "Agregar";
            btnAgregarAlum.UseVisualStyleBackColor = false;
            btnAgregarAlum.Click += btnAgregar_Click;
            // 
            // dgvAlumnos
            // 
            dgvAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlumnos.Location = new Point(38, 184);
            dgvAlumnos.Name = "dgvAlumnos";
            dgvAlumnos.RowHeadersWidth = 51;
            dgvAlumnos.Size = new Size(553, 150);
            dgvAlumnos.TabIndex = 3;
            dgvAlumnos.CellClick += dgvAlumnos_CellClick;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(79, 183, 179);
            lblNombre.Location = new Point(41, 25);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblApellido.ForeColor = Color.FromArgb(79, 183, 179);
            lblApellido.Location = new Point(41, 54);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 4;
            lblApellido.Text = "Apellido";
            // 
            // lblLegajo
            // 
            lblLegajo.AutoSize = true;
            lblLegajo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblLegajo.ForeColor = Color.FromArgb(79, 183, 179);
            lblLegajo.Location = new Point(41, 82);
            lblLegajo.Name = "lblLegajo";
            lblLegajo.Size = new Size(42, 15);
            lblLegajo.TabIndex = 4;
            lblLegajo.Text = "Legajo";
            // 
            // lblFechaNac
            // 
            lblFechaNac.AutoSize = true;
            lblFechaNac.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblFechaNac.ForeColor = Color.FromArgb(79, 183, 179);
            lblFechaNac.Location = new Point(41, 115);
            lblFechaNac.Name = "lblFechaNac";
            lblFechaNac.Size = new Size(65, 15);
            lblFechaNac.TabIndex = 4;
            lblFechaNac.Text = "Fecha Nac.";
            // 
            // btnActualizarAlum
            // 
            btnActualizarAlum.BackColor = Color.FromArgb(99, 122, 185);
            btnActualizarAlum.ForeColor = Color.Black;
            btnActualizarAlum.Location = new Point(535, 62);
            btnActualizarAlum.Name = "btnActualizarAlum";
            btnActualizarAlum.Size = new Size(124, 34);
            btnActualizarAlum.TabIndex = 5;
            btnActualizarAlum.Text = "Actualizar";
            btnActualizarAlum.UseVisualStyleBackColor = false;
            btnActualizarAlum.Click += btnActualizar_Click;
            // 
            // btnEliminarAlum
            // 
            btnEliminarAlum.BackColor = Color.FromArgb(99, 122, 185);
            btnEliminarAlum.ForeColor = Color.Black;
            btnEliminarAlum.Location = new Point(535, 102);
            btnEliminarAlum.Name = "btnEliminarAlum";
            btnEliminarAlum.Size = new Size(124, 34);
            btnEliminarAlum.TabIndex = 6;
            btnEliminarAlum.Text = "Eliminar";
            btnEliminarAlum.UseVisualStyleBackColor = false;
            btnEliminarAlum.Click += btnEliminar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(79, 183, 179);
            lblTitulo.Location = new Point(240, 156);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(163, 25);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "Lista de Alumnos";
            // 
            // btnInscribir
            // 
            btnInscribir.BackColor = Color.FromArgb(99, 122, 185);
            btnInscribir.Location = new Point(605, 237);
            btnInscribir.Name = "btnInscribir";
            btnInscribir.Size = new Size(93, 34);
            btnInscribir.TabIndex = 8;
            btnInscribir.Text = "Inscribir";
            btnInscribir.UseVisualStyleBackColor = false;
            btnInscribir.Click += btnInscribir_Click;
            // 
            // AlumnosView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 50, 111);
            ClientSize = new Size(699, 344);
            Controls.Add(btnInscribir);
            Controls.Add(lblTitulo);
            Controls.Add(btnEliminarAlum);
            Controls.Add(btnActualizarAlum);
            Controls.Add(lblFechaNac);
            Controls.Add(lblLegajo);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(dgvAlumnos);
            Controls.Add(btnAgregarAlum);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtLegajo);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Name = "AlumnosView";
            Text = "Getión de Alumnos";
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtLegajo;
        private DateTimePicker dtpFechaNacimiento;
        private Button btnAgregarAlum;
        private DataGridView dgvAlumnos;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblLegajo;
        private Label lblFechaNac;
        private Button btnActualizarAlum;
        private Button btnEliminarAlum;
        private Label lblTitulo;
        private Button btnInscribir;
    }
}
