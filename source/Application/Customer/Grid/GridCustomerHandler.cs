namespace Architecture.Application;

public sealed record GridCustomerHandler : IHandler<GridCustomerRequest, Grid<CustomerModel>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IResultService _resultService;

    public GridCustomerHandler
    (
        ICustomerRepository customerRepository,
        IResultService resultService
    )
    {
        _customerRepository = customerRepository;
        _resultService = resultService;
    }

    public async Task<Result<Grid<CustomerModel>>> HandleAsync(GridCustomerRequest request)
    {
        var grid = await _customerRepository.GridAsync(request);

        return _resultService.Success(grid);
    }
}
