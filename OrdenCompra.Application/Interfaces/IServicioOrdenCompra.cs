using crud2.OrdenCompra.Domain.Entidades;

namespace crud2.OrdenCompra.Application.Interfaces;

public interface IServicioOrdenCompra
{
    Task<IEnumerable<OrdenCompra.Domain.Entidades.OrdenCompra>> GetAllAsync();
    Task<OrdenCompra.Domain.Entidades.OrdenCompra?> GetByIdAsync(int id);
    Task CreateAsync(OrdenCompra.Domain.Entidades.OrdenCompra orden); 
    Task ApproveAsync(int id);
    Task CancelAsync(int id);
}

