using System.Data;

namespace AA.Bancs.Transversal.Commom
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}

