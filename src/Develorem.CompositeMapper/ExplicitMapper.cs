namespace Develorem.CompositeMapping
{
 
    public abstract class ExplicitMapper<TSource, TTarget> 
    {

        public abstract void Map(TSource source, TTarget target);
    }
}
