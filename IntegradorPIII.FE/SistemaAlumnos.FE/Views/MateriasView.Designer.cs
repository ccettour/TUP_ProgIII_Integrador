namespace IntegradorPIII.FE.Views
{
    partial class MateriasView
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
            lblNombre = new Label();
            lblAnio = new Label();
            lblCuatri = new Label();
            tbNombre = new TextBox();
            cbAnio = new ComboBox();
            cbCuatri = new ComboBox();
            btnAgregarMat = new Button();
            btnActualizarMat = new Button();
            btnEliminarMat = new Button();
            dgvMaterias = new DataGridView();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(79, 183, 179);
            lblNombre.Location = new Point(41, 50);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAnio.ForeColor = Color.FromArgb(79, 183, 179);
            lblAnio.Location = new Point(41, 80);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(29, 15);
            lblAnio.TabIndex = 1;
            lblAnio.Text = "Año";
            // 
            // lblCuatri
            // 
            lblCuatri.AutoSize = true;
            lblCuatri.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCuatri.ForeColor = Color.FromArgb(79, 183, 179);
            lblCuatri.Location = new Point(41, 110);
            lblCuatri.Name = "lblCuatri";
            lblCuatri.Size = new Size(74, 15);
            lblCuatri.TabIndex = 1;
            lblCuatri.Text = "Cuatrimestre";
            // 
            // tbNombre
            // 
            tbNombre.Location = new Point(151, 44);
            tbNombre.Margin = new Padding(3, 2, 3, 2);
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new Size(274, 23);
            tbNombre.TabIndex = 2;
            // 
            // cbAnio
            // 
            cbAnio.FormattingEnabled = true;
            cbAnio.Location = new Point(151, 74);
            cbAnio.Margin = new Padding(3, 2, 3, 2);
            cbAnio.Name = "cbAnio";
            cbAnio.Size = new Size(133, 23);
            cbAnio.TabIndex = 3;
            // 
            // cbCuatri
            // 
            cbCuatri.FormattingEnabled = true;
            cbCuatri.Location = new Point(152, 104);
            cbCuatri.Margin = new Padding(3, 2, 3, 2);
            cbCuatri.Name = "cbCuatri";
            cbCuatri.Size = new Size(133, 23);
            cbCuatri.TabIndex = 4;
            // 
            // btnAgregarMat
            // 
            btnAgregarMat.BackColor = Color.FromArgb(99, 122, 185);
            btnAgregarMat.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAgregarMat.ForeColor = Color.Black;
            btnAgregarMat.Location = new Point(555, 43);
            btnAgregarMat.Margin = new Padding(3, 2, 3, 2);
            btnAgregarMat.Name = "btnAgregarMat";
            btnAgregarMat.Size = new Size(93, 34);
            btnAgregarMat.TabIndex = 5;
            btnAgregarMat.Text = "Agregar";
            btnAgregarMat.UseVisualStyleBackColor = false;
            btnAgregarMat.Click += btnAgregarMat_Click;
            // 
            // btnActualizarMat
            // 
            btnActualizarMat.BackColor = Color.FromArgb(99, 122, 185);
            btnActualizarMat.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnActualizarMat.ForeColor = Color.Black;
            btnActualizarMat.Location = new Point(555, 80);
            btnActualizarMat.Margin = new Padding(3, 2, 3, 2);
            btnActualizarMat.Name = "btnActualizarMat";
            btnActualizarMat.Size = new Size(93, 34);
            btnActualizarMat.TabIndex = 5;
            btnActualizarMat.Text = "Actualizar";
            btnActualizarMat.UseVisualStyleBackColor = false;
            btnActualizarMat.Click += btnActualizarMat_Click;
            // 
            // btnEliminarMat
            // 
            btnEliminarMat.BackColor = Color.FromArgb(99, 122, 185);
            btnEliminarMat.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnEliminarMat.ForeColor = Color.Black;
            btnEliminarMat.Location = new Point(555, 118);
            btnEliminarMat.Margin = new Padding(3, 2, 3, 2);
            btnEliminarMat.Name = "btnEliminarMat";
            btnEliminarMat.Size = new Size(93, 34);
            btnEliminarMat.TabIndex = 5;
            btnEliminarMat.Text = "Eliminar";
            btnEliminarMat.UseVisualStyleBackColor = false;
            btnEliminarMat.Click += btnEliminarMat_Click;
            // 
            // dgvMaterias
            // 
            dgvMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterias.Location = new Point(124, 178);
            dgvMaterias.Margin = new Padding(3, 2, 3, 2);
            dgvMaterias.Name = "dgvMaterias";
            dgvMaterias.RowHeadersWidth = 51;
            dgvMaterias.Size = new Size(453, 136);
            dgvMaterias.TabIndex = 6;
            dgvMaterias.CellClick += dgvMaterias_CellClick;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(79, 183, 179);
            lblTitulo.Location = new Point(275, 151);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(160, 25);
            lblTitulo.TabIndex = 8;
            lblTitulo.Text = "Lista de Materias";
            // 
            // MateriasView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 50, 111);
            ClientSize = new Size(700, 338);
            Controls.Add(lblTitulo);
            Controls.Add(dgvMaterias);
            Controls.Add(btnEliminarMat);
            Controls.Add(btnActualizarMat);
            Controls.Add(btnAgregarMat);
            Controls.Add(cbCuatri);
            Controls.Add(cbAnio);
            Controls.Add(tbNombre);
            Controls.Add(lblCuatri);
            Controls.Add(lblAnio);
            Controls.Add(lblNombre);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MateriasView";
            Text = "Materias";
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblAnio;
        private Label lblCuatri;
        private TextBox tbNombre;
        private ComboBox cbAnio;
        private ComboBox cbCuatri;
        private Button btnAgregarMat;
        private Button btnActualizarMat;
        private Button btnEliminarMat;
        private DataGridView dgvMaterias;
        private Label lblTitulo;
    }
}