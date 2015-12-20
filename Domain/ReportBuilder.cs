using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace Domain
{
    public class ReportBuilder
    {
        private readonly IQuery<Cat, int> _mostPopularCatsForLadyesQuery;

        public ReportBuilder(IQuery<Cat,int> mostPopularCatsForLadyesQuery)
        {
            _mostPopularCatsForLadyesQuery = mostPopularCatsForLadyesQuery;
        }

        public IReadOnlyCollection<string> MostPopularCatNamesForLadies(int top)
        {
            return _mostPopularCatsForLadyesQuery.Execute(top).Select(c => c.Name).ToArray();
        } 
    }
}
