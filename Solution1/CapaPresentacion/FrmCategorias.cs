using CapaNegocio;
using System;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
        }
        #region "Mis Variables"
        int estadoGuarda=0;
        int nCodigo = 0;
        #endregion
        #region "Mis Metodos"
        private void Formato_ca()
        {
            dgvListado.Columns[0].Width = 88;
            dgvListado.Columns[0].HeaderText = "CODIGO";
            dgvListado.Columns[1].Width = 250;
            dgvListado.Columns[1].HeaderText = "CATEGORIA";
        }
        public void Listar_ca(string texto)
        {
            dgvListado.DataSource = NCategorias.Listar_ca(texto);
            this.Formato_ca();
        }

        private void Estado(bool lEstado)
        {
            txtCategoria.Enabled = lEstado;
            btnGuardar.Enabled = lEstado;
            btnCancelar.Enabled = lEstado;

            btnNuevo.Enabled = !lEstado;
            btnActualizar.Enabled = !lEstado;
            btnEliminar.Enabled = !lEstado;
            btnReporte.Enabled = !lEstado;
            btnSalir.Enabled=!lEstado;

            txtBuscar.Enabled = !lEstado;
            btnBuscar.Enabled = !lEstado;
            dgvListado.Enabled = !lEstado;
        }
        #endregion

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            this.Listar_ca("%");
            this.Formato_ca();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           if(string.IsNullOrEmpty(txtCategoria.Text))
            {
                MessageBox.Show("No se tiene información para ser guardada.","Aviso del sistema"
                    ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string respuesta = "";
                ECategorias datos = new ECategorias();
                datos.Codigo_ca = nCodigo;
                datos.Descripcion_ca = txtCategoria.Text.Trim();               
                respuesta = NCategorias.Guardar_ca(estadoGuarda, datos);
                if (respuesta == "OK")
                {
                    this.Listar_ca("");
                    this.Estado(false);
                    estadoGuarda = 0;
                    nCodigo = 0;
                    MessageBox.Show("Datos guardados correctamente","Aviso del sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(respuesta,"Aviso del sistema",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                }                
            }
            
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listar_ca(txtBuscar.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoGuarda = 1;
            this.Estado(true);
            txtCategoria.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Estado(false);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            estadoGuarda = 2;
            this.Estado(true);


        }

        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nCodigo = Convert.ToInt32(dgvListado.CurrentRow.Cells["codigo_ca"].Value);
            txtCategoria.Text = dgvListado.CurrentRow.Cells["descripcion_ca"].Value.ToString();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Estás seguro de eliminar este registro", "Aviso del sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion==DialogResult.Yes)
            {
                string respuesta = "";
                respuesta = NCategorias.Eliminar_ca(nCodigo);
                if (respuesta.Equals("OK"))
                {
                    this.Listar_ca("");                   
                    nCodigo = 0;
                    txtCategoria.Text = "";
                    MessageBox.Show("Registro eliminado", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show(respuesta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }             
                
            }
           
        }
    }
}
