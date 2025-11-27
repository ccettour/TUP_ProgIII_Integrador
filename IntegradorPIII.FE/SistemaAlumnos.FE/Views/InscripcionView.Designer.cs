namespace IntegradorPIII.FE.Views
{
    partial class InscripcionView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbMaterias = new ComboBox();
            btnInscribir = new Button();
            dgvInscripciones = new DataGridView();
            lblTitulo = new Label();
            lblNombre = new Label();
            btnDesinscribir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).BeginInit();
            SuspendLayout();
            // 
            // cbMaterias
            // 
            cbMaterias.FormattingEnabled = true;
            cbMaterias.Location = new Point(40, 77);
            cbMaterias.Name = "cbMaterias";
            cbMaterias.Size = new Size(145, 23);
            cbMaterias.TabIndex = 0;
            // 
            // btnInscribir
            // 
            btnInscribir.BackColor = Color.FromArgb(99, 122, 185);
            btnInscribir.Location = new Point(218, 70);
            btnInscribir.Name = "btnInscribir";
            btnInscribir.Size = new Size(88, 34);
            btnInscribir.TabIndex = 1;
            btnInscribir.Text = "Inscribir";
            btnInscribir.UseVisualStyleBackColor = false;
            btnInscribir.Click += btnInscribir_Click;
            // 
            // dgvInscripciones
            // 
            dgvInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInscripciones.Location = new Point(34, 168);
            dgvInscripciones.Name = "dgvInscripciones";
            dgvInscripciones.RowHeadersWidth = 51;
            dgvInscripciones.Size = new Size(553, 150);
            dgvInscripciones.TabIndex = 2;
            dgvInscripciones.CellClick += dgvInscripciones_CellClick;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(79, 183, 179);
            lblTitulo.Location = new Point(219, 137);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(160, 25);
            lblTitulo.TabIndex = 8;
            lblTitulo.Text = "Lista de Materias";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = Color.FromArgb(79, 183, 179);
            lblNombre.Location = new Point(40, 44);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(78, 25);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Alumno";
            // 
            // btnDesinscribir
            // 
            btnDesinscribir.BackColor = Color.FromArgb(99, 122, 185);
            btnDesinscribir.Location = new Point(600, 230);
            btnDesinscribir.Name = "btnDesinscribir";
            btnDesinscribir.Size = new Size(88, 34);
            btnDesinscribir.TabIndex = 10;
            btnDesinscribir.Text = "Desinscribir";
            btnDesinscribir.UseVisualStyleBackColor = false;
            btnDesinscribir.Click += btnDesinscribir_Click;
            // 
            // InscripcionView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 50, 111);
            ClientSize = new Size(700, 338);
            Controls.Add(btnDesinscribir);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Controls.Add(dgvInscripciones);
            Controls.Add(btnInscribir);
            Controls.Add(cbMaterias);
            Name = "InscripcionView";
            Text = "Inscripción";
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbMaterias;
        private Button btnInscribir;
        private DataGridView dgvInscripciones;
        private Label lblTitulo;
        private Label lblNombre;
        private Button btnDesinscribir;
    }
}