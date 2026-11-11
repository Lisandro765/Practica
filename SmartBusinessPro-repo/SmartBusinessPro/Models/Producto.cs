namespace SmartBusinessPro.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Existencia { get; set; }

        // Clave foránea hacia Categorias
        public int CategoriaId { get; set; }

        // Propiedad de navegación: cada producto pertenece a una categoría
        public Categoria? Categoria { get; set; }
    }
}
