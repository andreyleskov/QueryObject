using System.Linq;
using Infrastructure;

namespace Domain
{
    public class CatsForLadies:ICriteria<Cat>
    {
        private IQueryable<Cat> _cats;
        private IQueryable<Person> _persons;

        public CatsForLadies(IQueryable<Cat> cats, IQueryable<Person> persons)
        {
            _persons = persons;
            _cats = cats;
        }


        public IQueryable<Cat> Apply()
        {
            return (from c in _cats
                join p in _persons on c.OwnerId equals p.Id
                where p.Gender == Gender.Female
                select c);
        }
    }
}