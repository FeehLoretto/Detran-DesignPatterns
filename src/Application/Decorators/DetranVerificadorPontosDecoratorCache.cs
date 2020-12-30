using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using Workbench.IDistributedCache.Extensions;

namespace DesignPatternSamples.Application.Decorators
{
    public class DetranVerificadorPontosDecoratorCache : IDetranVerificadorPontosService
    {
        private readonly IDetranVerificadorPontosService _Inner;
        private readonly IDistributedCache _Cache;

        public DetranVerificadorPontosDecoratorCache(
            IDetranVerificadorPontosService inner,
            IDistributedCache cache)
        {
            _Inner = inner;
            _Cache = cache;
        }

        public Task<IEnumerable<PontosCarteira>> ConsultarDebitos(Carteira carteira)
        {
            return Task.FromResult(_Cache.GetOrCreate($"{carteira.CPFDoMotorista}_{carteira.Numero}", () => _Inner.ConsultarPontos(carteira).Result));
        }

        public Task<IEnumerable<PontosCarteira>> ConsultarPontos(Carteira carteira)
        {
            throw new System.NotImplementedException();
        }
    }
}
