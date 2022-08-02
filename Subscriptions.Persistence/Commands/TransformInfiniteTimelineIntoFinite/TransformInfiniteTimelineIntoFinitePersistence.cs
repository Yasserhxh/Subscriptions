using System;
using System.Threading.Tasks;
using Dapper;
using Subscriptions.Application.Commands.TransformInfiniteTimelineIntroFinite.Persistence;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Persistence.Commands.TransformInfiniteTimelineIntoFinite
{
    public class TransformInfiniteTimelineIntoFinitePersistence : ITransformInfiniteTimelineIntoFinitePersistence
    {
        private readonly IUnitOfWorkContext _unitOfWorkContext;

        public TransformInfiniteTimelineIntoFinitePersistence(IUnitOfWorkContext unitOfWorkContext)
        {
            _unitOfWorkContext = unitOfWorkContext;
        }

        public async Task<TimeLine> GetTimeline(string id)
        {
            var sql = "select * from timeline where id = @id";
            var con = _unitOfWorkContext.GetSqlConnection();
            return await con.QueryFirstOrDefaultAsync<TimeLine>(sql, new {id}, _unitOfWorkContext.GetTransaction());
        }

        public async Task SetTimeLineEnd(string id,DateTime now)
        {
            var sql = "update timeline set during = tstzrange(lower(during),@now) where id = @id";
            var con = _unitOfWorkContext.GetSqlConnection();
            await con.ExecuteAsync(sql, new {now, id}, _unitOfWorkContext.GetTransaction());
        }
    }
}