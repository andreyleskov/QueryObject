using Domain.Queries;
using NUnit.Framework;

namespace QueryObject
{
    class DynamicCatsFilterQuery_Filters_By_Positive_HasOwner : DynamicCatsFilterQuery
    {
        protected override CatsFilterViewModel Filter()
        {
            return new CatsFilterViewModel { hasOwner = true };
        }

        [Test]
        public void Then_Should_be_all_cats()
        {
            CollectionAssert.AreEquivalent(givenData.AllCats,_cats);
        }
    }
}