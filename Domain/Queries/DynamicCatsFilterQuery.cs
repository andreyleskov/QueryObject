using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure;

namespace Domain.Queries
{
    public class DynamicCatsFilterQuery:IQuery<Cat, CatsFilterViewModel>
    {
        private readonly IQueryable<Cat> _cats;
        private readonly IQueryable<Person> _persons;

        public DynamicCatsFilterQuery(IQueryable<Cat> cats, IQueryable<Person> persons)
        {
            _cats = cats;
            _persons = persons;
        }

        public IReadOnlyCollection<Cat> Execute(CatsFilterViewModel filter)
        {
            IQueryable<Cat> filteredCats = _cats;
            if (!string.IsNullOrEmpty(filter.NameLike))
                //Example of simple logic inmplemented in query
                filteredCats = filteredCats.Where(c => c.Name.Contains(filter.NameLike));

            if (filter.hasOwner.HasValue )
            {
                //Example of reusable join logic  
                IQueryable<Tuple<Cat, Person>> catsWithOwners = (new HasOwnerCriteria(filteredCats, _persons)).Apply();

                if (!filter.hasOwner.Value)
                    //fix for EF !!!!
                    filteredCats = filteredCats.Where(c => !catsWithOwners.Select(c1 => c1.Item1).Contains(c));

                if (filter.onwerGender.HasValue && filter.hasOwner.Value)
                    filteredCats = catsWithOwners.Where(t => t.Item2.Gender == filter.onwerGender.Value)
                        .Select(t => t.Item1);
            }

            if (filter.CuteFactorMin.HasValue)
                //Example of simple reusable logic in criteria 
                filteredCats = (new CuteFactorMinCriteria(filteredCats)).Apply(filter.CuteFactorMin.Value);

            if (filter.FieldsOrdering!= null && filter.FieldsOrdering.Any())
                //Example of complex reusable logic isoleted in criteria
                filteredCats = (new OrderingCriteria<Cat>(filteredCats)).Apply(filter.FieldsOrdering);

            //run final query
            return filteredCats.ToArray();
        }
    }
}