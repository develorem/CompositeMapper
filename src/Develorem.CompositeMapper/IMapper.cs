namespace Develorem.CompositeMapping
{
    public interface IMapper
    {
        TTarget Map<TSource, TTarget>(TSource source) where TTarget : new();
        void Map<TSource, TTarget>(TSource source, TTarget target);

    }
}
