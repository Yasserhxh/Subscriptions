using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Npgsql;

namespace Subscriptions.Application.Common.Interfaces
{
    public interface IUnitOfWorkContext
    {
        public DbTransaction GetTransaction();
        public NpgsqlConnection GetSqlConnection();
        Task<IUnitOfWork> CreateUnitOfWork();
    }
}