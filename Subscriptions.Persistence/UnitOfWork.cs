using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Npgsql;
using Subscriptions.Application.Common.Interfaces;

namespace Subscriptions.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbTransaction Transaction { get; private set; }
        public bool IsDisposed;
        private readonly NpgsqlConnection _connection;

        public UnitOfWork(NpgsqlConnection connection)
        {
            _connection = connection;
        }


        public async Task BeginWork()
        {
            Transaction = await _connection.BeginTransactionAsync();
        }

        public async Task CommitWork()
        {
            if (Transaction is null)
            {
                throw new Exception("you should begin transaction before commiting ");
            }

            await Transaction.CommitAsync();
        }

        public async Task RollBack()
        {
            if (Transaction is null)
            {
                throw new Exception("you should begin transaction before executing rollback ");
            }

            await Transaction.RollbackAsync();
        }

        public async ValueTask DisposeAsync()
        {
            Console.WriteLine("called");
            await Transaction.DisposeAsync();
            IsDisposed = true;

        }

     
    }
}
