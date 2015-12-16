using Autofac;
using Domain;

namespace QueryObject
{
    public class CompositionRoot
    {
        public ContainerBuilder ConfigureContainer(ContainerBuilder container)
        {
            container.RegisterType<ReportBuilder>().AsSelf()
                     
        }
    }
}