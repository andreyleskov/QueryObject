using System.Linq;
using Infrastructure;

namespace Domain.Queries
{
    class CuteFactorMinCriteria : ICriteria<Cat, int>
    {
        private readonly IQueryable<Cat> _cats;

        public CuteFactorMinCriteria(IQueryable<Cat> cats )
        {
            _cats = cats;
        }

        public IQueryable<Cat> Apply(int cuteFactor)
        {
            return _cats.Where(c => c.CuteFactor >= cuteFactor);
        }
    }
}