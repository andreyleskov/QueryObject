using System;
using System.Linq;
using Domain.Queries;
using NUnit.Framework;

namespace QueryObject
{
    class DynamicCatsFilterQuery_Orders_By_Multiple_columns : DynamicCatsFilterQuery
    {
        protected override CatsFilterViewModel Filter()
        {
            return new CatsFilterViewModel
            {
                FieldsOrdering = 
                    new []
                    {
                        Tuple.Create("CuteFactor",OrderDirection.Ascending),
                        Tuple.Create("Id",OrderDirection.Descending),
                        
                    }
            };
        }

        [Test]
        public void Then_First_Cat_Has_LowestCuteFactor_And_Highest_Id()
        {
            Assert.AreEqual(givenData.Maikl, _cats.First());
        }


        [Test]
        public void Then_Second_Cat_Has_LowestCuteFactor_And_Next_Id()
        {
            Assert.AreEqual(givenData.Sansa, _cats.Skip(1).First());
        }

        [Test]
        public void Then_Lastd_Cat_Has_Hithest_CuteFactor()
        {
            Assert.AreEqual(givenData.Bonifacii, _cats.Skip(2).First());
        }
    }
}