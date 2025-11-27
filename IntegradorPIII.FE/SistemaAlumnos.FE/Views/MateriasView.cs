using IntegradorPIII.FE.Models;
using IntegradorPIII.FE.Services;
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
    public partial class MateriasView : Form
    {
        private readonly MateriaService _service;
        private int _idSeleccionado = 0;
        public MateriasView()
        {
            InitializeComponent();
            inicializarComboAnio();
            inicializarComboCuatri();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Configuración del DataGridView
            dgvMaterias.ReadOnly = true;
            dgvMaterias.AllowUserToAddRows = false;
            dgvMaterias.AllowUserToDeleteRows = false;
            dgvMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterias.MultiSelect = false;

            btnActualizarMat.Enabled = false;
            btnEliminarMat.Enabled = false;
            btnAgregarMat.Enabled = true;

            // Configurar HttpClient (ignorar certificado para pruebas locales)
            var handler = new System.Net.Http.HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            var httpClient = new System.Net.Http.HttpClient(handler)
            {
                BaseAddress = new Uri("http://localhost:5038/")
            };

            _service = new MateriaService(httpClient);

            // Cargar datos al iniciar
            _ = CargarMateriasAsync();
        }

        private async Task CargarMateriasAsync()
        {
            dgvMaterias.DataSource = await _service.ObtenerMateriasAsync();

            // Personalizar encabezados
            dgvMaterias.Columns["Id"].HeaderText = "Código";
            dgvMaterias.Columns["Nombre"].HeaderText = "Nombre";
            dgvMaterias.Columns["Anio"].HeaderText = "Año";
            dgvMaterias.Columns["Cuatrimestre"].HeaderText = "Cuatrimestre";
        }

        private void LimpiarCampos()
        {
            tbNombre.Clear();
            cbAnio.SelectedIndex = -1;
            cbCuatri.SelectedIndex = -1;
            _idSeleccionado = 0;

            btnAgregarMat.Enabled = true;
            btnActualizarMat.Enabled = false;
            btnEliminarMat.Enabled = false;
        }


        private void inicializarComboAnio()
        {
            cbAnio.Items.Add(1);
            cbAnio.Items.Add(2);
            cbAnio.Items.Add(3);
            cbAnio.Items.Add(4);
            cbAnio.Items.Add(5);
        }

        private void inicializarComboCuatri()
        {
            cbCuatri.Items.Add(1);
            cbCuatri.Items.Add(2);
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMaterias.Rows[e.RowIndex];
                tbNombre.Text = row.Cells["Nombre"].Value?.ToString();
                cbAnio.SelectedItem = Convert.ToInt32(row.Cells["Anio"].Value);
                cbCuatri.SelectedItem = Convert.ToInt32(row.Cells["Cuatrimestre"].Value);
                _idSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);

                btnAgregarMat.Enabled = false; // Desactiva Agregar
                btnActualizarMat.Enabled = true;
                btnEliminarMat.Enabled = true;
            }
        }

        private async void btnActualizarMat_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione una materia para actualizar");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbNombre.Text) ||
                cbAnio.SelectedIndex == -1 ||
                cbCuatri.SelectedIndex == -1)
            {
                MessageBox.Show("Nombre, Año y Cuatrimestre son obligatorios");
                return;
            }

            var materiaActualizada = new Materia
            {
                Id = _idSeleccionado,
                Nombre = tbNombre.Text,
                Anio = Convert.ToInt32(cbAnio.SelectedItem),
                Cuatrimestre = Convert.ToInt32(cbCuatri.SelectedItem)
            };

            bool exito = await _service.ActualizarMateriaAsync(materiaActualizada);
            
            MessageBox.Show(exito ? "Materia actualizada correctamente" : "Error al actualizar materia");
            await CargarMateriasAsync();
            LimpiarCampos();
        }

        private async void btnEliminarMat_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione una materia para eliminar");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar esta materia?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bool exito = await _service.EliminarMateriaAsync(_idSeleccionado);
                MessageBox.Show(exito ? "Materia eliminada correctamente" : "Error al eliminar materia");
                await CargarMateriasAsync();
                LimpiarCampos();
            }
        }

        private async void btnAgregarMat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNombre.Text) ||
        cbAnio.SelectedIndex == -1 ||
        cbCuatri.SelectedIndex == -1)
            {
                MessageBox.Show("Nombre, Año y Cuatrimestre son obligatorios");
                return;
            }

            var nuevaMateria = new Materia
            {
                Nombre = tbNombre.Text,
                Anio = Convert.ToInt32(cbAnio.SelectedItem),
                Cuatrimestre = Convert.ToInt32(cbCuatri.SelectedItem)
            };

            bool exito = await _service.AgregarMateriaAsync(nuevaMateria);
            MessageBox.Show(exito ? "Materia agregada correctamente" : "Error al agregar materia");
            await CargarMateriasAsync();
            LimpiarCampos();
        }
    }
}
