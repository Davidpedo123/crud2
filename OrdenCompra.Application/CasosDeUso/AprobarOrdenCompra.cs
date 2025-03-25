using System;
using System.Threading.Tasks;
using crud2.OrdenCompra.Domain.Interfaces;
using crud2.OrdenCompra.Domain.Entidades;

namespace crud2.OrdenCompra.Application.CasosDeUso
{
    public class AprobarOrdenCompra
    {
        private readonly IRepositorioOrdenCompra _repository;

        public AprobarOrdenCompra(IRepositorioOrdenCompra repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int ordenId)
        {
            var orden = await _repository.GetByIdAsync(ordenId);
            if (orden is null)
                throw new KeyNotFoundException($"OrdenCompra {ordenId} no encontrada.");

            orden.Aprobar();
            await _repository.UpdateAsync(orden);
        }
    }
}
