using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{

    public interface IQuery<T>
    {
        IReadOnlyCollection<T> Execute();
    }

    public interface ISingleQuery<T>
    {
        T Execute();
    }

    public interface IQuery<T,U>
    {
        IReadOnlyCollection<T> Execute(U p1);
    }

    public interface IQuery<T, U, V>
    {
        IReadOnlyCollection<T> Execute(U p1, V p2);
    }
}
