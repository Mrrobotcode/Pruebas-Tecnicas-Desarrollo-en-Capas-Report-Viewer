using System;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class Sistema_Empresa : Form
    {
        public Sistema_Empresa()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            dgvDatosEmpleados.DataSource = NEmpleados.Listar_cat();
        }

        private void LimpiarFormulario()
        {
            txtIDEmpleado.Clear();
            txtNombreEmpleado.Clear();
            txtCargoEmpleado.Clear();
            txtNombreEmpleadoBuscar.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            EEmpleados validacion = CrearEmpleadoDesdeFormulario();

            if (NEmpleados.ValidacionesGuardar(validacion))
            {
                MessageBox.Show("Uno o mas campos no pueden estar vacios");
            }
            else
            {
                DialogResult resultado = MessageBox.Show("Seguro que quieres agregar a este empleado", "Confirma agregacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    NEmpleados.Guardar_emp(validacion);
                    MessageBox.Show("Empleado agregado");
                    CargarDatos();
                    LimpiarFormulario();
                } else
                {
                    MessageBox.Show("Operacion cancelada");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EEmpleados validacion = new EEmpleados
            {
                ID = int.TryParse(txtIDEmpleado.Text, out int idEmpleadoValidacion) ? idEmpleadoValidacion : (int?)null
            };

            if (NEmpleados.ValidacionesEliminar(validacion))
            {
                MessageBox.Show("Debe ingresar un ID valido para eliminar");
            }
            else
            {
                DialogResult resultado = MessageBox.Show("Seguro que quieres eliminar a este empleado", "Confirma eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    NEmpleados.Eliminar_emp(validacion);
                    MessageBox.Show("Empleado eliminado");
                    CargarDatos();
                    LimpiarFormulario();
                } else
                {
                    MessageBox.Show("Operacion cancelada");
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            EEmpleados validacion = CrearEmpleadoDesdeFormulario();

            if (NEmpleados.ValidacionesActualizar(validacion))
            {
                MessageBox.Show("Uno o mas campos no pueden estar vacios");
            }
            else
            {
                DialogResult resultado = MessageBox.Show("Seguro que quieres modificar a este empleado", "Confirma modificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    NEmpleados.Actualizar_emp(validacion);
                    MessageBox.Show("Empleado actualizado");
                    CargarDatos();
                    LimpiarFormulario();
                } else
                {
                    MessageBox.Show("Operacion cancelada");
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EEmpleados empleadoBusqueda = new EEmpleados
            {
                Nombre = txtNombreEmpleadoBuscar.Text
            };

            if (NEmpleados.ValidacionesBuscar(empleadoBusqueda))
            {
                MessageBox.Show("Debe ingresar un nombre valido para buscar");
            }
            else
            {
                dgvDatosEmpleados.DataSource = NEmpleados.Buscar_emp(empleadoBusqueda.Nombre);
            }
        }

        private EEmpleados CrearEmpleadoDesdeFormulario()
        {
            return new EEmpleados
            {
                ID = int.TryParse(txtIDEmpleado.Text, out int idEmpleado) ? idEmpleado : (int?)null,
                Nombre = txtNombreEmpleado.Text,
                Cargo = txtCargoEmpleado.Text
            };
        }

        private void dgvDatosEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDatosEmpleados.Rows[e.RowIndex];

                txtIDEmpleado.Text = row.Cells[0].Value.ToString();
                txtNombreEmpleado.Text = row.Cells[1].Value.ToString();
                txtCargoEmpleado.Text = row.Cells[2].Value.ToString();
            }
        }

        private void Sistema_Empresa_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
