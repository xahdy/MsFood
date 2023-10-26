using Marketplace.Domain.Interfaces;
using Marketplace.Domain.Models;


namespace Marketplace.Infra.Services
{
    public class MessageConsumer : ITypedConsumer<BaseEntity>
    {
        private readonly IRepository<Restaurante> _restauranteRepository;
        private readonly IRepository<Prato> _pratoRepository;

        public MessageConsumer(IRepository<Restaurante> restauranteRepository, IRepository<Prato> pratoRepository)
        {
            _restauranteRepository = restauranteRepository;
            _pratoRepository = pratoRepository;
        }
        public async Task ConsumeAsync(BaseEntity message, CancellationToken cancellationToken)
        {
            if (message != null)
            {
                var tipoObjeto = message.GetType();

                if (tipoObjeto == typeof(Restaurante))
                {
                    Restaurante restaurante = message as Restaurante;
                    await _restauranteRepository.AddAsync(restaurante);
                    await _restauranteRepository.SaveChangesAsync();
                }

                Prato prato = message as Prato;
                await _pratoRepository.AddAsync(prato);
                await _pratoRepository.SaveChangesAsync();
            }
        }
    }
}
