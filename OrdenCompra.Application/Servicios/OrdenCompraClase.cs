// OrdenCompra.Application/Servicios/ServicioOrdenCompra.cs
using crud2.OrdenCompra.Application.DTOs;
using crud2.OrdenCompra.Application.Interfaces;
using crud2.OrdenCompra.Domain.Entidades;
using crud2.OrdenCompra.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace crud2.OrdenCompra.Application.Servicios
{
    public class ServicioOrdenCompra : IServicioOrdenCompra
    {
        private readonly OrdenCompraContext _context;

        public ServicioOrdenCompra(OrdenCompraContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(OrdenCompraDto dto)
        {
            // El estado ya viene con valor por defecto del DTO
            var entidad = new Domain.Entidades.OrdenCompra(
                dto.ProveedorId,
                dto.MontoTotal,
                dto.Estado, // Usamos el estado del DTO
                dto.Comentarios
            );

            _context.OrdenesCompra.Add(entidad);
            await _context.SaveChangesAsync();
            dto.Id = entidad.OrdenCompraId;
        }

        public async Task<IEnumerable<OrdenCompraDto>> GetAllAsync()
        {
            return await _context.OrdenesCompra
                .Include(o => o.Proveedor)
                .Select(o => new OrdenCompraDto
                {
                    Id = o.OrdenCompraId,  // Cambiado de OrdenCompraId a Id
                    ProveedorId = o.ProveedorId,
                    ProveedorNombre = o.Proveedor.Nombre,
                    MontoTotal = o.MontoTotal,
                    Estado = o.Estado,
                    FechaCreacion = o.FechaCreacion,
                    Comentarios = o.Comentarios
                })
                .ToListAsync();
        }

        public async Task<OrdenCompraDto> GetByIdAsync(int id)
            {
                var orden = await _context.OrdenesCompra
                    .Include(o => o.Proveedor)
                    .FirstOrDefaultAsync(o => o.OrdenCompraId == id);

                if (orden == null) return null;

                return new OrdenCompraDto
                {
                    Id = orden.OrdenCompraId,  // Cambiado de OrdenCompraId a Id
                    ProveedorId = orden.ProveedorId,
                    ProveedorNombre = orden.Proveedor.Nombre,
                    MontoTotal = orden.MontoTotal,
                    Estado = orden.Estado,
                    FechaCreacion = orden.FechaCreacion,
                    Comentarios = orden.Comentarios
                };
            }

        public async Task UpdateAsync(OrdenCompraDto dto)
        {
            var orden = await _context.OrdenesCompra.FindAsync(dto.Id);
            if (orden == null) throw new KeyNotFoundException("Orden no encontrada");

            // Usamos el método de la entidad en lugar de asignar propiedades directamente
            orden.ActualizarInformacion(
                proveedorId: dto.ProveedorId,
                montoTotal: dto.MontoTotal,
                estado: dto.Estado,
                comentarios: dto.Comentarios
            );

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orden = await _context.OrdenesCompra.FindAsync(id);
            if (orden == null) throw new KeyNotFoundException("Orden no encontrada");

            _context.OrdenesCompra.Remove(orden);
            await _context.SaveChangesAsync();
        }

        public async Task AprobarOrdenAsync(int id)
        {
            var orden = await _context.OrdenesCompra.FindAsync(id);
            if (orden == null) throw new KeyNotFoundException("Orden no encontrada");

            orden.Aprobar();
            await _context.SaveChangesAsync();
        }

        public async Task CancelarOrdenAsync(int id)
        {
            var orden = await _context.OrdenesCompra.FindAsync(id);
            if (orden == null) throw new KeyNotFoundException("Orden no encontrada");

            orden.Cancelar();
            await _context.SaveChangesAsync();
        }
    }
}