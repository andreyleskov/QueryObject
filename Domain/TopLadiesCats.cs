using System.Collections.Generic;
using System.Linq;
using Infrastructure;

namespace Domain
{

    public class TopCutietsCatsForLadies : IQuery<Cat, int>
    {
        private readonly IQueryable<Cat> _cats;
        private readonly IQueryable<Person> _persons;

        public TopCutietsCatsForLadies(IQueryable<Cat> cats, IQueryable<Person> persons)
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

}