using crud2.OrdenCompra.Application.DTOs;

// OrdenCompra.Application/Interfaces/IProveedorService.cs
namespace crud2.OrdenCompra.Application.Interfaces
{
    public interface IProveedorService
    {
        Task<IEnumerable<ProveedorDto>> GetAllAsync();
        Task<ProveedorDto> GetByIdAsync(int id);
        Task CreateAsync(ProveedorDto dto);
        Task UpdateAsync(ProveedorDto dto);
        Task DeleteAsync(int id);
    }
}