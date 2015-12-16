using System.Collections.Generic;
using System.Linq;
using Infrastructure;

namespace Domain
{

    public class TopLadiesCats : IQuery<Cat, int>
    {
        private readonly IQueryable<Cat> _cats;
        private readonly IQueryable<Person> _persons;

        public TopLadiesCats(IQueryable<Cat> cats, IQueryable<Person> persons)
        {
            _cats = cats;
            _persons = persons;
        }

        public IReadOnlyCollection<Cat> Execute(int topCatsCount)
        {
            return new TopCutiesCats(new CatsForLadies(_cats, _persons).Apply())
                       .Execute(topCatsCount)
                       .ToArray();
        }
    }


    public class TopCutiesCats : ICriteria<Cat,int>
    {
        private IQueryable<Cat> _cats;

        public TopCutiesCats(IQueryable<Cat> cats)
        {
            _cats = cats;
        }


        public IQueryable<Cat> Execute(int top)
        {
            return _cats.OrderByDescending(c => c.CuteFactor).Take(top);
        }
    }


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