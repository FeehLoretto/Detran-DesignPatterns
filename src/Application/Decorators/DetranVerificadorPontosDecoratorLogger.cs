using DesignPatternSamples.Application.DTO;
using DesignPatternSamples.Application.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DesignPatternSamples.Application.Decorators
{
    public class DetranVerificadorPontosDecoratorLogger : IDetranVerificadorPontosService
    {
        private readonly IDetranVerificadorPontosService _Inner;
        private readonly ILogger<DetranVerificadorPontosDecoratorLogger> _Logger;

        public DetranVerificadorPontosDecoratorLogger(
            IDetranVerificadorPontosService inner,
            ILogger<DetranVerificadorPontosDecoratorLogger> logger)
        {
            _Inner = inner;
            _Logger = logger;
        }

        public async Task<IEnumerable<PontosCarteira>> ConsultarDebitos(Carteira carteira)
        {
            Stopwatch watch = Stopwatch.StartNew();
            _Logger.LogInformation($"Iniciando a execução do método ConsultarPontos({carteira})");
            var result = await _Inner.ConsultarPontos(carteira);
            watch.Stop();
            _Logger.LogInformation($"Encerrando a execução do método ConsultarPontos({carteira}) {watch.ElapsedMilliseconds}ms");
            return result;
        }

        public Task<IEnumerable<PontosCarteira>> ConsultarPontos(Carteira carteira)
        {
            throw new System.NotImplementedException();
        }
    }
}