using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using IntegradorPIII.FE.Models;
using IntegradorPIII.FE.Services;

namespace IntegradorPIII.FE.Views
{
    public partial class InscripcionView : Form
    {
        private readonly MateriaService _materiaService;
        private readonly InscripcionService _inscripcionService;

        private List<Materia> _listaMaterias;
        private readonly Alumno _alumnoActual;
        private int _idSeleccionado = 0;

        public InscripcionView(Alumno alumno)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            var handler = new System.Net.Http.HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            var httpClient = new System.Net.Http.HttpClient(handler)
            {
                BaseAddress = new Uri("http://localhost:5038/")
            };

            _materiaService = new MateriaService(httpClient);
            _inscripcionService = new InscripcionService(httpClient);

            cargaMaterias();
            CargarMateriasAsync();

            _alumnoActual = alumno;

            lblNombre.Text = $"{_alumnoActual.Apellido}, {_alumnoActual.Nombre}";
        }

        private class MateriaInscripcionDTO
        {
            public int InscripcionId { get; set; }
            public int MateriaId { get; set; }
            public string Nombre { get; set; }
            public int Anio { get; set; }
            public int Cuatrimestre { get; set; }
            public DateTime FechaInscripcion { get; set; }
        }

        private async Task CargarMateriasAsync()
        {
            try
            {
                var inscripciones = await _inscripcionService.ObtenerInscripcionesAsync();

                var inscripcionesDelAlumno = inscripciones
                    .Where(i => i.AlumnoId == _alumnoActual.Id)
                    .ToList();

                if (inscripcionesDelAlumno.Count == 0)
                {
                    dgvInscripciones.DataSource = null;
                    return;
                }

                var todasLasMaterias = await _materiaService.ObtenerMateriasAsync();

                var materiasDelAlumno = (
                    from ins in inscripcionesDelAlumno
                    join mat in todasLasMaterias on ins.MateriaId equals mat.Id
                    select new MateriaInscripcionDTO
                    {
                        InscripcionId = ins.Id,
                        MateriaId = mat.Id,
                        Nombre = mat.Nombre,
                        Anio = mat.Anio,
                        Cuatrimestre = mat.Cuatrimestre,
                        FechaInscripcion = ins.FechaInscripcion
                    }
                ).ToList();

                dgvInscripciones.DataSource = materiasDelAlumno;

                // Personalizar encabezados
                dgvInscripciones.Columns["InscripcionId"].Visible = false;
                dgvInscripciones.Columns["MateriaId"].HeaderText = "Código";
                dgvInscripciones.Columns["Nombre"].HeaderText = "Nombre";
                dgvInscripciones.Columns["Anio"].HeaderText = "Año";
                dgvInscripciones.Columns["Cuatrimestre"].HeaderText = "Cuatrimestre";
                dgvInscripciones.Columns["FechaInscripcion"].HeaderText = "Fecha de Inscripción";

                // Formato de fecha
                dgvInscripciones.Columns["FechaInscripcion"].DefaultCellStyle.Format = "dd/MM/yyyy";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar inscripciones: " + ex.Message);
            }
        }

        private async void cargaMaterias()
        {
            try
            {
                _listaMaterias = await _materiaService.ObtenerMateriasAsync();

                cbMaterias.Items.Clear();

                cbMaterias.DisplayMember = "Nombre";

                foreach (var materia in _listaMaterias)
                {
                    cbMaterias.Items.Add(materia);
                }

                if (_listaMaterias.Count > 0)
                {
                    cbMaterias.Enabled = true;
                    cbMaterias.SelectedIndex = 0;
                    btnInscribir.Enabled = true;
                }
                else
                {
                    cbMaterias.Enabled = false;
                    btnInscribir.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar materias: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnInscribir_Click(object sender, EventArgs e)
        {
            if (cbMaterias.SelectedItem is not Materia materiaSeleccionada)
            {
                MessageBox.Show("Debe seleccionar una materia.");
                return;
            }

            var inscripcion = new Inscripcion
            {
                AlumnoId = _alumnoActual.Id,
                MateriaId = materiaSeleccionada.Id,
                FechaInscripcion = DateTime.Now
            };

            var (exito, mensaje) = await _inscripcionService.InscribirAlumnoAsync(inscripcion);

            if (!exito)
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Inscripción exitosa!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarMateriasAsync();
            LimpiarCampos();
        }

        private async void btnDesinscribir_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione una materia para anular la inscripción");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar la inscripción a esta materia?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bool exito = await _inscripcionService.EliminarInscripcionAsync(_idSeleccionado);
                
                await CargarMateriasAsync();
                LimpiarCampos();
                MessageBox.Show(exito ? "Inscripción eliminada correctamente" : "Error al eliminar inscripción");
            }
        }

        private void LimpiarCampos()
        {
            cbMaterias.SelectedIndex = -1;
            _idSeleccionado = 0;
        }

        private void dgvInscripciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvInscripciones.Rows[e.RowIndex];
                _idSeleccionado = Convert.ToInt32(row.Cells["InscripcionId"].Value);
            }
        }
    }
}