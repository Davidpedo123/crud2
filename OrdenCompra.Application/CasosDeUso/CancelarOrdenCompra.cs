using System;
using System.Threading.Tasks;
using crud2.OrdenCompra.Domain.Entidades;
using crud2.OrdenCompra.Domain.Interfaces;

namespace crud2.OrdenCompra.Application.CasosDeUso
{
    public class CancelarOrdenCompra
    {
        private readonly IRepositorioOrdenCompra _repository;

        public CancelarOrdenCompra(IRepositorioOrdenCompra repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int ordenId)
        {
            var orden = await _repository.GetByIdAsync(ordenId);
            if (orden is null)
                throw new KeyNotFoundException($"OrdenCompra {ordenId} no encontrada.");

            orden.Cancelar();
            await _repository.UpdateAsync(orden);
        }
    }
}
