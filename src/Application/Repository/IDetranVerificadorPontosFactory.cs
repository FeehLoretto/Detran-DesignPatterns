using System;

namespace DesignPatternSamples.Application.Repository
{
    public interface IDetranVerificadorPontosFactory
    {
        public IDetranVerificadorPontosFactory Register(string Numero, Type repository);
        public IDetranVerificadorPontosRepository Create(string Numero);
    }
}
