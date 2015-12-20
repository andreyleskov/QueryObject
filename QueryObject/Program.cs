using System.Linq;
using Autofac;
using Domain;
using Infrastructure;

namespace QueryObject
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    //public class CompositionRoot
    //{
    //    public ContainerBuilder ConfigureContainer(ContainerBuilder container)
    //    {
    //        container.Register<TopCutiestCatsForLadies>()
    //                 .As<IQuery<Cat, int>>()
    //                 .;
    //        container.Register<ReportBuilder>().AsSelf();
    //        return container;
    //    }
    //}
}
