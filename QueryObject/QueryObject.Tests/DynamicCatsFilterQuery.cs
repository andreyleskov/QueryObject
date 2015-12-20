using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Queries;
using SpecsFor;

namespace QueryObject
{
    internal class DynamicCatsFilterQuery : SpecsFor<Domain.Queries.DynamicCatsFilterQuery>
    {
        protected readonly AndreyAndJuliaCats givenData = new AndreyAndJuliaCats();
        protected IReadOnlyCollection<Cat> _cats;

        protected override void When()
        {
            _cats = SUT.Execute(Filter());
        }

        protected virtual CatsFilterViewModel Filter()
        {
            return new CatsFilterViewModel();
        }
        protected override void InitializeClassUnderTest()
        {
            SUT = new Domain.Queries.DynamicCatsFilterQuery(givenData.AllCats.AsQueryable(),
                givenData.AllPersons.AsQueryable());
        }
    }
}