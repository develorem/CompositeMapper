using Develorem.CompositeMapper.Tests.Models;
using Develorem.CompositeMapping;

namespace Develorem.CompositeMapper.Tests.Maps
{
    public class BookNovelMap : ExplicitMapper<Book, Novel>
    {
        public int NumberTimesCalled { get; set; }
        
        public override void Map(Book source, Novel target)
        {
            target.Name = source.Name;
            target.Authors = source.Authors;

            NumberTimesCalled++;
        }
    }
}
