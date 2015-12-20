using Domain;
using Domain.Queries;
using NUnit.Framework;

namespace QueryObject
{
    class DynamicCatsFilterQuery_Filters_By_Positive_HasOwner_And_Gender : DynamicCatsFilterQuery
    {
        protected override CatsFilterViewModel Filter()
        {
            return new CatsFilterViewModel { hasOwner = true , onwerGender = Gender.Male};
        }

        [Test]
        public void Then_Should_be_all_Andrey_cats()
        {
            CollectionAssert.AreEquivalent(givenData.AndreyCats, _cats);
        }
    }
}