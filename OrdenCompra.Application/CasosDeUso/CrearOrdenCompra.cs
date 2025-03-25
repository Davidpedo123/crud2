using crud2.OrdenCompra.Domain.Entidades;
using crud2.OrdenCompra.Domain.Interfaces;

namespace crud2.OrdenCompra.Application.CasosDeUso;

public class CrearOrdenCompra
{
    private readonly IRepositorioOrdenCompra _repositorio;

    public CrearOrdenCompra(IRepositorioOrdenCompra repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task EjecutarAsync(int proveedorId, decimal montoTotal, string comentarios)
    {
        var orden = new OrdenCompra.Domain.Entidades.OrdenCompra(proveedorId, montoTotal, "Creada", comentarios);
        await _repositorio.CreateAsync(orden);
    }
}
