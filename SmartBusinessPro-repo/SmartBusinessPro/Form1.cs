using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SmartBusinessPro.Data;

namespace SmartBusinessPro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Comprueba que se puede abrir la conexión con SQL Server
        private void btnProbarConexion_Click(object? sender, EventArgs e)
        {
            try
            {
                using var db = new SmartBusinessContext();

                if (db.Database.CanConnect())
                {
                    lblEstado.Text = "Conexión exitosa a SmartBusinessPro";
                    lblEstado.ForeColor = Color.Green;
                }
                else
                {
                    lblEstado.Text = "No fue posible conectar con la base de datos";
                    lblEstado.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // Recupera los productos junto con su categoría
        private void btnConsultar_Click(object? sender, EventArgs e)
        {
            try
            {
                using var db = new SmartBusinessContext();

                var lista = db.Productos
                    .AsNoTracking()
                    .OrderBy(p => p.Nombre)
                    .Select(p => new
                    {
                        Producto = p.Nombre,
                        Precio = p.Precio,
                        Existencia = p.Existencia,
                        Categoria = p.Categoria!.Nombre
                    })
                    .ToList();

                dgvProductos.DataSource = lista;
                dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "C2";

                lblEstado.Text = $"{lista.Count} productos recuperados";
                lblEstado.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        // Traduce los errores técnicos a mensajes comprensibles
        private void MostrarError(Exception ex)
        {
            var sqlEx = ex as SqlException ?? ex.InnerException as SqlException;

            string mensaje = sqlEx?.Number switch
            {
                53 or -1 or 2 => "No se pudo localizar el servidor SQL. Verifique el nombre del servidor y que el servicio esté iniciado.",
                4060 => "La base de datos indicada no existe o el usuario no tiene acceso a ella.",
                18456 => "Inicio de sesión fallido. Revise el usuario o la contraseña.",
                _ when sqlEx != null => $"Error de SQL Server ({sqlEx.Number}): {sqlEx.Message}",
                _ => $"Error inesperado: {ex.Message}"
            };

            lblEstado.Text = "Error de conexión";
            lblEstado.ForeColor = Color.Red;
            dgvProductos.DataSource = null;

            MessageBox.Show(mensaje, "SmartBusinessPro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
