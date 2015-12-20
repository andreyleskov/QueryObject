using Domain.Queries;
using NUnit.Framework;

namespace QueryObject
{
    class DynamicCatsFilterQuery_Filters_By_Negative_HasOwner : DynamicCatsFilterQuery
    {
        protected override CatsFilterViewModel Filter()
        {
            return new CatsFilterViewModel { hasOwner = false };
        }

        [Test]
        public void Then_Should_no_cats()
        {
            CollectionAssert.IsEmpty(_cats);
        }
    }
}