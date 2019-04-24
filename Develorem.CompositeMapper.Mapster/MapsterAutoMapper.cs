using Develorem.CompositeMapping;
using Mapster;

namespace Develorem.CompositeMapper.Mapster
{
    public class MapsterAutoMapper : IAutoMapper
    {
        public TTarget Map<TTarget>(object source)
        {
            return source.Adapt<TTarget>();
        }

        public void Map(object source, object target)
        {
            source.Adapt(target);
        }
    }
}
