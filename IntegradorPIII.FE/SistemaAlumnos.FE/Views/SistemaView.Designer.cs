namespace IntegradorPIII.FE.Views
{
    partial class SistemaView
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
            btnGAlumnos = new Button();
            btnGMaterias = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnGAlumnos
            // 
            btnGAlumnos.BackColor = Color.FromArgb(99, 122, 185);
            btnGAlumnos.Location = new Point(172, 229);
            btnGAlumnos.Margin = new Padding(3, 2, 3, 2);
            btnGAlumnos.Name = "btnGAlumnos";
            btnGAlumnos.Size = new Size(142, 32);
            btnGAlumnos.TabIndex = 0;
            btnGAlumnos.Text = "Gestión de Alumnos";
            btnGAlumnos.UseVisualStyleBackColor = false;
            btnGAlumnos.Click += btnGAlumnos_Click;
            // 
            // btnGMaterias
            // 
            btnGMaterias.BackColor = Color.FromArgb(99, 122, 185);
            btnGMaterias.Location = new Point(404, 229);
            btnGMaterias.Margin = new Padding(3, 2, 3, 2);
            btnGMaterias.Name = "btnGMaterias";
            btnGMaterias.Size = new Size(142, 32);
            btnGMaterias.TabIndex = 0;
            btnGMaterias.Text = "Gestión de Materias";
            btnGMaterias.UseVisualStyleBackColor = false;
            btnGMaterias.Click += btnGMaterias_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(79, 183, 179);
            label1.Location = new Point(233, 106);
            label1.Name = "label1";
            label1.Size = new Size(239, 30);
            label1.TabIndex = 1;
            label1.Text = "SISTEMA DE GESTIÓN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(79, 183, 179);
            label2.Location = new Point(211, 140);
            label2.Name = "label2";
            label2.Size = new Size(288, 30);
            label2.TabIndex = 1;
            label2.Text = "DE ALUMNOS Y MATERIAS";
            // 
            // SistemaView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 50, 111);
            ClientSize = new Size(700, 338);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGMaterias);
            Controls.Add(btnGAlumnos);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SistemaView";
            Text = "SistemaView";
            Load += SistemaView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGAlumnos;
        private Button btnGMaterias;
        private Label label1;
        private Label label2;
    }
}