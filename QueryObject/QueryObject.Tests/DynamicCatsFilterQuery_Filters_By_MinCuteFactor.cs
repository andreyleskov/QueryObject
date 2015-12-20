using System.Linq;
using Domain.Queries;
using NUnit.Framework;

namespace QueryObject
{
    class DynamicCatsFilterQuery_Filters_By_MinCuteFactor : DynamicCatsFilterQuery
    {
        protected override CatsFilterViewModel Filter()
        {
            return new CatsFilterViewModel { CuteFactorMin = 6 };
        }

        [Test]
        public void Then_Should_Be_Only_One_cuties_cat()
        {
            Assert.AreEqual(givenData.Bonifacii, _cats.First());
        }
    }
}