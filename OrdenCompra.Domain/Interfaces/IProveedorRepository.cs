using crud2.OrdenCompra.Domain.Entidades;

namespace crud2.OrdenCompra.Domain.Interfaces;

public interface IProveedorRepository
{
    Task<IEnumerable<Proveedor>> GetAllAsync();
    Task<Proveedor?> GetByIdAsync(int id);
    Task CreateAsync(Proveedor proveedor);
    Task UpdateAsync(Proveedor proveedor);
}
