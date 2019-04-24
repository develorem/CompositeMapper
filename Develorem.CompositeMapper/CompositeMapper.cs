using System;
using Microsoft.Extensions.DependencyInjection;

namespace Develorem.CompositeMapping
{
    public class CompositeMapper : IMapper
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAutoMapper _autoMapper;

        public CompositeMapper(IServiceProvider serviceProvider, IAutoMapper autoMapper)
        {
            _serviceProvider = serviceProvider;
            _autoMapper = autoMapper;
        }

        public TTarget Map<TSource, TTarget>(TSource source) where TTarget : new()
        {
            var target = new TTarget();
            Map(source, target);
            return target;
        }

        public void Map<TSource, TTarget>(TSource source, TTarget target)
        {
            var explicitMapper = _serviceProvider.GetService<ExplicitMapper<TSource, TTarget>>();
            if (explicitMapper != null)
            {
                explicitMapper.Map(source, target);
                return;
            }

            _autoMapper.Map(source, target);            
        }
        
    }
}
