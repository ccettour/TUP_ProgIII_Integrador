using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using IntegradorPIII.FE.Models;
using IntegradorPIII.FE.Services;
using IntegradorPIII.FE.Views;

namespace IntegradorPIII.FE
{
    public partial class AlumnosView : Form
    {
        private readonly AlumnoService _service;
        private int _idSeleccionado = 0;

        public AlumnosView()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Configuración del DataGridView
            dgvAlumnos.ReadOnly = true;
            dgvAlumnos.AllowUserToAddRows = false;
            dgvAlumnos.AllowUserToDeleteRows = false;
            dgvAlumnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlumnos.MultiSelect = false;

            btnActualizarAlum.Enabled = false;
            btnEliminarAlum.Enabled = false;
            btnInscribir.Enabled = false;
            btnAgregarAlum.Enabled = true;

            // Configurar HttpClient (ignorar certificado para pruebas locales)
            var handler = new System.Net.Http.HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            var httpClient = new System.Net.Http.HttpClient(handler)
            {
                BaseAddress = new Uri("http://localhost:5038/")
            };

            _service = new AlumnoService(httpClient);

            // Cargar datos al iniciar
            _ = CargarAlumnosAsync();
        }

        private async Task CargarAlumnosAsync()
        {
            dgvAlumnos.DataSource = await _service.ObtenerAlumnosAsync();

            // Personalizar encabezados
            dgvAlumnos.Columns["Id"].HeaderText = "Código";
            dgvAlumnos.Columns["Nombre"].HeaderText = "Nombre del Alumno";
            dgvAlumnos.Columns["Apellido"].HeaderText = "Apellido del Alumno";
            dgvAlumnos.Columns["Legajo"].HeaderText = "N° Legajo";
            dgvAlumnos.Columns["FechaNacimiento"].HeaderText = "Fecha de Nacimiento";

            // Formato de fecha
            dgvAlumnos.Columns["FechaNacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtLegajo.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            _idSeleccionado = 0;

            btnAgregarAlum.Enabled = true;
            btnActualizarAlum.Enabled = false;
            btnEliminarAlum.Enabled = false;
            btnInscribir.Enabled = false;
        }

        private bool EsMayorDe16(DateTime fechaNacimiento)
        {
            var edad = DateTime.Today.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad)) edad--;
            return edad >= 16;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtLegajo.Text))
            {
                MessageBox.Show("Nombre, Apellido y Legajo son obligatorios");
                return;
            }

            if (!EsMayorDe16(dtpFechaNacimiento.Value))
            {
                MessageBox.Show("El alumno debe ser mayor de 16 años");
                return;
            }

            var nuevo = new Alumno
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Legajo = txtLegajo.Text,
                FechaNacimiento = dtpFechaNacimiento.Value
            };

            bool exito = await _service.AgregarAlumnoAsync(nuevo);
            MessageBox.Show(exito ? "Alumno agregado correctamente" : "Error al agregar alumno");
            await CargarAlumnosAsync();
            LimpiarCampos();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un alumno para actualizar");
                return;
            }

            if (!EsMayorDe16(dtpFechaNacimiento.Value))
            {
                MessageBox.Show("El alumno debe ser mayor de 16 años");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtLegajo.Text))
            {
                MessageBox.Show("Nombre, Apellido y Legajo son obligatorios");
                return;
            }

            var actualizado = new Alumno
            {
                Id = _idSeleccionado,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Legajo = txtLegajo.Text,
                FechaNacimiento = dtpFechaNacimiento.Value
            };

            bool exito = await _service.ActualizarAlumnoAsync(actualizado);
            
            MessageBox.Show(exito ? "Alumno actualizado correctamente" : "Error al actualizar alumno");
            await CargarAlumnosAsync();
            LimpiarCampos();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un alumno para eliminar");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar este alumno?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bool exito = await _service.EliminarAlumnoAsync(_idSeleccionado);
                MessageBox.Show(exito ? "Alumno eliminado correctamente" : "Error al eliminar alumno");
                await CargarAlumnosAsync();
                LimpiarCampos();
            }
        }

        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvAlumnos.Rows[e.RowIndex];
                txtNombre.Text = row.Cells["Nombre"].Value?.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value?.ToString();
                txtLegajo.Text = row.Cells["Legajo"].Value?.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(row.Cells["FechaNacimiento"].Value);
                _idSeleccionado = Convert.ToInt32(row.Cells["Id"].Value);

                btnAgregarAlum.Enabled = false; // Desactiva Agregar
                btnActualizarAlum.Enabled = true;
                btnEliminarAlum.Enabled = true;
                btnInscribir.Enabled = true;
            }
        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                var filaSeleccionada = dgvAlumnos.SelectedRows[0];

                // Obtener el objeto Alumno completo
                Alumno alumnoSeleccionado = filaSeleccionada.DataBoundItem as Alumno;

                if (alumnoSeleccionado != null)
                {
                    InscripcionView inscripcionView = new InscripcionView(alumnoSeleccionado);
                    inscripcionView.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el alumno seleccionado.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un alumno para inscribir.");
            }

        }
    }
}