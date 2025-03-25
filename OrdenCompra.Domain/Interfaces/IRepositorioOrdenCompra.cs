using crud2.OrdenCompra.Domain.Entidades;

namespace crud2.OrdenCompra.Domain.Interfaces;

public interface IRepositorioOrdenCompra
{
    Task<IEnumerable<Entidades.OrdenCompra>> GetAllAsync();
    Task<Entidades.OrdenCompra?> GetByIdAsync(int id);
    Task CreateAsync(Entidades.OrdenCompra orden);
    Task UpdateAsync(Entidades.OrdenCompra orden);
}
