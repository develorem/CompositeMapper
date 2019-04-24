using Develorem.CompositeMapping;

namespace Develorem.CompositeMapper.Tests
{
    /// <summary>
    /// A class that needs to use the mapper!
    /// I mean, the tests could have resolved the IMapper directly, but at least this way we mimick real code.
    /// </summary>
    public class Harness
    {
        private readonly IMapper _mapper;

        public Harness(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void TestMap<TSource, TTarget>(TSource source, TTarget target)
        {
            _mapper.Map(source, target);
        }
    }
}
