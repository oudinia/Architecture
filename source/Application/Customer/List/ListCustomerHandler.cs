namespace Architecture.Application;

public sealed record ListCustomerHandler : IHandler<ListCustomerRequest, IEnumerable<CustomerModel>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IResultService _resultService;

    public ListCustomerHandler
    (
        ICustomerRepository customerRepository,
        IResultService resultService
    )
    {
        _customerRepository = customerRepository;
        _resultService = resultService;
    }

    public async Task<Result<IEnumerable<CustomerModel>>> HandleAsync(ListCustomerRequest request)
    {
        var customers = await _customerRepository.ListModelAsync();

        return _resultService.Success(customers);
    }
}
