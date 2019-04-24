using System.Collections.Generic;

namespace Develorem.CompositeMapper.Tests.Models
{
    public class Novel
    {
        public string Name { get; set; }
        public IEnumerable<string> Authors { get; set; }
    }

}
