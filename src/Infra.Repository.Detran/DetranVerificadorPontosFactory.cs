using DesignPatternSamples.Application.Repository;
using System;
using System.Collections.Generic;

namespace DesignPatternSamples.Infra.Repository.Detran
{
    public class DetranVerificadorPontosFactory : IDetranVerificadorPontosFactory
    {
        private readonly IServiceProvider _ServiceProvider;
        private readonly IDictionary<string, Type> _Repositories = new Dictionary<string, Type>();

        public DetranVerificadorPontosFactory(IServiceProvider serviceProvider)
        {
            _ServiceProvider = serviceProvider;
        }

        public IDetranVerificadorPontosRepository Create(string Numero)
        {
            IDetranVerificadorPontosRepository result = null;

            if (_Repositories.TryGetValue(Numero, out Type type))
            {
                result = _ServiceProvider.GetService(type) as IDetranVerificadorPontosRepository;
            }

            return result;
        }

        public IDetranVerificadorPontosFactory Register(string Numero, Type repository)
        {
            if (!_Repositories.TryAdd(Numero, repository))
            {
                _Repositories[Numero] = repository;
            }

            return this;
        }
    }
}
