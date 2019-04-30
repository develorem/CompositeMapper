using Develorem.CompositeMapping;

namespace Develorem.CompositeMapper.Tests.AutoMappers
{
    public class DoNothingAutoMapper : IAutoMapper
    {
        public int NumberTimesCalled { get; set; }

        public TTarget Map<TTarget>(object source)
        {
            NumberTimesCalled++;
            return default(TTarget);
        }

        public void Map(object source, object target)
        {
            NumberTimesCalled++;            
        }
    }
}
