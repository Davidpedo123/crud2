using crud2.OrdenCompra.Domain.Entidades;
using crud2.OrdenCompra.Domain.Interfaces;

namespace crud2.OrdenCompra.Application.CasosDeUso;

public class SeguimientoOrdenCompra
{
    private readonly IRepositorioOrdenCompra _repositorio;

    public SeguimientoOrdenCompra(IRepositorioOrdenCompra repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<OrdenCompra.Domain.Entidades.OrdenCompra?> EjecutarAsync(int id)
    {
        return await _repositorio.GetByIdAsync(id);
    }
}
