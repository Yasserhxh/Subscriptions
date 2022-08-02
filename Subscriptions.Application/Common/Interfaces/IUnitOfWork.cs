using System;
using System.Threading.Tasks;

namespace Subscriptions.Application.Common.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task BeginWork();
        Task CommitWork();
        Task RollBack();
    }
}