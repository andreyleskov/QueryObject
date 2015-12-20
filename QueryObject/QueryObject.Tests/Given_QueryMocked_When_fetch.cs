using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Domain;
using Infrastructure;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using SpecsFor;
using IContainer = StructureMap.IContainer;

namespace QueryObject
{
    class Given_QueryMocked_When_fetch:SpecsFor<ReportBuilder>
    {
        private  Cat[] _cats;
        private IReadOnlyCollection<string> _reportedNames;

        protected override void  Given()
        {
            _cats = (new Fixture()).CreateMany<Cat>().ToArray();
            GetMockFor<IQuery<Cat, int>>().Setup(q => q.Execute(It.IsAny<int>())).Returns(_cats);
        }

        protected override void When()
        {
            _reportedNames = SUT.MostPopularCatNamesForLadies(10);
        }

        [Test]
        public void Mocked_Query_results_should_be_fetched()
        {
            CollectionAssert.AreEquivalent(_cats.Select(c => c.Name),_reportedNames);
        }
    }

    public static class CollectionExtensions
    {
        public static T TakeRandom<T>(this ICollection<T> col)
        {
            var num = (new Random()).Next(0, col.Count);
            return col.Skip(num).First();
        }    
    }
}