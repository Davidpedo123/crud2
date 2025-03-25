using crud2.OrdenCompra.Domain.Entidades;

namespace crud2.OrdenCompra.Application.Interfaces
{
    public interface IProveedorService
    {
        Task<IEnumerable<Proveedor>> GetAllAsync();
        Task<Proveedor?> GetProveedorAsync(int id);
        Task CreateProveedorAsync(Proveedor proveedor);
        Task UpdateProveedorAsync(Proveedor proveedor);
        Task DeleteProveedorAsync(int id);
    }
}
