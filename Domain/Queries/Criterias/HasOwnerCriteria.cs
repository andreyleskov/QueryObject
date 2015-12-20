using System;
using System.Linq;
using Infrastructure;

namespace Domain.Queries
{
    class HasOwnerCriteria : ICriteria<Tuple<Cat,Person>>
    {
        private readonly IQueryable<Cat> _cats;
        private readonly IQueryable<Person> _persons;

        public HasOwnerCriteria(IQueryable<Cat> cats, IQueryable<Person> persons)
        {
            _persons = persons;
            _cats = cats;
        }


        public IQueryable<Tuple<Cat,Person>> Apply()
        {
            return (from c in _cats
                join p in _persons on c.OwnerId equals p.Id
                select Tuple.Create(c, p));
        }
    }
}