using System.Linq;
using Infrastructure;

namespace Domain
{
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
}