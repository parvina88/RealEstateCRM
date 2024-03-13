namespace RealEstate.Contract.Queries;

public abstract record PagedQuery<T> : IRequest<List<T>> 
{
    public int Skip { get; set; }
    public int Page { get; init; }
    public int PageSize { get; init; }
    public string? Search { get; init; }
    public string? OrderBy { get; init; }
    public bool OrderByDescending { get; init; }
}
