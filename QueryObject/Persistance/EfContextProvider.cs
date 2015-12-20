using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistance
{
    public class EfContextProvider<T> where T:DbContext
    {
        private T _context;

        public EfContextProvider(T context)
        {
            _context = context;
        }
    }

}
