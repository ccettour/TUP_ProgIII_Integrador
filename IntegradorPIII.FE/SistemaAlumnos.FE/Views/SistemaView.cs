using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegradorPIII.FE.Views
{
    public partial class SistemaView : Form
    {
        public SistemaView()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnGAlumnos_Click(object sender, EventArgs e)
        {
            AlumnosView alumnosView = new AlumnosView();
            alumnosView.ShowDialog();
        }

        private void btnGMaterias_Click(object sender, EventArgs e)
        {
            MateriasView materiasView = new MateriasView();
            materiasView.ShowDialog();
        }

        private void SistemaView_Load(object sender, EventArgs e)
        {

        }
    }
}
