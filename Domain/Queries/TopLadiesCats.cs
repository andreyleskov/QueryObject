using System.Collections.Generic;
using System.Linq;
using Infrastructure;

namespace Domain
{

    public class TopCutiestCatsForLadies : IQuery<Cat, int>
    {
        private readonly IQueryable<Cat> _cats;
        private readonly IQueryable<Person> _persons;

        public TopCutiestCatsForLadies(IQueryable<Cat> cats, IQueryable<Person> persons)
        {
            _cats = cats;
            _persons = persons;
        }

        public IReadOnlyCollection<Cat> Execute(int topCatsCount)
        {
            return new TopCutiesCats(new CatsForLadies(_cats, _persons).Apply())
                       .Apply(topCatsCount)
                       .ToArray();
        }
    }

}