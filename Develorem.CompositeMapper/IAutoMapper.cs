namespace Develorem.CompositeMapping
{
    public interface IAutoMapper
    {
        TTarget Map<TTarget>(object source);
        void Map(object source, object target);
    }
}
