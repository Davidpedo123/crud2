// OrdenCompra.Application/DTOs/OrdenCompraDto.cs
namespace crud2.OrdenCompra.Application.DTOs
{
    public class OrdenCompraDto
    {
        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public string ProveedorNombre { get; set; } = string.Empty;
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; } = "Creada"; // Valor por defecto
        public DateTime FechaCreacion { get; set; }
        public string Comentarios { get; set; } = string.Empty;
    }
}