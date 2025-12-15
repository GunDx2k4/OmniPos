namespace OmniPos.Application.Common.Queries;

public interface IQueryHandler<TQuery, IResult> where TQuery : IQuery<IResult>
{
    Task<IResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}
