using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Icon icono = new Icon("C:/Users/HP/Desktop/icon.ico");
            Size tamañoDeseado = new Size(50, 50);
            Bitmap imagenRedimensionada = new Bitmap(icono.ToBitmap(), tamañoDeseado);
            pictureBox1.Image = imagenRedimensionada;
            pictureBox1.Size = tamañoDeseado;
            pictureBox1.Location = new Point(20, pictureBox1.Location.Y);
        }

        #region Acciones (Botones)
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades data = CrearProductoDesdeFormulario();

                if (Logica.ValidacionesGuardar(data))
                {
                    MessageBox.Show("Uno o mas campos no pueden estar vacios");
                }
                else
                {
                    DialogResult resultado = MessageBox.Show("Seguro que deseas guardar estos datos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (resultado == DialogResult.Yes)
                    {

                        if (cbCategoria.SelectedIndex == -1 || cbMedida.SelectedIndex == -1)
                        {
                            MessageBox.Show("No puedes dejar las casillas de los combobox vacias. Intentarlo de nuevo");
                        }
                        else
                        {
                            Logica.Guardar_pro(data);
                            MessageBox.Show("Producto agregado");
                            CargarDatos();
                            LimpiarFormulario();
                            EnabledTxtBotonComboBoxOFF();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Operacion cancelada");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"El error es: {ex} ");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EnabledTxtBotonComboBoxOFF();
            MessageBox.Show("Operaciones canceladas");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EnabledTxtBotonComboBoxON();
            LimpiarFormulario();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Entidades actualizarProducto = ActualizarProductoDesdeFormulario();

            if (Logica.ValidacionesActualizar(actualizarProducto))
            {
                MessageBox.Show("Uno o mas campos no pueden estar vacios");
            }
            else
            {
                DialogResult resultado = MessageBox.Show("Seguro que quieres modificar a este empleado", "Confirma modificacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    Logica.Actualizar_pro(actualizarProducto);
                    MessageBox.Show("Empleado actualizado");
                    CargarDatos();
                    LimpiarFormulario();
                    EnabledTxtBotonComboBoxOFF();
                }
                else
                {
                    MessageBox.Show("Operacion cancelada");
                }
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDatos.Rows[e.RowIndex];

                txtProducto.Text = row.Cells[1].Value.ToString();
                txtPrecio.Text = row.Cells[2].Value.ToString();
                txtStock.Text = row.Cells[3].Value.ToString();
                cbCategoria.Text = row.Cells[6].Value.ToString();
                cbMedida.Text = row.Cells[7].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDatos.SelectedRows[0];

                bool isRowEmpty = true;

                for (int i = 1; i < 2; i++)
                {
                    if (selectedRow.Cells[i].Value != null && !string.IsNullOrEmpty(selectedRow.Cells[i].Value.ToString()))
                    {
                        isRowEmpty = false;
                        break;
                    }
                }

                if (isRowEmpty)
                {
                    MessageBox.Show("La filas no tienen informacion, es decir que estan vacias. No se puede ejecutar la acción");
                } else
                {
                    Entidades idProductoEliminar = new Entidades
                    {
                        IDProducto = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["ID_Producto"].Value)
                    };

                    if (Logica.ValidacionesEliminar(idProductoEliminar.IDProducto))
                    {
                        MessageBox.Show("Debe seleccionar un ID para poder eliminar");
                    }
                    else
                    {
                        DialogResult resultado = MessageBox.Show("Seguro que quieres eliminar a este producto", "Confirma eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (resultado == DialogResult.Yes)
                        {
                            Logica.Eliminar_pro(idProductoEliminar);
                            MessageBox.Show("Empleado eliminado logicamente");
                            dgvDatos.Rows.RemoveAt(dgvDatos.SelectedRows[0].Index);
                            LimpiarFormulario();
                            EnabledTxtBotonComboBoxOFF();
                        }
                        else
                        {
                            MessageBox.Show("Operacion cancelada");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila en la tabla");
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ClickEnterButtonSearch();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarDataMedida();
            CargarDataCategoria();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ClickEnterButtonSearch();
        }
        #endregion

        #region Toma de Datos

        private void CargarDataMedida()
        {
            if (cbMedida.Items.Count < 0)
            {
                MessageBox.Show("No hay medidas para seleccionar");
            }
            else
            {
                cbMedida.DataSource = Logica.Listar_medidas();
                cbMedida.DisplayMember = "Nombre_Medida";
                cbMedida.ValueMember = "ID_Medida";
            }
        }

        private void CargarDataCategoria()
        {
            if (cbCategoria.Items.Count < 0)
            {
                MessageBox.Show("No hay categorias para seleccionar");
            }
            else
            {
                cbCategoria.DataSource = Logica.Listar_categoria();
                cbCategoria.DisplayMember = "Nombre_Categoria";
                cbCategoria.ValueMember = "ID_Categoria";
            }
        }

        private void CargarDatos()
        {
            dgvDatos.DataSource = Logica.Listar_cat();
        }

        #endregion

        #region Otros Metodos

        public void LimpiarFormulario()
        {
            txtBuscar.Clear();
            txtPrecio.Clear();
            txtProducto.Clear();
            txtStock.Clear();
        }

        private Entidades CrearProductoDesdeFormulario()
        {
            return new Entidades
            {
                NombreProducto = txtProducto.Text,
                IDCategoria = Convert.ToInt32(cbCategoria.SelectedValue),
                IDMedida = Convert.ToInt32(cbMedida.SelectedValue),
                PrecioProducto = int.TryParse(txtPrecio.Text, out int producto) ? producto : (int?)null,
                Stock = int.TryParse(txtStock.Text, out int stock) ? stock : (int?)null,
                Activo = 1,
            };
        }

        private Entidades ActualizarProductoDesdeFormulario()
        {
            return new Entidades
            {
                IDProducto = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["ID_Producto"].Value),
                NombreProducto = txtProducto.Text,
                IDCategoria = Convert.ToInt32(cbCategoria.SelectedValue),
                IDMedida = Convert.ToInt32(cbMedida.SelectedValue),
                PrecioProducto = int.TryParse(txtPrecio.Text, out int producto) ? producto : (int?)null,
                Stock = int.TryParse(txtStock.Text, out int stock) ? stock : (int?)null,
                Activo = 1,
            };
        }

        private void EnabledTxtBotonComboBoxOFF()
        {
            btnGuardar.Enabled = false;
            btnGuardar.Visible = false;
        }

        private void EnabledTxtBotonComboBoxON()
        {
            btnGuardar.Enabled = true;
            btnGuardar.Visible = true;
        }
        
        private void ClickEnterButtonSearch()
        {
            Entidades productoBusqueda = new Entidades
            {
                NombreProducto = txtBuscar.Text
            };

            if (Logica.ValidacionesBuscar(productoBusqueda))
            {
                MessageBox.Show("Debe ingresar un producto valido para buscar");
            }
            else
            {
                dgvDatos.DataSource = Logica.Buscar_pro(productoBusqueda.NombreProducto);
            }
        }
        #endregion

        #region Estilos de los Botones

        private void btnNuevo_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            int radius = 20;
            Color darkSlateColor = Color.DarkSlateGray;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(btn.Width - radius - 1, 0, radius, radius, 270, 90); 
                path.AddArc(btn.Width - radius - 1, btn.Height - radius - 1, radius, radius, 0, 90);
                path.AddArc(0, btn.Height - radius - 1, radius, radius, 90, 90);
                path.CloseFigure();
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillPath(new SolidBrush(btn.BackColor), path);

                using (Pen pen = new Pen(darkSlateColor, 1))
                {
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }

                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, new Rectangle(0, 0, btn.Width, btn.Height), btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void btnCancelar_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            int radius = 20;
            Color darkSlateColor = Color.DarkSlateGray;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(btn.Width - radius - 1, 0, radius, radius, 270, 90);
                path.AddArc(btn.Width - radius - 1, btn.Height - radius - 1, radius, radius, 0, 90);
                path.AddArc(0, btn.Height - radius - 1, radius, radius, 90, 90);
                path.CloseFigure();
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillPath(new SolidBrush(btn.BackColor), path);

                using (Pen pen = new Pen(darkSlateColor, 1))
                {
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }

                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, new Rectangle(0, 0, btn.Width, btn.Height), btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void btnActualizar_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            int radius = 20;
            Color darkSlateColor = Color.DarkSlateGray;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(btn.Width - radius - 1, 0, radius, radius, 270, 90);
                path.AddArc(btn.Width - radius - 1, btn.Height - radius - 1, radius, radius, 0, 90);
                path.AddArc(0, btn.Height - radius - 1, radius, radius, 90, 90);
                path.CloseFigure();
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillPath(new SolidBrush(btn.BackColor), path);

                using (Pen pen = new Pen(darkSlateColor, 1))
                {
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }

                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, new Rectangle(0, 0, btn.Width, btn.Height), btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
        #endregion
    }
}