using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface IQuery<TQueryResult> : IRequest<TQueryResult> 
    {
    }
}
