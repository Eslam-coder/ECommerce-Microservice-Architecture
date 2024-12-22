using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface IQueryHandler<TQuery, TQueryResult> : IRequestHandler<TQuery, TQueryResult>
        where TQuery : IQuery<TQueryResult>
    {
    }
}
