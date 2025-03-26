// OrdenCompra.Application/Servicios/ProveedorService.cs
using crud2.OrdenCompra.Application.DTOs;
using crud2.OrdenCompra.Application.Interfaces;
using crud2.OrdenCompra.Domain.Entidades;
using crud2.OrdenCompra.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace crud2.OrdenCompra.Application.Servicios
{
    public class ProveedorService : IProveedorService
    {
        private readonly OrdenCompraContext _context;

        public ProveedorService(OrdenCompraContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProveedorDto>> GetAllAsync()
        {
            return await _context.Proveedores
                .Select(p => new ProveedorDto
                {
                    ProveedorId = p.ProveedorId,
                    Nombre = p.Nombre,
                    Contacto = p.Contacto,
                    Telefono = p.Telefono,
                    Email = p.Email,
                    Direccion = p.Direccion
                }).ToListAsync();
        }

        public async Task<ProveedorDto> GetByIdAsync(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null) return null;

            return new ProveedorDto
            {
                ProveedorId = proveedor.ProveedorId,
                Nombre = proveedor.Nombre,
                Contacto = proveedor.Contacto,
                Telefono = proveedor.Telefono,
                Email = proveedor.Email,
                Direccion = proveedor.Direccion
            };
        }

        public async Task CreateAsync(ProveedorDto dto)
        {
            var proveedor = new Proveedor(
                dto.Nombre,
                dto.Contacto,
                dto.Telefono,
                dto.Email,
                dto.Direccion);

            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
            dto.ProveedorId = proveedor.ProveedorId;
        }

        public async Task UpdateAsync(ProveedorDto dto)
        {
            var proveedor = await _context.Proveedores.FindAsync(dto.ProveedorId);
            if (proveedor == null) throw new KeyNotFoundException("Proveedor no encontrado");

            proveedor.Update(
                dto.Nombre,
                dto.Contacto,
                dto.Telefono,
                dto.Email,
                dto.Direccion);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null) throw new KeyNotFoundException("Proveedor no encontrado");

            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
        }
    }
}