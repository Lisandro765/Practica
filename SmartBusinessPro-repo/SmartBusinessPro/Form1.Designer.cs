namespace SmartBusinessPro
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnProbarConexion = new Button();
            btnConsultar = new Button();
            dgvProductos = new DataGridView();
            lblEstado = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            //
            // btnProbarConexion
            //
            btnProbarConexion.Location = new Point(12, 12);
            btnProbarConexion.Name = "btnProbarConexion";
            btnProbarConexion.Size = new Size(150, 32);
            btnProbarConexion.TabIndex = 0;
            btnProbarConexion.Text = "Probar conexión";
            btnProbarConexion.UseVisualStyleBackColor = true;
            btnProbarConexion.Click += btnProbarConexion_Click;
            //
            // btnConsultar
            //
            btnConsultar.Location = new Point(168, 12);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(150, 32);
            btnConsultar.TabIndex = 1;
            btnConsultar.Text = "Consultar productos";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(334, 20);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(120, 15);
            lblEstado.TabIndex = 2;
            lblEstado.Text = "Sin conexión probada";
            //
            // dgvProductos
            //
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 56);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.Size = new Size(760, 393);
            dgvProductos.TabIndex = 3;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(dgvProductos);
            Controls.Add(lblEstado);
            Controls.Add(btnConsultar);
            Controls.Add(btnProbarConexion);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SmartBusinessPro - Inventario";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnProbarConexion;
        private Button btnConsultar;
        private DataGridView dgvProductos;
        private Label lblEstado;
    }
}
