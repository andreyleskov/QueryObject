using System.Collections.Generic;
using System.Linq;
using Domain;
using NUnit.Framework;
using Ploeh.AutoFixture;
using SpecsFor;

namespace QueryObject
{
    class Given_Query_ForInMemoryObjects_When_fetch : SpecsFor<ReportBuilder>
    {
        private Cat[] _cats;
        private Person[] _persons;
        private IReadOnlyCollection<string> _reportedNames;

        protected override void Given()
        {
            var fixture = new Fixture();
            _persons = fixture.CreateMany<Person>().ToArray();
            _cats = fixture.Build<Cat>().Do(c => c.OwnerId = _persons.TakeRandom().Id)
                .CreateMany()
                .ToArray();
        }

        protected override void InitializeClassUnderTest()
        {
            //here we can bind dbcontext as provider for queriables
            SUT = new ReportBuilder(new TopCutiestCatsForLadies(_cats.AsQueryable(),_persons.AsQueryable()));
        }

        protected override void When()
        {
            _reportedNames = SUT.MostPopularCatNamesForLadies(10);
        }

        [Test]
        public void All_names_taken_from_data_are_real()
        {
            foreach (var name in _reportedNames)
            {
                CollectionAssert.Contains(_cats.Select(c => c.Name), name);
            }
        }
    }
}