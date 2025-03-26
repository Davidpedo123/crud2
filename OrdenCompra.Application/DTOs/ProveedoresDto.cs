// OrdenCompra.Application/DTOs/ProveedorDto.cs
namespace crud2.OrdenCompra.Application.DTOs
{
    public class ProveedorDto
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }  = string.Empty;
        public string Contacto { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }
}