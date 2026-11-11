namespace SmartBusinessPro.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; } = string.Empty;

        // Propiedad de navegación: una categoría tiene muchos productos
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
