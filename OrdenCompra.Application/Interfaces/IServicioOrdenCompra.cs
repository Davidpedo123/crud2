
using crud2.OrdenCompra.Application.DTOs; 
namespace crud2.OrdenCompra.Application.Interfaces
{
    public interface IServicioOrdenCompra
    {
        Task<IEnumerable<OrdenCompraDto>> GetAllAsync();
        Task<OrdenCompraDto> GetByIdAsync(int id);
        Task CreateAsync(OrdenCompraDto dto);
        Task UpdateAsync(OrdenCompraDto dto);
        Task DeleteAsync(int id);
    }
}