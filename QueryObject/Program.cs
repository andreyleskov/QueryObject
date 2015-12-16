using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace QueryObject
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class CompositionRoot
    {
        public IContainer ConfigureContainer(IContainer container)
        {
            return container;
        }
    }

}
