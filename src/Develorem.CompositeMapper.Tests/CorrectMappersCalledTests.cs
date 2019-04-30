using Develorem.CompositeMapper.Tests.AutoMappers;
using Develorem.CompositeMapper.Tests.Maps;
using Develorem.CompositeMapper.Tests.Models;
using Develorem.CompositeMapping;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Linq;

namespace Develorem.CompositeMapper.Tests
{
    [TestClass]
    public class CorrectMappersCalledTests
    {
        [TestMethod]
        public void EnsureAutoMapperWorksAlone()
        {
            var services = new ServiceCollection() as IServiceCollection;
            services.RegisterCompositeAutoMapper<DoNothingAutoMapper>();
            services.AddSingleton<Harness>();
            var provider = services.BuildServiceProvider();

            var harness = provider.GetRequiredService<Harness>();

            var book = new Book { Name = "Bored of the Rings", Authors = new[] { "JRT Token" } };
            var novel = new Novel();

            harness.TestMap(book, novel);

            var autoMapper = provider.GetService<IAutoMapper>() as DoNothingAutoMapper;
            autoMapper.NumberTimesCalled.ShouldBe(1);
        }

        [TestMethod]
        public void EnsureExplicitMapperCalledAndNotTheAutoMapper()
        {
            var services = new ServiceCollection() as IServiceCollection;
            services.RegisterCompositeAutoMapper<DoNothingAutoMapper>(typeof(BookNovelMap).Assembly);
            services.AddSingleton<Harness>();            
            var provider = services.BuildServiceProvider();

            var harness = provider.GetRequiredService<Harness>();

            var book = new Book { Name = "Bored of the Rings", Authors = new[] { "JRT Token" } };
            var novel = new Novel();

            harness.TestMap(book, novel);

            var explicitMapper = provider.GetRequiredService<ExplicitMapper<Book, Novel>>() as BookNovelMap;
            explicitMapper.NumberTimesCalled.ShouldBe(1);

            var autoMapper = provider.GetService<IAutoMapper>() as DoNothingAutoMapper;
            autoMapper.NumberTimesCalled.ShouldBe(0);
        }

    }
}
